using Microsoft.AspNetCore.Mvc;
using solution.DTOs;

namespace solution.Service;

public interface IPrescriptionService
{
    public Task<int> AddPrescription([FromBody] AddPrescriptionDTO addPrescriptionDto);
    public void CheckDueDate([FromBody] AddPrescriptionDTO addPrescriptionDto);
    public void CheckPrescriptionExists(List<PrescriptionDTO>? prescriptions, int clientId);


}