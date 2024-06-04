using Microsoft.AspNetCore.Mvc;
using solution.DTOs;

namespace solution.ServiceInterfaces;

public interface IPrescriptionService
{
    public Task<int> AddPrescription([FromBody] AddPrescriptionDto addPrescriptionDto);
    public void CheckDueDate([FromBody] AddPrescriptionDto addPrescriptionDto);


}