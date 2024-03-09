using Clinic.Data.Common;

namespace Clinic.Data.Entities;

public class Person : AuditableEntity
{
    public Person()
    {
        PersonAddresses = new HashSet<PersonAddress>();
        PersonVacationPeriods = new HashSet<PersonVacationPeriod>();
    }

    public string Name { get; set; } = string.Empty;

    public string Telephone { get; set; } = string.Empty;

    public string NIF { get; set; } = string.Empty; 

    public int SocialNumber { get; set; }  

    public Doctor Doctor { get; set; } = new(); // One to One

    public Employee Employee { get; set; } = new();

    public Patient Patient { get; set; } = new();

    public ICollection<PersonAddress> PersonAddresses { get; set; } // One to Many

    public ICollection<PersonVacationPeriod> PersonVacationPeriods { get; set; }
}
