using Clinic.Data.Common;
using Clinic.Data.Contracts;
using Clinic.Data.Entities;
using Clinic.Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Data.Repositories;

public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly AppDbContext _dbContext;

    public DoctorRepository(AppDbContext dbContext, IUnitOfWork unitOfWork): base(dbContext)
    {
        _dbContext = dbContext;
        _unitOfWork = unitOfWork;
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
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(Doctor doctor)
    {
        _dbContext.Doctor.Update(doctor);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(Doctor doctor)
    {
        _dbContext.Doctor.Remove(doctor);
        await _unitOfWork.SaveChangesAsync();
    }
}
