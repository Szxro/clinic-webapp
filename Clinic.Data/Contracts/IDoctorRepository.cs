using Clinic.Data.Entities;

namespace Clinic.Data.Contracts;

public interface IDoctorRepository
{
    Task AddAsync(Doctor doctor);
    Task<IEnumerable<Doctor>> GetAllAsync();
    Task DeleteAsync(Doctor doctor);
    Task<Doctor> GetByIdAsync(int doctorId);
    Task<Doctor> GetDoctorByIdAsync(int doctorId);
    Task UpdatAsync(Doctor doctor);
}
