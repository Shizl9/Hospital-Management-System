using Hospital_Management_System.Models;

namespace Hospital_Management_System
{
    public class Program
    {
        public static void RegisterPatient(HospitalContext context)
        {
            //insert patient info:
            Console.WriteLine("Enter patient name:");
            string pName = Console.ReadLine();

            Console.WriteLine("Enter patient Age: ");
            int pAge = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter gender: ");
            string pGender = Console.ReadLine();

            Console.WriteLine("Enter patient Phone");
            string patientPhone = Console.ReadLine();

            Console.WriteLine("Enter patient Email:");
            string pEmail = Console.ReadLine();

            Console.WriteLine("Enter patient BloodType:");
            string patientBloodType = Console.ReadLine();

            //generate patient id :
            int patientId = (context.patients.Count) + 1;

            //add patient in list of system storage:
            context.patients.Add(new Patient
            {
                patientId = patientId,
                patientName = pName,
                patientAge = pAge,
                patientGender = pGender,
                patientPhone = patientPhone,
                patientEmail = pEmail,
                patientBloodType = patientBloodType
            });
            Console.WriteLine("Pateint added successfully with Id:" + patientId);
        }
        public static void RegisterDoctor(HospitalContext context)
        {
            //insert doctor info:
            Console.WriteLine("Enter doctor name:");
            string doctorName = Console.ReadLine();

            Console.WriteLine("Enter doctor Specialization:");
            string doctorSpecialization = Console.ReadLine();

            Console.WriteLine("Enter doctor Phone");
            string doctorPhone = Console.ReadLine();

            Console.WriteLine("Enter doctor Email:");
            string doctorEmail = Console.ReadLine();

            Console.WriteLine("Enter doctor consultationFee: ");
            decimal consultationFee = decimal.Parse(Console.ReadLine());
        }
            static void Main(string[] args)
        {
            HospitalContext maincontext = new HospitalContext();

            maincontext.patients = new List<Models.Patient>();
            maincontext.doctors = new List<Models.Doctor>();
            maincontext.appointments = new List<Models.Appointment>();
            maincontext.medicalRecords = new List<Models.MedicalRecord>();
            maincontext.availableSlots = new List<Models.AvailableSlot>();
        }
    }
}
