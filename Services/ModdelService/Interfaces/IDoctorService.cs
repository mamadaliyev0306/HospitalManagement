using EntityManagement.DataAcces;
using HospitalManagement.Dtos;
using Microsoft.EntityFrameworkCore;
using ServicesManagement.ModdelRepository.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesManagement.ModdelService.Interfaces
{
        public interface IDoctorService
        {
            Task<bool> CreateDoctor(CreateDoctorDto doctorDto); 

            IList<DoctorDto> GetAllDoctors(); 

            Task<bool> UpdateDoctor(DoctorDto doctorDto);

            Task<bool> DeleteDoctor(int id);
        }
}
