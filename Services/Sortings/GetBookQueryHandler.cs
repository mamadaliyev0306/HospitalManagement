
using EntityManagement.DataAcces;
using EntityManagement.DataAcces.DbContext_Entity;
using HospitalManagement.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServicesManagement.Sortings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesManagement.Settings;
public sealed class GetDoctorQueryHandler : IRequestHandler<GetDoctorQuery, List<DoctorRequest>>
{
    private readonly HospitalContext _context;
    public GetDoctorQueryHandler(HospitalContext context) {  _context = context; }
    public async Task<List<DoctorRequest>> Handle(GetDoctorQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Doctor> doctorQueryable = _context.Doctors;
        if (!string.IsNullOrEmpty(request.SearchTerm))
        {
            doctorQueryable = doctorQueryable.Where(a =>
                a.Firstname.Contains(request.SearchTerm) ||
                a.Lastname.Contains(request.SearchTerm)
            );
        }
        var doctor = await doctorQueryable
            .Select(r => new DoctorRequest(
                r.DoctorId,
                r.Firstname,
                r.Lastname,
                r.SpecialityId,
                r.IsActive
            )).ToListAsync(cancellationToken);

        return doctor;
    }
}

