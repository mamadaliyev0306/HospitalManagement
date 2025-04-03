using ServicesManagement.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesManagement.ModdelService.Interfaces;

public interface IPatientService
{
    Task<IList<PatientDto>> GetHighSeverityPatientAsync();
}
