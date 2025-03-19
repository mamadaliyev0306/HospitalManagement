using EntityManagement.DataAcces.DbContext_Entity;
using EntityManagement.DataAcces;
using Services.ModdelRepozitory;
using ServicesManagement.ModdelRepository.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesManagement.ModdelRepository
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(HospitalContext context) : base(context)
        {
        }
    }
}
