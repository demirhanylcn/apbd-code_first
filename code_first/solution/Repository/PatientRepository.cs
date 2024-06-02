using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using solution.DTOs;

namespace solution.Repository;

public class PatientRepository : IPatientRepository
{
    public readonly AppDbContext _appDbContext;

    public PatientRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<bool> CheckPatientExist([FromBody] AddPrescriptionDTO addPrescriptionDto)
    {
        var patient =
            await _appDbContext.Patients.FirstOrDefaultAsync(p => p.IdPatient == addPrescriptionDto.PatientId);
        if (patient == null) return false;
        return true;
    }
    
}