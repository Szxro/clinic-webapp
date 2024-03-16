using Clinic.Data.Entities.Common.Primitives;
using MediatR;

namespace Clinic.Data.Contracts;

public interface ICommand : IRequest { }

public interface ICommand<out IResult> : IRequest<IResult> { }
