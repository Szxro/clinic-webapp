using Clinic.Data.DTOs;
using Clinic.Data.Entities;
using Clinic.Data.Entities.Common.Primitives;

namespace Clinic.Data.Contracts
{
    public interface IPatientRepository
    {
        void Add(Patient patient);

        void Remove(Patient patient);

        void Update(Patient patient);

        Task<Patient?> GetPatientById(int id);

        Task<PagedList<PatientDto>> GetPatientsInformation(string? name, string? sortColumn, string? sortOrder, int page, int pageSize);
        Task<Patient> GetById(int patientId);
    }
}
