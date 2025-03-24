
using EntityManagement.DataAcces;
using HospitalManagement.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesManagement.Sortings;
public record GetDoctorQuery(string SearchTerm) : IRequest<List<DoctorRequest>>;

