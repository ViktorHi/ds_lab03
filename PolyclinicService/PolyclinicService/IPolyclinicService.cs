using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PolyclinicService
{
	// ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IPolyclinicService" в коде и файле конфигурации.
	[ServiceContract]
	public interface IPolyclinicService
	{

		[OperationContract]
		List<Visit> GetVisits();

		[OperationContract]
		bool CreateVisit(Visit visit);

		[OperationContract]
		bool UpdateVisit(Visit visit);

		[OperationContract]
		bool DeleteVisit(Visit visit);
	}

	[DataContract]
	public class Visit
	{
		[DataMember]
		public int Id { get; set; }

		[DataMember]
		public string DoctorFio { get; set; }

		[DataMember]
		public string PatientFio { get; set; }

		[DataMember]
		public DateTime Date { get; set; }

		[DataMember]
		public string Speciality { get; set; }

		
		public Visit(string doctorFio, string patientFio, DateTime date, string speciality)
		{
			DoctorFio = doctorFio;
			PatientFio = patientFio;
			Date = date;
			Speciality = speciality;
		}

		public Visit(int id, string doctorFio, string patientFio, DateTime date, string speciality)
		{
			Id = id;
			DoctorFio = doctorFio;
			PatientFio = patientFio;
			Date = date;
			Speciality = speciality;
		}

	}

	

	[DataContract]
	public class Token
	{

		[DataMember]
		public int Id { get; set; }


		[DataMember]
		public string Line { get; set; }

		[DataMember]
		public Functions Function { get; set; }

		[DataMember]
		public DateTime Day1 { get; set; }

		[DataMember]
		public DateTime Day2 { get; set; }

		public Token(int id, string data, Functions function, DateTime date1, DateTime date2)
		{
			Id = id;
			Line = data;
			Function = function;
			Day1 = date1;
			Day2 = date2;
		}


	}


	[DataContract]
	public class TokenPaymentDto
	{
		[DataMember]
		public Functions data { get; set; }

		[DataMember]
		public DateTime Date1 { get; set; }

		[DataMember]
		public DateTime Date2 { get; set; }

        public TokenPaymentDto(Functions data, DateTime date1, DateTime date2)
        {
            this.data = data;
            Date1 = date1;
            Date2 = date2;
        }
    }


	public enum Functions
	{
		Create,
		Update,
		Delete,
		Get,
		Undefined
	}

	public class UserNotFoundException : Exception
	{
		public UserNotFoundException(string message)
		: base(message)
		{
		}
	}

	public class TokenNotFoundException : Exception
	{
		public TokenNotFoundException(string message)
		: base(message)
		{
		}
	}

}
	

