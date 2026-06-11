using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System
{
    public class HospitalContext
    {
        //system storage
        public List<Patient> patients { get; set; }
        public List<Doctor> doctors { get; set; }
        public List <Appointment> appointments { get; set; }
        public List<MedicalRecord> medicalRecords { get; set; }
        public List <AvailableSlot> availableSlots { get; set; }
    }
}
