using Clinic.Domain.Common;

namespace Clinic.Domain.Entities;

public class VacationPeriodStatus : AuditableEntity
{
    public VacationPeriodStatus()
    {
        PersonVacationPeriods = new HashSet<PersonVacationPeriod>();
    }

    public string StatusName { get; set; } = string.Empty;

    public ICollection<PersonVacationPeriod> PersonVacationPeriods { get; set; }
}
