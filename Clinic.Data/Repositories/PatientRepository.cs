using Clinic.Data.Common;
using Clinic.Data.Contracts;
using Clinic.Data.DTOs;
using Clinic.Data.Entities;
using Clinic.Data.Entities.Common.Primitives;
using Clinic.Data.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Clinic.Data.Repositories
{
    public class PatientRepository
                    : GenericRepository<Patient>,
                    IPatientRepository
    {
        public PatientRepository(AppDbContext dbContext) : base(dbContext) { }

        public async Task<List<DoctorResponse>?> GetAllDoctorsFromPatient(int patientId)
        {
            return await _dbContext.Patient
                .Include(x => x.DoctorPatients)
                .ThenInclude(dp => dp.Doctor)
                .Where(x => x.Id == patientId)
                .SelectMany(x => x.DoctorPatients.Select(dp => dp.Doctor))
                .Select(x =>
                    new DoctorResponse()
                    {
                        Name = x.Person.Name,
                        Telephone = x.Person.Telephone,
                        NIF = x.Person.NIF,
                        SocialNumber = x.Person.SocialNumber,
                    })
                .ToListAsync();
        }

        public async Task<Patient?> GetPatientById(int id)
        {
            return await _dbContext.Patient.Include(x => x.Person).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<PagedList<PatientResponse>> GetPatientsInformation(string? name, string? sortColumn, string? sortOrder, int page, int pageSize)
        {
            IQueryable<Patient> queryable = _dbContext.Patient.Include(x => x.Person);

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

            IQueryable<PatientResponse> patients = queryable
                .AsNoTracking()
                .Select(x =>
                            new PatientResponse()
                            {
                                PatientId = x.Id,
                                Name = x.Person.Name,
                                Telephone = x.Person.Telephone,
                                NIF = x.Person.NIF,
                                SocialNumber = x.Person.SocialNumber,
                            });

            return await MakePagedList(patients, page, pageSize);

            static Expression<Func<Patient, object>> GetSortProperty(string? sortColumn)
                => sortColumn?.ToLower() switch
                {
                    "name" => patient => patient.Person.Name,
                    "nif" => patient => patient.Person.NIF,
                    "socialnumber" => patient => patient.Person.SocialNumber,
                    "telephone" => patient => patient.Person.Telephone,
                    _ => patient => patient.Id
                };
        }

        public async Task<bool> IsDoctorAssociatedWithPatientAsync(int patientId, int doctorId)
        {
            return await _dbContext.DoctorPatient
                .AnyAsync(dp => dp.PatientId == patientId && dp.DoctorId == doctorId);
        }

        public async Task<bool> AddDoctorToPatientAsync(int patientId, int doctorId)
        {
            var doctorPatient = new DoctorPatient
            {
                PatientId = patientId,
                DoctorId = doctorId
            };

            _dbContext.DoctorPatient.Add(doctorPatient);

            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
