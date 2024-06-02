using Microsoft.AspNetCore.Mvc;
using solution.DTOs;

namespace solution.Repository;

public interface IPrescriptionRepository
{
    public Task<int> AddPrescription([FromBody] AddPrescriptionDTO addPrescriptionDto);

}