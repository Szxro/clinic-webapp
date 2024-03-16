using Clinic.Data.Entities.Common.Primitives;

namespace Clinic.Business.Common.Exceptions;

public class ValidationException : Exception
{
    public ValidationException()
        : base("One or more validation failures have occurred.")
    {
        Errors = new Dictionary<string, Error[]>();       
    }
    public IDictionary<string, Error[]> Errors { get; }

    public ValidationException(Error[] validationErrors)
        : this()
    {
        Errors = new Dictionary<string, Error[]>()
        {
            {"validationErrors", validationErrors}
        };
    }
}
