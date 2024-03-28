using Clinic.Data.DTOs;
using Clinic.Data.Entities;
using Clinic.Data.Entities.Common.Primitives;

namespace Clinic.Data.Contracts;

public interface IDoctorRepository
{
    void Add(Doctorresponse doctor);

    void Remove(Doctorresponse doctor);

    void Update(Doctorresponse doctor); 

    Task<bool> IsCollegueNumberNotAvaliable(int collegueNumber);

    Task<Doctorresponse?> GetDoctorByNameAndCollegueNumber(string name,int collegueNumber);

    Task<Doctorresponse?> GetDoctorPersonById(int id);

    Task<PagedList<DoctorResponse>> GetDoctorsInformation(string? name,string? sortColumn,string? sortOrder,int page,int pageSize);
}
