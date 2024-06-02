using Microsoft.AspNetCore.Mvc;
using solution.DTOs;

namespace solution.Interface;

public interface IDoctorService
{
    public Task<bool> CheckDoctorExist([FromBody] AddPrescriptionDTO addPrescriptionDto);

}