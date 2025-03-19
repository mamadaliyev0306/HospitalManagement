using EntityManagement.DataAcces;
using HospitalManagement.Dtos;
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

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }


        public async Task<bool> CreateDoctor(CreateDoctorDto doctorDto)
        {
            if (doctorDto.SpecialtyId == null || doctorDto.Firstname==null || doctorDto.Lastname==null)
            {
                return false;
            }
            var doctor = doctorDto.ToEntity();

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

        public  IList<DoctorDto> GetAllDoctors()
        {
            return _doctorRepository.GetAll().AsNoTracking().Select(r => new DoctorDto()
            {
                DoctorId = r.DoctorId,
                Firstname = r.Firstname,
                Lastname = r.Lastname,
                SpecialtyId = r.SpecialityId
            }).ToList();
        }

        public async Task<bool> UpdateDoctor(DoctorDto doctorDto)
        {

            var result= await _doctorRepository.GetByIdAsync(doctorDto.DoctorId);
            if (result == null)
            {
                return false;
            }
            result.DoctorId = result.DoctorId;
            result.Lastname = doctorDto.Lastname;
            result.Firstname = doctorDto.Firstname;
            result.SpecialityId = doctorDto.SpecialtyId;
             _doctorRepository.Update(result);
            await _doctorRepository.SaveChangesAsync();
            return true ;
        }
    }
}
