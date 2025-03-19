using EntityManagement.DataAcces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesManagement.Dtos
{
    public class ArrangeAppointmentDto
    {

        public bool IsActive { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime RegisteredAt { get; set; }

        public Appointment IEntity()
        {
            return new Appointment()
            {
                IsActive = this.IsActive,
                PatientId = this.PatientId,
                RegisteredAt = this.RegisteredAt,
                DoctorId = this.DoctorId
            };
        }
    }
}
