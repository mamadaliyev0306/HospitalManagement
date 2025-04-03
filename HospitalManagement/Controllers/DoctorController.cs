using HospitalManagement.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ServicesManagement.Dtos.Configurations;
using ServicesManagement.ModdelService.Interfaces;
using ServicesManagement.Sortings;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly ILogger _logger;
        protected readonly IDoctorService _octorService;
        private readonly ICorrelationIdGenerator _correlationIdGenerator;
        private readonly IMediator _mediator;
        public DoctorController(IDoctorService octorService,
            IOptions<CorrelationIdGenerator> correlationIdGenerator,
            ILogger<DoctorController> logger,
            IMediator mediator)
        {
            _octorService = octorService;
            _correlationIdGenerator=correlationIdGenerator.Value;
            _logger= logger;
            _mediator=mediator;
        }
        [HttpGet("gets")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("CorrelationId:{correlationId}", _correlationIdGenerator.Get());
            var list= await _octorService.GetAllDoctors();
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
        [HttpGet("search")]
        public async Task<IActionResult> SearchGet(string searchTrem)
        {
         _logger.LogInformation($"Search {searchTrem}");
            var search=new GetDoctorQuery(searchTrem);
            var sr=await _mediator.Send(search);
            return Ok(sr);
        }
    }
}
