using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using solution.DTOs;
using solution.Exception;

namespace solution.Repository;

public class DoctorRepository : IDoctorRepository
{
    public readonly AppDbContext _appDbContext;

    public DoctorRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public async Task<bool> CheckDoctorExist([FromBody] AddPrescriptionDTO addPrescriptionDto)
    {
        var doctor =
            await _appDbContext.Doctors.FirstOrDefaultAsync(d => d.IdDoctor == addPrescriptionDto.DoctorId);
        if (doctor == null) throw new DoctorDoesntExistsException(addPrescriptionDto.DoctorId);
        return true;
    }

}