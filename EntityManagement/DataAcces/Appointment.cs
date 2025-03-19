using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityManagement.DataAcces
{
    [Table("Appointment",Schema ="DataAcces")]
    public class Appointment
    {
        public int AppointmentId { get; set; }

        public bool IsActive { get; set; }

        public DateTime RegisteredAt { get; set; }

        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }

    }
}
