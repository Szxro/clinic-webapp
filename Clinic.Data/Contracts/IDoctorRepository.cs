using Clinic.Data.Entities;

namespace Clinic.Data.Contracts;

public interface IDoctorRepository
{
    void Add(Doctor newDoctor);
}
