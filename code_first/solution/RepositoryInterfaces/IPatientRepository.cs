using Microsoft.AspNetCore.Mvc;
using solution.DTOs;

namespace solution.Repository;

public interface IPatientRepository
{
    public Task<bool> CheckPatientExist([FromBody] AddPrescriptionDTO addPrescriptionDto);
    public Task<int> InsertNewPatient([FromBody] AddPrescriptionDTO addPrescriptionDto);

}