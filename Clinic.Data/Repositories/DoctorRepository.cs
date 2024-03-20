using Clinic.Data.Common;
using Clinic.Data.Contracts;
using Clinic.Data.Entities;
using Clinic.Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Data.Repositories;

public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
{
    private readonly IUnitOfWork _unitOfWork;

    public DoctorRepository(AppDbContext dbContext, IUnitOfWork unitOfWork) : base(dbContext)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Doctor?> GetByIdAsync(int id)
    {
        return await GetById(id);
    }

    public async Task<IEnumerable<Doctor>> GetAllAsync()
    {
        return await _dbContext.Doctor.ToListAsync();
    }

    public async Task AddAsync(Doctor doctor)
    {
        Add(doctor);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(Doctor doctor)
    {
        _dbContext.Update(doctor);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(Doctor doctor)
    {
        _dbContext.Remove(doctor);
        await _unitOfWork.SaveChangesAsync();
    }
}
