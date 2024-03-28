using Clinic.Data.Common;
using Clinic.Data.Contracts;
using Clinic.Data.DTOs;
using Clinic.Data.Entities;
using Clinic.Data.Entities.Common.Primitives;
using Clinic.Data.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Clinic.Data.Repositories;

public class DoctorRepository 
    : GenericRepository<Doctorresponse>,
    IDoctorRepository
{
    public DoctorRepository(AppDbContext dbContext) : base(dbContext) { }

    public async Task<Doctorresponse?> GetDoctorByNameAndCollegueNumber(string name, int collegueNumber)
    {
        return await _dbContext.Doctor.Include(x => x.Person)
                                      .Where(x => x.Person.Name == name && x.CollegueNumber == collegueNumber)
                                      .FirstOrDefaultAsync();
    }

    public async Task<bool> IsCollegueNumberNotAvaliable(int collegueNumber)
    {
        return await _dbContext.Doctor.AsNoTracking().AnyAsync(x => x.CollegueNumber == collegueNumber);
    }
    public async Task<Doctorresponse?> GetDoctorPersonById(int id)
    {
        return await _dbContext.Doctor.Include(x => x.Person).Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<PagedList<DoctorResponse>> GetDoctorsInformation(string? name, string? sortColumn, string? sortOrder, int page, int pageSize)
    {
        IQueryable<Doctorresponse> queryable = _dbContext.Doctor;

        if (!string.IsNullOrWhiteSpace(name))
        {
            queryable = queryable.Where(x => x.Person.Name.Contains(name));
        }

        if (sortOrder?.ToLower() == "desc")
        {
            queryable = queryable.OrderByDescending(GetSortProperty(sortColumn));
        }

        if (sortOrder?.ToLower() == "asc")
        {
            queryable = queryable.OrderBy(GetSortProperty(sortColumn));
        }

        IQueryable<DoctorResponse> doctors = queryable
            .AsNoTracking()
            .Include(x => x.Person)
            .Include(x => x.DoctorPosition)
            .Select(x =>
            new DoctorResponse()
            {
                Name = x.Person.Name,
                Telephone = x.Person.Telephone,
                NIF = x.Person.NIF,
                SocialNumber = x.Person.SocialNumber,
                CollegueNumber = x.CollegueNumber,
                StartDate = x.StartDate.ToString("yyyy-MM-dd"),
                EndDate = x.EndDate.ToString("yyyy-MM-dd"), 
                PositionName = x.DoctorPosition.PositionName
            });

        return await MakePagedList(doctors, page, pageSize);

        static Expression<Func<Doctorresponse, object>> GetSortProperty(string? sortColumn)
            => sortColumn?.ToLower() switch
            {
                "colleguenumber" => doctor => doctor.CollegueNumber,
                "name" => doctor => doctor.Person.Name,
                "nif" => doctor => doctor.Person.NIF,
                "socialnumber" => doctor => doctor.Person.SocialNumber,
                "telephone" => doctor => doctor.Person.Telephone,
                _ => doctor => doctor.Id
            };
    }
}
