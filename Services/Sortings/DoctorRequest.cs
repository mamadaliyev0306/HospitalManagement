using EntityManagement.DataAcces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesManagement.Sortings
{
    public class DoctorRequest
    {
        public int DoctorId { get; set; }

        public string Firstname { get; set; }
        public bool IsActive { get; set; }
        public string Lastname { get; set; }
        public int SpecialityId { get; }
        public DoctorRequest(int doctorId, string firstname, string lastname, int specialityId, bool isActive)
        {
            DoctorId = doctorId;
            Firstname = firstname;
            Lastname = lastname;
            SpecialityId = specialityId;
            IsActive = isActive;
        }
    }
}
