using Microsoft.AspNetCore.Mvc;
using solution.DTOs;

namespace solution.Interface;

public interface IPatientService
{
    public  Task<int> InsertNewPatient([FromBody] AddPrescriptionDTO addPrescriptionDto);

    public Task<bool> CheckPatientExist([FromBody] AddPrescriptionDTO addPrescriptionDto);

}