using Clinic.Data.Entities;

namespace Clinic.Data.Contracts;

public interface IDoctorPositionRepository
{
    Task AddDefaultDoctorPosition();

    Task<DoctorPosition?> GetDoctorPositionByPositionName(string positionName);
}
