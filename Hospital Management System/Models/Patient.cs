using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Models
{
    public class Patient
    {
        public int patientId { get; set; }
        public string patientName { get; set; }
        public int patientAge { get; set; }
        public string patientGender { get; set; }
        public string patientPhone { get; set; }
        public string patientEmail { get; set; }
        public string patientBloodType { get; set; }

        //constructor:
        public Patient (int pId, string pName, int pAge, string pGender, string patientPhonenumber, string pEmail, string pBloodType)
        {
            patientId = pId;
            patientName = pName;
            patientAge = pAge;
            patientGender = pGender;
            patientPhone = patientPhonenumber;
            patientEmail = pEmail;
            patientBloodType = pBloodType;
        }

        //function for print information of patient:
        public void printPatient()
        {
            Console.WriteLine("ID:" +patientId + ",Name:" +patientName + ",Age:" + patientAge + ", Gender:" + patientGender + ",phone: " +patientPhone + ",Email:" + patientEmail + ", BloodType:" +patientBloodType);
        }
    }

}
