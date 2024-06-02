using Microsoft.AspNetCore.Mvc;
using solution.DTOs;

namespace solution.RepositoryInterfaces;

public interface IDoctorRepository
{
    public Task<bool> CheckDoctorExist([FromBody] AddPrescriptionDTO addPrescriptionDto);

}