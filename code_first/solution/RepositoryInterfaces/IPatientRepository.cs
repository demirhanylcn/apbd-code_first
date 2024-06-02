using Microsoft.AspNetCore.Mvc;
using solution.DTOs;

namespace solution.Repository;

public interface IPatientRepository
{
    public Task<bool> CheckPatientExist(int patientId);
    public Task<int> InsertNewPatient([FromBody] AddPrescriptionDTO addPrescriptionDto);
    public Task<PatientDTO> GetPatientInformation(int patientId);


}