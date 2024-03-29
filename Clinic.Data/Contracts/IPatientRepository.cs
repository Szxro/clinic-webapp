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

        Task<PagedList<PatientResponse>> GetPatientsInformation(string? name, string? sortColumn, string? sortOrder, int page, int pageSize);

        Task<Patient?> GetById(int Id, List<string>? includes = null);

        Task<List<DoctorResponse>?> GetAllDoctorsFromPatient(int patientId);
        Task<bool> IsDoctorAssociatedWithPatientAsync(int patientId, int doctorId);
        Task<bool> AddDoctorToPatientAsync(int patientId, int doctorId);
    }
}
