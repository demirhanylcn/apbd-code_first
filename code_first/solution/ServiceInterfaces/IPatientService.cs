using Microsoft.AspNetCore.Mvc;
using solution.DTOs;

namespace solution.ServiceInterfaces;

public interface IPatientService
{
    public  Task<int> InsertNewPatient([FromBody] AddPrescriptionDTO addPrescriptionDto);

    public Task<bool> CheckPatientExist(int patientId);
    public Task<PatientDTO> GetPatientInformation(int patientId);


}