using Microsoft.AspNetCore.Mvc;
using solution.DTOs;

namespace solution.RepositoryInterfaces;

public interface IPrescriptionRepository
{
    public Task<int> AddPrescription([FromBody] AddPrescriptionDto addPrescriptionDto);
}