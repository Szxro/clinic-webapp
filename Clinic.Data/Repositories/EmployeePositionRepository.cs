using Clinic.Data.Common;
using Clinic.Data.Contracts;
using Clinic.Data.Entities;
using Clinic.Data.Persistence;

namespace Clinic.Data.Repositories;

public class EmployeePositionRepository 
    : GenericRepository<EmployeePosition>, IEmployeePositionRepository
{
    private readonly IUnitOfWork _unitOfWork;

    public EmployeePositionRepository(AppDbContext dbContext, IUnitOfWork unitOfWork) : base(dbContext)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task AddDefaultEmployeePositions()
    {
        ICollection<EmployeePosition> employeePositions = new HashSet<EmployeePosition>()
        {
            new EmployeePosition(){ PositionName = "ATS" },
            new EmployeePosition(){ PositionName = "ATS de Zona"},
            new EmployeePosition(){ PositionName = "Auxiliares de enfermeria"},
            new EmployeePosition(){ PositionName = "Celadores"},
            new EmployeePosition(){ PositionName = "Administractivos"}
        };

        AddRange(employeePositions);

        await _unitOfWork.SaveChangesAsync();
    }
}
