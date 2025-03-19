using EntityManagement.DataAcces;

namespace HospitalManagement.Dtos;

public class DoctorDto
{

    public int DoctorId { get; set; }

    public string Firstname { get; set; }

    public string Lastname { get; set; }

    public int SpecialtyId { get; set; }
    public Doctor ToEntity()
    {
        return new()
        {
            Firstname = Firstname,
            Lastname = Lastname,
            IsActive = true,
            SpecialityId = SpecialtyId
        };
    }
}
