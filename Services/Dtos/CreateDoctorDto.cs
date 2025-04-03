

using EntityManagement.DataAcces;

namespace HospitalManagement.Dtos;

public class CreateDoctorDto
{
    public string Firstname { get; set; }

    public string Lastname { get; set; }

    public int SpecialityId { get; set; }
}
