using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MySql.Data.MySqlClient;

namespace PolyclinicService
{
	// ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "PolyclinicService" в коде, SVC-файле и файле конфигурации.
	// ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы PolyclinicService.svc или PolyclinicService.svc.cs в обозревателе решений и начните отладку.
	public class PolyclinicService : IPolyclinicService
	{

		private string getConnectionString()
		{
			return "server=104.154.108.3;user=root;database=ds;password=DS@BSU;";
		}

		private string getServiceName()
		{
			return "PolyclinincService";
		}

		private string getUserEmail()
		{
			return "User";
		}

		private string createTokenData()
		{
			StringBuilder sb = new StringBuilder();
			Random random = new Random();
			for(int i=0;i<256;i++)
			{
				sb.Append(random.Next());
			}
			return sb.ToString();
		}

		private Token getOrCreateToken()
		{
			string connStr = getConnectionString();
			Token tokens;
			try
			{
				MySqlConnection conn = new MySqlConnection(connStr);
				conn.Open();
				string sql = "SELECT * FROM tokens WHERE service = '" + getServiceName() + "'";
				MySqlCommand command = new MySqlCommand(sql, conn);

				using (DbDataReader reader = command.ExecuteReader())
				{
					if (reader.HasRows)
					{

						while (reader.Read())
						{
							int id = reader.GetInt32(0);
							string data = reader.GetString(1);
							string service = reader.GetString(2);
							string userEmail = reader.GetString(5);


							Token token1 = new Token();
							token1.Id = id;
							token1.data = data;
							token1.userEmail = userEmail;
							return token1;
						}
					}
				}

				Token token = new Token();
				token.data = createTokenData();
				token.userEmail = getUserEmail();
				addToken(token);
				return token;
			}
			catch (Exception ex)
			{
				return null;
			}
		}


		public List<Visit> getUserVisits()
		{
			
			string connStr = getConnectionString();

			getOrCreateToken();

			List<Visit> visits = new List<Visit>();
			try
			{
				MySqlConnection conn = new MySqlConnection(connStr);
				conn.Open();
				string sql = "SELECT * FROM Visits WHERE user_email = '" + getUserEmail() + "'";
				MySqlCommand command = new MySqlCommand(sql, conn);

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
							string userEmail = reader.GetString(4);
							string doctor = reader.GetString(5);

							Visit visit = new Visit();
							visit.Id = id;
							visit.userEmail = userEmail;
							visit.DoctorFio = doctor;
							visit.PatientFio = patient;
							visit.Date = date;
							visit.Speciality = spec;

							visits.Add(visit);
						}
					}
				}
				return visits;
			}
			catch(Exception ex)
			{
				return new List<Visit>();
			}
			
		}

		public bool createVisit(Visit visit)
		{
			getOrCreateToken();

			string connStr = getConnectionString();
			try
			{
				MySqlConnection conn = new MySqlConnection(connStr);
			conn.Open();
			string sql = "INSERT INTO Visits(user_fio,date,specialization,user_email,doctor_fio) VALUES('"+visit.PatientFio
					+"','" + visit.Date.ToString("yyyy-M-dd") + "','"+visit.Speciality+"','" +
				visit.userEmail + "','"+visit.DoctorFio+"')";
			MySqlCommand command = new MySqlCommand(sql, conn);
			
				command.ExecuteNonQuery();
			}
			catch(Exception ex)
			{
				return false;
			}
			return true;
		}

		public bool deleteVisit(Visit visit)
		{
			getOrCreateToken();
			string connStr = getConnectionString();
			try
			{
				MySqlConnection conn = new MySqlConnection(connStr);
				conn.Open();
				string sql = "DELETE FROM Visits where id = "+visit.Id+"";
				MySqlCommand command = new MySqlCommand(sql, conn);

				command.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				return false;
			}
			return true;
		}

		public bool updateVisit(Visit visit)
		{
			getOrCreateToken();
			string connStr = getConnectionString();
			try
			{
				MySqlConnection conn = new MySqlConnection(connStr);
				conn.Open();
				string sql = "UPDATE Visits SET doctor_fio='"+visit.DoctorFio+ "', user_fio='" + visit.PatientFio 
					+ "',date='" + visit.Date.ToString("yyyy-M-dd") + "',speciality='" + visit.Speciality +"', user_email = '"+visit.userEmail
					+ "' where id = " + visit.Id;
				MySqlCommand command = new MySqlCommand(sql, conn);

				command.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				return false;
			}
			return true;
		}

		public List<Token> getUserTokens()
		{
			 
			string connStr = "server=localhost;user=root;database=polyclinic;password=haq611kl;";

			List<Token> tokens = new List<Token>();
			try
			{
				MySqlConnection conn = new MySqlConnection(connStr);
				conn.Open();
				string sql = "SELECT * FROM tokens WHERE user_email = '" + getUserEmail() + "'";
				MySqlCommand command = new MySqlCommand(sql, conn);

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
							string userEmail = reader.GetString(5);


							Token token = new Token();
							token.Id = id;
							token.data = data;
							//token.function = func;
							token.Date1 = date1;
							token.Date2 = date2;
							token.userEmail = userEmail;

							tokens.Add(token);
						}
					}
				}
				return tokens;
			}
			catch (Exception ex)
			{
				return null;
			}
		}
		
		public bool addToken(Token token)
		{
			
			string connStr = getConnectionString();
			try
			{
				MySqlConnection conn = new MySqlConnection(connStr);
				conn.Open();
				string sql = "INSERT INTO tokens(data, service, user_email) VALUES('" + token.data + "','" + getServiceName() + "', '"+
					getUserEmail() +"')";
				MySqlCommand command = new MySqlCommand(sql, conn);

				command.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				return false;
			}
			return true;
		}

		private Token findActualToken(string function)
		{
			/*DateTime curDate = DateTime.Now;
			List<Token> tokens = getAllTokens(user.userEmail);
			foreach(Token token in tokens)
			{
				if(token.Date1.CompareTo(curDate) <=0  && token.Date2.CompareTo(curDate) >= 0 && token.function.Equals(function))
				{
					return token;
				}
			}*/
			return null;
		}

		private List<Token> getAllTokens(string email)
		{
			string connStr = getConnectionString();

			List<Token> tokens = new List<Token>();
			try
			{
				MySqlConnection conn = new MySqlConnection(connStr);
				conn.Open();
				string sql = "SELECT * FROM tokens WHERE user_email = '" + email + "'";
				MySqlCommand command = new MySqlCommand(sql, conn);

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
							string userEmail = reader.GetString(5);


							Token token = new Token();
							token.Id = id;
							token.data = data;
							//token.function = func;
							token.Date1 = date1;
							token.Date2 = date2;
							token.userEmail = userEmail;

							tokens.Add(token);
						}
					}
				}
				return tokens;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		bool IPolyclinicService.addTokenForUser(TokenPaymentDto tokenDto)
		{
			throw new NotImplementedException();
		}
	}

	
}
