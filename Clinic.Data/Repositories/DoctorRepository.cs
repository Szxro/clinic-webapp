using Clinic.Data.Common;
using Clinic.Data.Contracts;
using Clinic.Data.Entities;
using Clinic.Data.Persistence;

namespace Clinic.Data.Repositories;

public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
{
    public DoctorRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public Task AddAsync(Doctor doctor)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Doctor doctor)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Doctor>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Doctor> GetByIdAsync(int doctorId)
    {
        throw new NotImplementedException();
    }

    public Task<Doctor> GetDoctorByIdAsync(int doctorId)
    {
        throw new NotImplementedException();
    }

    public Task UpdatAsync(Doctor doctor)
    {
        throw new NotImplementedException();
    }
}
