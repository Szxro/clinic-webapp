namespace Clinic.Data.Contracts;

using MediatR;

public interface IQuery<out IResult> : IRequest<IResult> { }


