using HospitalManagement.Dtos;
using ServicesManagement.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesManagement.ModdelService.Interfaces
{
    public interface IAppointmentService
    {
        Task AddAppointment(ArrangeAppointmentDto arrangeAppointmentDto);
        bool CanCancelAppointment(DateTime appointmentDataTime);
    }
}
