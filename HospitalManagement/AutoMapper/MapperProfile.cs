using AutoMapper;
using EntityManagement;
using EntityManagement.DataAcces;
using HospitalManagement.Dtos;
using ServicesManagement.Dtos;

namespace HospitalManagement.AutoMapper;

public class MapperProfile:Profile
{
    public MapperProfile()
    {
        CreateMap<Doctor, DoctorDto>();
        CreateMap<Patient,PatientDto>();
        CreateMap<Doctor, CreateDoctorDto>();
        CreateMap<CreateDoctorDto, Doctor>();
    }
}