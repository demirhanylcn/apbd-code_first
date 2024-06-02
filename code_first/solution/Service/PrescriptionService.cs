using Microsoft.AspNetCore.Mvc;
using solution.DTOs;
using solution.Exception;
using solution.Repository;

namespace solution.Service;

public class PrescriptionService : IPrescriptionService
{
    public IPrescriptionRepository _PrescriptionRepository;

    public PrescriptionService(IPrescriptionRepository prescriptionRepository)
    {
        _PrescriptionRepository = prescriptionRepository;
    }
    public async Task<int> AddPrescription([FromBody] AddPrescriptionDTO addPrescriptionDto)
    {
        var result = await _PrescriptionRepository.AddPrescription(addPrescriptionDto);
        return result;
    }

    public void CheckDueDate([FromBody] AddPrescriptionDTO addPrescriptionDto)
    {
        var dueDate = addPrescriptionDto.PrescriptionDueDate;
        var date = addPrescriptionDto.PrescriptionDate;
        var result = dueDate >= date;
        if (result!) throw new DueDateSmallerThanDateException(dueDate,date);
    }
}