using Clinic.Data.Contracts;
using MediatR;

namespace Clinic.Business.Contracts;

public interface IQueryHandler<in TRequest, IResult> : IRequestHandler<TRequest,IResult>
    where TRequest : IQuery<IResult>
{
}
