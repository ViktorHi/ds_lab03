using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{

    public class Visit
    {

        public int Id { get; set; }

        public string userEmail { get; set; }

        public string DoctorFio { get; set; }

        public string PatientFio { get; set; }

        public DateTime Date { get; set; }

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
}
