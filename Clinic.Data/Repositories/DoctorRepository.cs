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

    public Task<Doctor> GetDoctorById(int doctorId)
    {
        throw new NotImplementedException();
    }

    public void Update(Doctor doctor)
    {
        throw new NotImplementedException();
    }
}
