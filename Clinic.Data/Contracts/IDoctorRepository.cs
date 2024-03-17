using Clinic.Data.Entities;

namespace Clinic.Data.Contracts;

public interface IDoctorRepository
{
    void Add(Doctor newDoctor);
    Task<Doctor> GetDoctorById(int doctorId);
    void Update(Doctor doctor);
}
