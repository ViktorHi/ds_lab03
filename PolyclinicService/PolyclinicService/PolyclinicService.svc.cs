﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.CRUD;
using Org.BouncyCastle.Crypto.Tls;

namespace PolyclinicService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "PolyclinicService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы PolyclinicService.svc или PolyclinicService.svc.cs в обозревателе решений и начните отладку.


    public class PolyclinicService : IPolyclinicService
    {

        ITokenManager tokenManager = new TokenManager("PolyclinincService", "DefaultPolyclynicUser");

        public List<Visit> GetVisits()
        {

            var token = tokenManager.FindOrAddToken();
            if(tokenManager.IsTockenPaymentValid(token, Functions.Get))
            {
                var dao = VisitDao.instanceOf();
                return dao.GetVisit();
            }

            throw new TokenNotFoundException("Payment or token not found. Operation GetVisits in Polyclinic Service");
        }

        public bool CreateVisit(Visit visit)
        {
            var token = tokenManager.FindOrAddToken();
            if (tokenManager.IsTockenPaymentValid(token, Functions.Create))
            {
                var dao = VisitDao.instanceOf();
                dao.CreateVisit(visit);
                return true;
            }

            throw new TokenNotFoundException("Payment or token not found. Operation CreateVisits in Polyclinic Service");
        }

        public bool DeleteVisit(Visit visit)
        {

            var token = tokenManager.FindOrAddToken();
            if (tokenManager.IsTockenPaymentValid(token, Functions.Delete))
            {
                var dao = VisitDao.instanceOf();
                dao.DeleteVisit(visit);

                return true;
            }

            throw new TokenNotFoundException("Payment or token not found. Operation DeleteVisits in Polyclinic Service");
        }

        public bool UpdateVisit(Visit visit)
        {
            var token = tokenManager.FindOrAddToken();
            if (tokenManager.IsTockenPaymentValid(token, Functions.Update))
            {
                var dao = VisitDao.instanceOf();
                dao.UpdateVisit(visit);

                return true;
            }

            throw new TokenNotFoundException("Payment or token not found. Operation UpdateVisits in Polyclinic Service");
        }

        List<Token> IPolyclinicService.getTokenPayments()
        {
            var token = tokenManager.FindOrAddToken();

            return tokenManager.GetTokensPayment(token);
        }

        void IPolyclinicService.PayToken(TokenPaymentDto tokenDto)
        {
            var token = tokenManager.FindOrAddToken();

            tokenManager.PayToken(token, tokenDto);
        }

        bool IPolyclinicService.IsTokenExists(Functions functions)
        {
            var token = tokenManager.FindOrAddToken();

            return tokenManager.IsTockenPaymentValid(token, functions);
        }
    }

    class VisitDao
    {
        private static VisitDao instance = null;
        private MySqlConnection connection;
        private String visit_table = "Visits";
        private String visit_patient_fio_table = "user_fio";
        private String visit_specializtion_table = "specialization";
        private String visit_doctor_fio_table = "doctor_fio";
        private String visit_date_table = "doctor_fio";
        private String visit_id_table = "id";


        public static VisitDao instanceOf()
        {
            if (instance == null)
            {
                instance = new VisitDao();
            }

            return instance;
        }

        private VisitDao()
        {
            connection = new MySqlConnection(getConnectionString());
        }

        public List<Visit> GetVisit()
        {

            List<Visit> visits = new List<Visit>();

            connection.Open();

            string sql = "SELECT * FROM " + visit_table + ";";

            MySqlCommand command = new MySqlCommand(sql, connection);

            using (DbDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {

                        int id = reader.GetInt32(0);
                        string patient = reader.GetString(1);
                        DateTime date = reader.GetDateTime(2);
                        string spec = reader.GetString(3);
                        string doctor = reader.GetString(5);

                        Visit visit = new Visit(id, doctor, patient, date, spec);
                        visits.Add(visit);
                    }
                }
            }
            connection.Close();

            return visits;
        }


        public void CreateVisit(Visit visit)
        {
            connection.Open();

            string sql = $"INSERT INTO {visit_table}({visit_patient_fio_table},{visit_doctor_fio_table},{visit_date_table}, {visit_specializtion_table}) " +
                $"VALUES( {visit.PatientFio},  {visit.DoctorFio}, {visit.Date.ToString("yyyy-M-dd")}, {visit.Date} )";
            MySqlCommand command = new MySqlCommand(sql, connection);

            command.ExecuteNonQuery();
            connection.Close();

        }

        public void UpdateVisit(Visit visit)
        {

            connection.Open();
            string sql = $"UPDATE {visit_table} SET {visit_doctor_fio_table}='" + visit.DoctorFio + $"', {visit_patient_fio_table}='" + visit.PatientFio
                + $"',{visit_date_table}='" + visit.Date.ToString("yyyy-M-dd") + $"',{visit_specializtion_table}='" + visit.Speciality + $"' where {visit_id_table} = " + visit.Id;
            MySqlCommand command = new MySqlCommand(sql, connection);

            command.ExecuteNonQuery();
            connection.Close();

        }

        public void DeleteVisit(Visit visit)
        {

            connection.Open();
            string sql = $"DELETE FROM {visit_table} where id = " + visit.Id + "";
            MySqlCommand command = new MySqlCommand(sql, connection);

            command.ExecuteNonQuery();
            connection.Close();

        }

        private string getConnectionString()
        {
            return "server=104.154.108.3;user=root;database=ds;password=DS@BSU;";
        }
    }

    interface ITokenManager
    {
        string GenerateToken();

        String FindOrAddToken();

        List<Token> GetTokensPayment(String token);

        void PayToken(string token, TokenPaymentDto dto);

        bool IsTockenPaymentValid(String token, Functions function);

        String MyServiceName();
        String MyServiceUser();
    }
    class TokenManager : ITokenManager
    {

        private MySqlConnection connection;

        private String serviceName;
        private String serviceUser;

        private String token_table = "Tokens";
        private String token_line_column = "line";
        private String token_server_name_column = "server_name";
        private String token_user_name_column = "server_user_name";


        private String token_payment_table = "Token_payment";
        private String token_payment_token_column = "token";
        private String token_payment_function_column = "function";
        private String token_payment_day1_column = "day1";
        private String token_payment_day2_column = "day2";

        private string getConnectionString()
        {
            return "server=104.154.108.3;user=root;database=ds;password=DS@BSU;";
        }

        public String MyServiceName()
        {
            return serviceName;
        }

        public String MyServiceUser()
        {
            return serviceUser;
        }

        public TokenManager(String serviceName, String serviceUser)
        {
            this.serviceName = serviceName;
            this.serviceUser = serviceUser;
            connection = new MySqlConnection(getConnectionString());
        }


        public string GenerateToken()
        {
            StringBuilder sb = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < 256; i++)
            {
                sb.Append(random.Next());
            }
            return sb.ToString();
        }

        public string FindOrAddToken()
        {
            string ans= null;
            connection.Open();
            string sql = $"SELECT * FROM {token_table} WHERE {token_server_name_column} = '" + MyServiceName() + "'";

            MySqlCommand command = new MySqlCommand(sql, connection);

            using (DbDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                  	if (reader.Read())
					{
						ans = reader.GetString(1);
					}
                }
                else
                {
                    ans = GenerateToken();

                    sql = $"INSERT INTO {token_table}({token_line_column}, {token_server_name_column}, {token_user_name_column}) " +
                        $"VALUES( '{ans}','{MyServiceName()}', '{MyServiceUser()}')";

                    command = new MySqlCommand(sql, connection);

                    command.ExecuteNonQuery();

                }

            }
            connection.Close();

            return ans;
        }

        public List<Token> GetTokensPayment(string token)
        {
            List<Token> tokens = new List<Token>();

            connection.Open();
            string sql = $"SELECT * FROM {token_payment_table} WHERE {token_payment_token_column} = '" + token + "'";

            MySqlCommand command = new MySqlCommand(sql, connection);

            using (DbDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {

                        int id = reader.GetInt32(0);
                        string data = reader.GetString(1);
                        string func = reader.GetString(2);
                        DateTime date1 = reader.GetDateTime(3);
                        DateTime date2 = reader.GetDateTime(4);

                        Token t = new Token(id, data, mapWithFunction(func), date1, date2);

                        tokens.Add(t);
                    }
                }
            }
            connection.Close();
            return tokens;

        }

        public void PayToken(string token, TokenPaymentDto dto)
        {

            connection.Open();

            string sql = $"INSERT INTO {token_payment_table}({token_payment_token_column}, {token_payment_function_column}, {token_payment_day1_column}, {token_payment_day2_column}) " +
                $"VALUES( '{token}','{dto.data}', '{dto.Date1}', '{dto.Date2}')";
            MySqlCommand command = new MySqlCommand(sql, connection);

            command.ExecuteNonQuery();

            connection.Close();

        }

        public bool IsTockenPaymentValid(String token, Functions function)
        {
            var tokens = GetTokensPayment(token);

            tokens = tokens.FindAll(e => e.Day1 < DateTime.Now && e.Day2 > DateTime.Now && e.Function == function);

            if (tokens.Count == 0)
            {
                return false;
            }
            return true;
            
        }

        private Functions mapWithFunction(String func)
        {
            switch (func)
            {
                case "Create": return Functions.Create;
                case "Update": return Functions.Update;
                case "Delete": return Functions.Delete;
                case "Get": return Functions.Get;
            }
            return Functions.Undefined;
        }
    }

}
