using AutoMapper;
using EntityManagement.DataAcces.DbContext_Entity;
using ServicesManagement.Dtos;
using ServicesManagement.ModdelRepository;
using ServicesManagement.ModdelService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesManagement.ModdelService;

public class PatientService  : IPatientService
{
    private readonly IPatientRepository _repository;
    private readonly IMapper _mapper;
    public PatientService(IPatientRepository patientRepository)
    {
        _repository = patientRepository;
    }
    public async Task<IList<PatientDto>> GetHighSeverityPatientAsync()
    {
        var severities = await _repository.GetBySeverityPatients(5);
        var result = _mapper.Map<IList<PatientDto>>(severities);
        return result;
    }
}
