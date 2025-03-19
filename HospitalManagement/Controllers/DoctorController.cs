using HospitalManagement.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ServicesManagement.ModdelService.Interfaces;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        protected readonly IDoctorService _octorService;
        public DoctorController(IDoctorService octorService)
        {
            _octorService = octorService;
        }
        [HttpGet("gets")]
        public async Task<IActionResult> GetAll()
        {
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
