using Microsoft.Extensions.Options;
using ServicesManagement.Dtos;
using ServicesManagement.ModdelRepository.InterfaceRepository;
using ServicesManagement.ModdelService.Interfaces;
using ServicesManagement.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesManagement.ModdelService
{
    public class AppointmentService: IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly AppointmentSettings _options;

        public AppointmentService(IAppointmentRepository appointmentRepository,
            IOptions<AppointmentSettings> options)
        {
            _appointmentRepository = appointmentRepository;
            _options = options.Value;
        }
        public async Task AddAppointment(ArrangeAppointmentDto arrangeAppointmentDto)
        {
           var appointment = arrangeAppointmentDto.IEntity();
            await _appointmentRepository.AddAsync(appointment);
            await _appointmentRepository.SaveChangesAsync();
        }
        public bool CanCancelAppointment(DateTime appointmentDataTime)
        {
            TimeSpan timeSpan = appointmentDataTime - DateTime.Now;
            if (timeSpan.TotalHours > _options.CancellationDeadlineHours)
            {
                return true;
            }
            return false;
        }
    }

}
