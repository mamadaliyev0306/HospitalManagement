using EntityManagement.DataAcces;
using EntityManagement.DataAcces.DbContext_Entity;
using Services.ModdelRepozitory;
using ServicesManagement.ModdelRepository.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesManagement.ModdelRepository
{
    public  class AppointmentRepository:Repository<Appointment>,IAppointmentRepository
    {
        public AppointmentRepository(HospitalContext context) : base(context)
        {
        }
    }
}
