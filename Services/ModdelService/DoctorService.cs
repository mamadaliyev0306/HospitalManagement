using AutoMapper;
using EntityManagement.DataAcces;
using HospitalManagement.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ServicesManagement.ModdelRepository.InterfaceRepository;
using ServicesManagement.ModdelService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesManagement.ModdelService
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public DoctorService(IDoctorRepository doctorRepository,IMapper mapper)
        {
            _doctorRepository = doctorRepository;
        }


        public async Task<bool> CreateDoctor(CreateDoctorDto doctorDto)
        {
            if(doctorDto == null) 
                return false;
            var doctor = _mapper.Map<Doctor>(doctorDto);

            await _doctorRepository.AddAsync(doctor);
            await _doctorRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDoctor(int Id)
        {
            var result = await _doctorRepository.GetByIdAsync(Id);
            if (result == null)
            {
                return false;
            }
            _doctorRepository.Delete(result);
            await _doctorRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<DoctorDto>> GetAllDoctors()
        {
            var result = await _doctorRepository.GetAll().AsNoTracking().ToListAsync();
            if (result == null)
                return Enumerable.Empty<DoctorDto>();
            return _mapper.Map<IEnumerable<DoctorDto>>(result);
                
        }

        public async Task<bool> UpdateDoctor(DoctorDto doctorDto)
        {

            var result= await _doctorRepository.GetByIdAsync(doctorDto.DoctorId);
            if (result == null)
            {
                return false;
            }
             var doctor = _mapper.Map<Doctor>(result);
              _doctorRepository.Update(doctor);
            await _doctorRepository.SaveChangesAsync();
            return true ;
        }
    }
}
