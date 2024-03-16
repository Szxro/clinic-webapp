using Clinic.Data.Common;
using Clinic.Data.Contracts;
using Clinic.Data.Entities;
using Clinic.Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Data.Repositories;

public class DoctorPositionRepository : GenericRepository<DoctorPosition>, IDoctorPositionRepository
{
    private readonly IUnitOfWork _unitOfWork;

    public DoctorPositionRepository(AppDbContext dbContext, IUnitOfWork unitOfWork) : base(dbContext)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task AddDefaultDoctorPosition()
    {
        ICollection<DoctorPosition> doctorPositions = new HashSet<DoctorPosition>()
        {
             new DoctorPosition() {PositionName = "Medico Titular" },
             new DoctorPosition() {PositionName = "Medico Interino" },
             new DoctorPosition() {PositionName = "Medico Sustituto"}
        };

        AddRange(doctorPositions);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<DoctorPosition?> GetDoctorPositionByPositionName(string positionName)
    {
        return await _dbContext.DoctorPosition
                               .Where(position => position.PositionName == positionName)
                               .FirstOrDefaultAsync();
    }
}
