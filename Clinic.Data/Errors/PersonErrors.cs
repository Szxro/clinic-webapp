using Clinic.Data.Entities.Common.Primitives;

namespace Clinic.Data.Errors;

public static class PersonErrors
{
    public static readonly Error NifNotUnique 
        = Error.Conflit("Person.NifNotUnique","The NIF is already register");

    public static readonly Error SocialNumberNotUnique
        = Error.Conflit("Person.SocialNumber", "The Social Number is already register");
}
