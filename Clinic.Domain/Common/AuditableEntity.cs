namespace Clinic.Domain.Common;

public abstract class AuditableEntity : BaseEntity
{
    public DateTime? CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set;}
}
