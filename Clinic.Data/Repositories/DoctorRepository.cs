using Clinic.Data.Common;
using Clinic.Data.Contracts;
using Clinic.Data.Entities;
using Clinic.Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Data.Repositories;

public class DoctorRepository : IDoctorRepository
{
    private readonly AppDbContext _dbContext;

    public DoctorRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Doctor?> GetByIdAsync(int id)
    {
        return await _dbContext.Doctor.FindAsync(id);
    }

    public async Task<IEnumerable<Doctor>> GetAllAsync()
    {
        return await _dbContext.Doctor.ToListAsync();
    }

    public async Task AddAsync(Doctor doctor)
    {
        await _dbContext.Doctor.AddAsync(doctor);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Doctor doctor)
    {
        _dbContext.Doctor.Update(doctor);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Doctor doctor)
    {
        _dbContext.Doctor.Remove(doctor);
        await _dbContext.SaveChangesAsync();
    }
}
