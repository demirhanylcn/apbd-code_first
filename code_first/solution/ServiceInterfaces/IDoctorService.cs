using Microsoft.AspNetCore.Mvc;
using solution.DTOs;

namespace solution.ServiceInterfaces;

public interface IDoctorService
{
    public void CheckDoctorExist([FromBody] AddPrescriptionDTO addPrescriptionDto);

}