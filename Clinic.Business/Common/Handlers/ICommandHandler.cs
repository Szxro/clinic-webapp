using Clinic.Data.Contracts;
using MediatR;

namespace Clinic.Business.Contracts;

public interface ICommandHandler<in TRequest, IResult> : IRequestHandler<TRequest, IResult>
    where TRequest : ICommand<IResult>
{
}

public interface ICommandHandler<in TRequest> : IRequestHandler<TRequest>
    where TRequest : ICommand
{ 
}
