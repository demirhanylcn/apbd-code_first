using Microsoft.AspNetCore.Mvc;
using solution.DTOs;

namespace solution.RepositoryInterfaces;

public interface IPatientRepository
{
    public Task<bool> CheckPatientExist(int patientId);
    public Task<int> InsertNewPatient([FromBody] AddPrescriptionDto addPrescriptionDto);
    public  Task<PatientDto> GetPatientInformation(int patientId);


}