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
		List<Visit> getUserVisits();

		[OperationContract]
		bool createVisit(Visit visit);

		[OperationContract]
		bool updateVisit(Visit visit);

		[OperationContract]
		bool deleteVisit(Visit visit);

		[OperationContract]
		List<Token> getUserTokens();

		[OperationContract]
		bool addTokenForUser(TokenPaymentDto tokenDto);
	}

	[DataContract]
	public class Visit
	{
		[DataMember]
		public int Id { get; set; }

		[DataMember]
		public string userEmail { get; set; }

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

		public Visit()
		{
		}
	}

	

	[DataContract]
	public class Token
	{

		[DataMember]
		public int Id { get; set; }

		[DataMember]
		public string userEmail { get; set; }

		[DataMember]
		public string data { get; set; }

		[DataMember]
		public Functions function { get; set; }

		[DataMember]
		public DateTime Date1 { get; set; }

		[DataMember]
		public DateTime Date2 { get; set; }

		public Token(string userEmail, string data, Functions function, DateTime date1, DateTime date2)
		{
			this.userEmail = userEmail;
			this.data = data;
			this.function = function;
			Date1 = date1;
			Date2 = date2;
		}

		public Token()
		{
		}
	}


	[DataContract]
	public class TokenPaymentDto
	{
		[DataMember]
		public string data { get; set; }

		[DataMember]
		public DateTime Date1 { get; set; }

		[DataMember]
		public DateTime Date2 { get; set; }
	}


	public enum Functions
	{
		Create,
		Update,
		Delete,
		Get
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
	

