using EntityManagement;
using EntityManagement.DataAcces.DbContext_Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesManagement.ModdelRepository;
public interface IPatientRepository 
{
 Task<IList<Patient>> GetPatientsSeverity(int serverity);
 }
public class PatientRepository : IPatientRepository
{
    private readonly HospitalContext _context;
    private  readonly IMemoryCache _cache;
    public PatientRepository(HospitalContext context,IMemoryCache memoryCache)
    {
        _context = context;
        _cache = memoryCache;
    }
    public async Task<IList<Patient>> GetPatientsSeverity(int serverity)
    {
        if (_cache.TryGetValue("Patients", out IList<Patient> patients))
        {
            return patients;
        }
        var patientsAll =await _context.Patients
            .Include(p => p.PatientBlank)
            .Where(p => p.PatientBlank.Severity > serverity).ToListAsync();
        return patientsAll;
    }
}

