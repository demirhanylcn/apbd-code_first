using Microsoft.AspNetCore.Mvc;
using solution.DTOs;
using solution.Repository;

namespace solution.Service;

public class PrescriptionService : IPrescriptionService
{
    public IPrescriptionRepository _PrescriptionRepository;

    public PrescriptionService(IPrescriptionRepository prescriptionRepository)
    {
        _PrescriptionRepository = prescriptionRepository;
    }
    public Task<int> AddPrescription([FromBody] AddPrescriptionDTO addPrescriptionDto)
    {
        
    }
}