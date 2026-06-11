namespace Hospital_Management_System
{
    public class Program
    {
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
