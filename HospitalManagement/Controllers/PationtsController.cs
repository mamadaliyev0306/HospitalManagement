using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ServicesManagement.Dtos;
using ServicesManagement.ModdelService;
using ServicesManagement.ModdelService.Interfaces;
using ServicesManagement.Settings;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PationtsController : ControllerBase
    {
        private readonly DoctorsSettings _doctorsSettings;
        private readonly IAppointmentService _appointmentService;
        private readonly ILogger _logger;
        public PationtsController(IOptions<DoctorsSettings> options,
            IAppointmentService appointmentService,
            ILogger<PationtsController> logger)
        {
            _appointmentService = appointmentService;
            _doctorsSettings = options.Value;
            _logger = logger;
        }
        [HttpPost("post")]
        public async Task<IActionResult> ArrengeAppointment([FromBody] ArrangeAppointmentDto appointmentDto)
        {
            var time = TimeOnly.FromDateTime(appointmentDto.RegisteredAt);
            if (!time.IsBetween(_doctorsSettings.WorkTime.Start, _doctorsSettings.WorkTime.End))
            {
                _logger.LogWarning("Doctor is not available at this time");

                return BadRequest("Doctor is not available at this time");
            }
            _logger.LogInformation("Appointment arranged");
            await _appointmentService.AddAppointment(appointmentDto);
            return Ok("Your application arranged");
        }
        [HttpPost]
        public IActionResult CancelAppointment([FromBody] CancelAppointmentRequest cancelAppointmentRequest)
        {
            if (_appointmentService.CanCancelAppointment(cancelAppointmentRequest.AppointmentData))
            {
                _logger.LogInformation("Appointment canceled");
                return Ok("Appointment canceled");
            }
            _logger.LogWarning("Appointment can't be canceled");
            return BadRequest("Appointment can't be canceled");
        }
    }
}
