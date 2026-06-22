using Hospital_Management_System.Models;
using System.Numerics;
using static System.Reflection.Metadata.BlobBuilder;

namespace Hospital_Management_System
{
    public class Program
    {
        public static void RegisterPatient(List<Patient> patients)
        {
            Console.WriteLine("\n=== Register New Patient ===");
            //insert patient info:
            Console.WriteLine("Enter patient name:");
            string pName = Console.ReadLine();

            Console.WriteLine("Enter patient Age: ");
            int pAge = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter gender: ");
            string pGender = Console.ReadLine();

            Console.WriteLine("Enter patient Phone");
            string patientPhonenumber = Console.ReadLine();

            Console.WriteLine("Enter patient Email:");
            string pEmail = Console.ReadLine();

            Console.WriteLine("Enter patient BloodType:");
            string pBloodType = Console.ReadLine();

            //generate patient id :
            int pId = (patients.Count) + 1;

            //add patient in list of system storage:
            //context.patients.Add(new Patient
            //{
            //    patientId = patientId,
            //    patientName = pName,
            //    patientAge = pAge,
            //    patientGender = pGender,
            //    patientPhone = patientPhone,
            //    patientEmail = pEmail,
            //    patientBloodType = patientBloodType
            //});

            patients.Add(new Patient( pId,  pName,  pAge,  pGender, patientPhonenumber, pEmail, pBloodType));

            Console.WriteLine("Pateint added successfully with Id:" + pId);
        }
        public static void RegisterDoctor(List<Doctor> doctors)
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
            int doctorId = (doctors.Count) + 1;


