using Clinic.Data.Contracts;
using Clinic.Data.Entities;
using Clinic.Data.Entities.Common.Primitives;
using Clinic.Data.Errors;
using System.Threading;
using System.Threading.Tasks;

namespace Clinic.Business.Employees.Commands.DeleteEmployee
{
    public record DeleteEmployeeCommand(string employeeName,
                                        int employeeNumber) : ICommand<Result>;

    public class DeleteEmployeeCommandHandler : ICommandHandler<DeleteEmployeeCommand, Result>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteEmployeeCommandHandler(
            IEmployeeRepository employeeRepository,
            IUnitOfWork unitOfWork)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee? foundEmployee = await _employeeRepository.GetEmployeeByNameAndEmployeeNumber(request.employeeName, request.employeeNumber);

            if (foundEmployee is null)
            {
                return Result.Failure(EmployeeErrors.NotFoundByName(request.employeeName));
            }

            _employeeRepository.Remove(foundEmployee);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}

