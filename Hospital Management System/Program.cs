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

            //generate doctor id :
            int doctorId = (context.doctors.Count) + 1;


            //add doctor in list of system storage:
            context.doctors.Add(new Doctor
            {
                doctorId = doctorId,
                doctorName = doctorName,
                doctorSpecialization = doctorSpecialization,
                doctorPhone = doctorPhone,
                doctorEmail = doctorEmail,
                consultationFee = consultationFee
            });
            Console.WriteLine("Doctor added successfully with Id:" + doctorId);
        }

        public static void DisplayAllPatients(HospitalContext context)
        {
            foreach (Patient patient in context.patients)
            {
                if (context.patients == null)
                {
                    Console.WriteLine("No patient registered yet.");
                }
                else
                {
                    Console.WriteLine("ID:" + patient.patientId + ",Name:" + patient.patientName + ",Age:" + patient.patientAge + ", Gender:" + patient.patientGender + ",phone: " + patient.patientPhone + ",Email:" + patient.patientEmail + ", BloodType:" + patient.patientBloodType);
                }
            }
        }

        public static void DisplayAllDoctorsBySpetialization( HospitalContext context)
        {
            foreach ( Doctor doctor in context.doctors)
            {
                if (doctor.doctorSpecialization == doctor.doctorSpecialization)
                {
                    Console.WriteLine($"doctor name:{doctor.doctorName}, doctor Specialization:{doctor.doctorSpecialization}");
                }
                else
                {
                    Console.WriteLine(" not matched spetailization. ");
                }
            }
        }

        public static void AddAvilableTimeSlotForDoctor(HospitalContext context)
        {
            //generate slot id:
            int slotId = (context.availableSlots.Count)+1;

            Console.WriteLine("Enter doctor id:");
            int doctorId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter slot Date :");
            string slotDate = Console.ReadLine();

            Console.WriteLine("Enter slot Time:");
            string slotTime = Console.ReadLine();
            context.availableSlots.Add(new AvailableSlot
            {
                slotId=slotId,
                doctorId=doctorId,
                slotDate=slotDate,
                slotTime=slotTime,
                isBooked=false
            });
            
                Console.WriteLine(" slot has been added successfuly.");
            
           
        }

        public static void BookAppointment(HospitalContext context)
        {

            // generate appointment Id:
            int appointmentId = (context.appointments.Count) + 1;

            Console.WriteLine("Enter patient id: ");
            int patientid = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter doctor id: ");
            int doctorid = int.Parse(Console.ReadLine());

            foreach( var slot in context.availableSlots)
            {
                if ( slot.doctorId == doctorid && slot.isBooked == false)
                {
                    Console.WriteLine($"slot id :{slot.slotId} , Date: {slot.slotDate}, Time: {slot.slotTime}");
                    Console.WriteLine("no slots booked yet");
                }
              
                else
                {
                    Console.WriteLine("slot is already booked.");
                }
            }

            Console.WriteLine("Enter slot id: ");
            int slotId = int.Parse(Console.ReadLine());
            if (slotId == slotId)
            {
                Console.WriteLine("");
            }

            Console.WriteLine("Enter status : ");
            string status = Console.ReadLine();

            context.appointments.Add(new Appointment
            {
                appointmentId=appointmentId,
                patientId=patientid,
                doctorId=doctorid,
                
                status="unbooked"
            });
            if (status =="booked")
            {
                Console.WriteLine(" time slot as no longer available.");
            }
            else
            {
                Console.WriteLine(" time slot is available.");
            }
        }

        public static void CancelAppointment(HospitalContext context)
        {
            Console.WriteLine("Enter appointment Id:");
            int AppointmentId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter slot id: ");
            int slotId = int.Parse(Console.ReadLine());

            var appointment = context.appointments.FirstOrDefault(find => find.appointmentId == AppointmentId);

            var slot = context.availableSlots.FirstOrDefault(s => s.slotId == slotId);

            if (appointment == null)
            {
                Console.WriteLine(" appointment not found.");
            }
            else if (appointment.status == "cancelled")
            {
                
                Console.WriteLine("appointment is alrady cancelld");
            }
            else
            {
                slot.isBooked = true;
                Console.WriteLine("Appointment cancelled successfully.");
            }
            
           
        }

        public static void CreateMedicalRecord(HospitalContext context)
        {
            Console.WriteLine("Enter appointment Id:");
            int appointmentId = int.Parse(Console.ReadLine());

            var appointment = context.appointments.FirstOrDefault(a => a.appointmentId ==appointmentId );

            if (appointment == null)
            {
                Console.WriteLine("Appointment not found.");
            }
            else if (appointment.status == "Compleated")
            {
                Console.WriteLine("Already completed");
            }

            Console.WriteLine("Enter diagnosis:");
            string diagnosis = Console.ReadLine();

            Console.WriteLine("Enter medication:");
            string medication = Console.ReadLine();

            if (diagnosis=="" || medication == "")
            {
                Console.WriteLine("Error: missing data!");
            }

            
            context.medicalRecords.Add(new MedicalRecord
            {
                appointmentId = appointmentId,
                diagnosis = diagnosis,
                prescription = medication,
               
            });
            appointment.status = "compleated";
            Console.WriteLine("Medical record created successfully.");
        }
        static void Main(string[] args)
        {
            HospitalContext maincontext = new HospitalContext();

            maincontext.patients = new List<Models.Patient>();
            maincontext.doctors = new List<Models.Doctor>();
            maincontext.appointments = new List<Models.Appointment>();
            maincontext.medicalRecords = new List<Models.MedicalRecord>();
            maincontext.availableSlots = new List<Models.AvailableSlot>();


            bool exit = false;
            while (exit == false)
            {
                //let system begin
                Console.WriteLine("welcome to hospital manegment system!");
                Console.WriteLine(" please select an option:");
                Console.WriteLine("1.Register Patient:");
                Console.WriteLine("2.Register Doctor:");
                Console.WriteLine("3.Display All Patients:");
                Console.WriteLine("4.Display All Doctors By Spetialization:");
                Console.WriteLine("5.Add Avilable Time Slot For Doctor:");
                Console.WriteLine("6.Book Appointment:");
                Console.WriteLine("7.Cancel Appointment:");
                Console.WriteLine("8.Create Medical Record:");

                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                 case 1:
                        RegisterPatient(maincontext);
                    break;

                 case 2:
                        RegisterDoctor(maincontext);
                     break;

                    case 3:
                        DisplayAllPatients(maincontext);
                        break;

                    case 4:
                        DisplayAllDoctorsBySpetialization(maincontext);
                        break;

                    case 5:
                        AddAvilableTimeSlotForDoctor(maincontext);
                        break;

                    case 6:
                        BookAppointment(maincontext);
                        break;
                    case 7:
                        CancelAppointment(maincontext);
                        break;

                    case 8:
                        CreateMedicalRecord(maincontext);
                        break;
                }
            }
        }

    }
}
