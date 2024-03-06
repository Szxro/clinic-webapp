using Clinic.Domain.Common;

namespace Clinic.Domain.Entities;

public class Person : AuditableEntity
{
    public string Name { get; set; } = string.Empty;

    public string Telephone { get; set; } = string.Empty;

    public string NIF { get; set; } = string.Empty;

    public int SocialNumber { get; set; }
}
