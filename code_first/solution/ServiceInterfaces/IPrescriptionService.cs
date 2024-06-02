using Microsoft.AspNetCore.Mvc;
using solution.DTOs;

namespace solution.ServiceInterfaces;

public interface IPrescriptionService
{
    public Task<int> AddPrescription([FromBody] AddPrescriptionDTO addPrescriptionDto);
    public void CheckDueDate([FromBody] AddPrescriptionDTO addPrescriptionDto);


}