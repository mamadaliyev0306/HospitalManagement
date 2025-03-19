using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityManagement.DataAcces
{
    [Table("Doctor",Schema ="DataAcces")]
    public class Doctor
    {
        public Doctor() 
        {
            Appointments=new List<Appointment>();
        }
        public int DoctorId { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public bool IsActive { get; set; }

        public int SpecialityId { get; set; }
        public Speciality Speciality { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
