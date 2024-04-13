using Clinic.Business.Employees.Commands.CreateEmployee;
using Clinic.Data.Contracts;
using Clinic.Data.Entities.Common.Primitives;

namespace Clinic.Business.EmployeePositions.Commands.CreateEmployeePosition;
public record CreateEmployeePositionCommand(string positionName) : ICommand<Result> { }

    public class CreateEmployeePositionCommandHandler : ICommandHandler<CreateEmployeeCommand, Result>
    {
        private readonly IEmployeePositionRepository _employeePositionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateEmployeePositionCommandHandler(IEmployeePositionRepository employeePositionRepository,
                                                    IUnitOfWork unitOfWork)
        {
            _employeePositionRepository = employeePositionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            
            

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }




