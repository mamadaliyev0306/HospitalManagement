using HospitalManagement.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ServicesManagement.Configurations;
using ServicesManagement.ModdelService.Interfaces;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly ILogger _logger;
        protected readonly IDoctorService _octorService;
        private readonly ICorrelationIdGenerator _correlationIdGenerator;
        public DoctorController(IDoctorService octorService,
            IOptions<CorrelationIdGenerator> correlationIdGenerator,
            ILogger<DoctorController> logger)
        {
            _octorService = octorService;
            _correlationIdGenerator=correlationIdGenerator.Value;
            _logger= logger;
        }
        [HttpGet("gets")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("CorrelationId:{correlationId}", _correlationIdGenerator.Get());
            var list= _octorService.GetAllDoctors();
            return Ok(list);
        }
        [HttpPost("post")]
        public async Task<ActionResult<bool>> PostMetod([FromBody] CreateDoctorDto doctorDto)
        {
           var result=await _octorService.CreateDoctor(doctorDto);
            return Ok(result);
        }
        [HttpPatch("patch")]
        public async Task< ActionResult<bool>> UpdatePatch([FromBody] DoctorDto doctorDto)
        {
            var result=await _octorService.UpdateDoctor(doctorDto);
            return Ok(result);
        }
        [HttpDelete("delete")]
        public async Task<ActionResult<bool>> DeleteMetod([FromBody] int Id)
        {
            var result = await _octorService.DeleteDoctor(Id);
            return Ok(result);
        }
    }
}