            //add doctor in list of system storage:
            doctors.Add(new Doctor
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

        public static void DisplayAllPatients(List<Patient> patients)
        {
            Console.WriteLine("\n=== All Registered Patients ===");

            if (patients.Count == 0)
            {
                Console.WriteLine("No patient registered yet.");
                return;
            }
            //display table of patients:
            foreach (Patient patient in patients)
            {
                patient.printPatient();
            }
            
            //foreach (Patient patient in context.patients)
            //{
            //    if (context.patients == null)
            //    {
            //        Console.WriteLine("No patient registered yet.");
            //    }
            //    else
            //    {
            //        Console.WriteLine("ID:" + patient.patientId + ",Name:" + patient.patientName + ",Age:" + patient.patientAge + ", Gender:" + patient.patientGender + ",phone: " + patient.patientPhone + ",Email:" + patient.patientEmail + ", BloodType:" + patient.patientBloodType);
            //    }
            //}

        }

        public static void ViewAllPatientOlderThan50(List<Patient> patients)
        {
            Console.WriteLine("\n=== All Registered Patients ===");
            if (patients.Count == 0)
            {
                Console.WriteLine("No Patients older than 50 years.");
                return;
            }

            //view patient older than 50:
            List<Patient> olderthan50 = patients.Where(p => p.patientAge > 50)
                                                .ToList();//only view 
            //we need to print this list that have patients older than 50:
            foreach(Patient p in olderthan50)
            {
                p.printPatient();
            }

        }

        public static void DisplayAllDoctorsBySpetialization( List<Doctor> doctors)
        {
            Console.WriteLine("\n=== Search Doctors by Specialization ===");

            Console.Write("Enter specialization to search: ");
            
            string insert = Console.ReadLine().ToLower();//to make it same as writed in table

            List<Doctor> Matched = doctors.Where(d => d.doctorSpecialization
                                          .ToLower() == insert)
                                          .ToList();//view in list

            if (Matched.Count == 0)
            {
                Console.WriteLine("No doctors found with this Specialization "+ insert);
                return;
            }

            Matched.ForEach(d => Console.WriteLine($"doctor name:{d.doctorName}, doctor Specialization:{d.doctorSpecialization}"));
            //    });
            //foreach ( Doctor doctor in context.doctors)
            //{
            //    if (doctor.doctorSpecialization == doctor.doctorSpecialization)
            //    {
            //        Console.WriteLine($"doctor name:{doctor.doctorName}, doctor Specialization:{doctor.doctorSpecialization}");
            //    }
            //    else
            //    {
            //        Console.WriteLine(" not matched spetailization. ");
            //    }
            //}
        }

        public static void AddAvilableTimeSlotForDoctor(HospitalContext context)
        {
            Console.WriteLine("\n=== Add Available Slot for Doctor ===");
            
            //make sure that there is no doctors in system...
            if (context.doctors.Count == 0)
            {
                Console.WriteLine("No doctors in the system yet!");
                return;
            }

            //see available doctors in system:
            Console.WriteLine("=====Available doctors:=====");

            //print all doctors:
            context.doctors.ForEach(d => d.printDoctor());

            Console.WriteLine("Enter doctor id:");
            int doctorId = int.Parse(Console.ReadLine());

            //validation for doctor id:

            Doctor doctor = context.doctors.FirstOrDefault(d => d.doctorId == doctorId);
            if (doctor == null)
            {
                Console.WriteLine("Doctor not found.");
                return;
            }
                //or
                bool validDoctorTD = context.doctors.Any(d => d.doctorId == doctorId);

            //if doctor not found print this:
            if (validDoctorTD == false)
            {
                Console.WriteLine("No doctors founded.");
                return;
            }

            
            Console.WriteLine("Enter slot Date :");
            string slotDate = Console.ReadLine();

            Console.WriteLine("Enter slot Time:");
            string slotTime = Console.ReadLine();

            //generate slot id:
            int slotId = (context.availableSlots.Count) + 1;

            context.availableSlots.Add(new AvailableSlot
            {
                slotId = slotId,
                doctorId = doctorId,
                slotDate = slotDate,
                slotTime = slotTime,
                isBooked = false
            });

            Console.WriteLine(" slot has been added successfuly.");

        }

         public static void BookAppointment(HospitalContext context)
        {


            Console.WriteLine("Enter patient id: ");
            int patientid = int.Parse(Console.ReadLine());

            //validation for patient id:
            Patient patient = context.patients.FirstOrDefault(p => p.patientId == patientid);
            if (patient == null)
            {
                Console.WriteLine("patient not found.");
                return;
            }


            //ask patient to choose doctor to treat with (ex: eys or heart doctor ets...)
            DisplayAllDoctorsBySpetialization(context.doctors);

            //ask patient to enter doctor id how choosed by patient:
            Console.WriteLine("Enter doctor id: ");
            int doctorId = int.Parse(Console.ReadLine());

            //validation for doctor id:
            Doctor doctor = context.doctors.FirstOrDefault(d => d.doctorId == doctorId);

            //if doctor not found print:
            if (doctor == null)
            {
                Console.WriteLine("not found");
                return;

            }


            ////=== NOW ==>>>> i want to see list of available slots for doctor tha unbooked yet:
            //// i already hav doctor id 

            List<AvailableSlot> slots = context.availableSlots.Where(s => s.doctorId == doctorId && s.isBooked == false)
                                                              .ToList();//convert to list


            //// if there is no available slots print no available slots:
            if (slots.Count == 0)
            {
                Console.WriteLine("No available slots fo this doctor.");
                return;
            }

            //    //if there is available slots print:
            Console.WriteLine($" available slots for {doctor.doctorName}");
            slots.ForEach(s => Console.WriteLine($"slot Id:{s.slotId},Date:{s.slotDate},Time:{s.slotTime}"));

            ////ask patient to inter slot id that he choosen :
            Console.WriteLine("Enter slot id:");
            int slotId = int.Parse(Console.ReadLine());

            //valid slot id and unbooked slot:
            AvailableSlot selectedslot = slots.FirstOrDefault(s => s.slotId == slotId);

            if (selectedslot == null)
            {
                Console.WriteLine("slot already booked");
            }

            // generate appointment Id:
            int appointmentId = (context.appointments.Count) + 1;

            //set status as schaduled
            context.appointments.Add(new Appointment
            {
                appointmentId = appointmentId,
                patientId = patientid,
                doctorId=doctorId,
                appointmentDate=selectedslot.slotDate,
                appointmentTime=selectedslot.slotTime,
                status = "schaduled"
            });
            
            //slot already booked
            selectedslot.isBooked = true;

            Console.WriteLine("Appointment booked successfully with Id:" + appointmentId);


            //foreach (var slot in context.availableSlots)
            //{
            //    if (slot.doctorId == doctorid && slot.isBooked == false)
            //    {
            //        //display table for doctor slot
            //        Console.WriteLine($"slot id :{slot.slotId} , Date: {slot.slotDate}, Time: {slot.slotTime}");

            //    }

            //    else 
            //    {
            //        Console.WriteLine("No available slots for this doctor.");
            //    }

            //}







            //Console.WriteLine("Enter Slot Id: ");
            //int slotId = int.Parse(Console.ReadLine());
            //foreach (var s in context.availableSlots)
            //{
            //    if (s.slotId == slotId)
            //    {
            //        s.isBooked = true;
            //    }
            //    else
            //    {
            //        Console.WriteLine("not booked yet.");
            //    }
            //}


        }

        public static void CancelAppointment(HospitalContext context)
        {
           
            Console.WriteLine("Enter appointment Id:");
            int AppointmentId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter slot id: ");
            int slotId = int.Parse(Console.ReadLine());

            Appointment appointment = context.appointments.FirstOrDefault(find => find.appointmentId == AppointmentId);

            //if appointment empty
            if (appointment == null)
            {
                Console.WriteLine(" appointment not found.");
                return;
            }

            if (appointment.status == "cancelled")
            {

                Console.WriteLine("appointment is alrady cancelld");
                return;
            }

            if (appointment.status == "Completed")
            {
                Console.WriteLine("Cannot cancel a completed appointment.");
                return;
            }

            AvailableSlot slot = context.availableSlots.FirstOrDefault(s =>
                s.doctorId == appointment.doctorId &&
                s.slotDate == appointment.appointmentDate &&
                s.slotTime == appointment.appointmentTime
            );

            if (slot != null)
                slot.isBooked = false;

            appointment.status = "Cancelled";
            Console.WriteLine($"Appointment {appointment.appointmentId} has been cancelled and the time slot is now available again.");

        }

        public static void ViewAllCancelledAppointments(HospitalContext context)
        {
            Console.WriteLine("\n=== Cancelled Appointments ===");
            
            //view cancelld appointments using where:
            List<Appointment> cancelledAppointments = context.appointments
                              .Where(a => a.status == "Cancelled")
                              .ToList();


            //if there is no cancelled appointments print:
            if (cancelledAppointments == null)
            {
                Console.WriteLine("No cancelled appointments found.");
                return;
            }

            //if there print:
            cancelledAppointments.ForEach(c => Console.WriteLine($"Id:{c.appointmentId}, patient Id:{c.patientId}, doctoor Id: {c.doctorId}, date:{c.appointmentDate}, time:{ c.appointmentTime}, status:{c.status}"));

        }

        public static void CreateMedicalRecord(HospitalContext context)
        {
            Console.WriteLine("Enter appointment Id:");
            int appointmentId = int.Parse(Console.ReadLine());

            var appointment = context.appointments.FirstOrDefault(a => a.appointmentId == appointmentId);

            if (appointment == null)
            {
                Console.WriteLine("Appointment not found.");
                return;
            }
           if (appointment.status == "Compleated")
            {
                Console.WriteLine("Already completed");
                return;
            }

            Console.WriteLine("Enter diagnosis:");
            string diagnosis = Console.ReadLine();

            Console.WriteLine("Enter medication:");
            string medication = Console.ReadLine();

            
            
   
        }
        static void Main(string[] args)
        {
            HospitalContext maincontext = new HospitalContext();

            
            maincontext.appointments = new List<Models.Appointment>();
            maincontext.medicalRecords = new List<Models.MedicalRecord>();
            maincontext.availableSlots = new List<Models.AvailableSlot>();

            maincontext.patients = new List<Models.Patient>()
            {
                new Patient(1,"sheika",25,"Female","+68995125165","sheika02@gmail.com","+O"),
                new Patient(1,"mira",33,"Female","+68999999995","mira@gmail.com","AB"),
                new Patient(1,"ali",45,"male","+689996655223","ali@gmail.com","-O"),
                new Patient(1,"majid",32,"male","+68971245875","majid@gmail.com","+B"),
                new Patient(1,"faridah",25,"Female","+68995124575","faridah@gmail.com","A")
            };

            
            bool exit = false;
            while (exit == false)
            {
                //let system begin
                Console.WriteLine("welcome to hospital manegment system!");
                Console.WriteLine(" please select an option:");
                Console.WriteLine("1.Register Patient:");
                Console.WriteLine("2.Register Doctor:");
                Console.WriteLine("3.Display All Patients:");
                Console.WriteLine("4.Display All Patients Older than 50:");
                Console.WriteLine("4.Display All Doctors By Spetialization:");
                Console.WriteLine("5.Add Avilable Time Slot For Doctor:");
                Console.WriteLine("6.Book Appointment:");
                Console.WriteLine("7.Cancel Appointment:");
                Console.WriteLine("8.Create Medical Record:");
                Console.WriteLine("9.exit...");

                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                 case 1:
                        RegisterPatient(maincontext.patients);
                    break;

                 case 2:
                        RegisterDoctor(maincontext.doctors);
                     break;

                    case 3:
                        DisplayAllPatients(maincontext.patients);
                        break;

                    case 4:
                        DisplayAllDoctorsBySpetialization(maincontext.doctors);
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
                    case 9:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("invalid option.try again.");
                        break;
                }


                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();// to wait for user input before clearing the console
                Console.Clear();
            }


        }

    }
}
