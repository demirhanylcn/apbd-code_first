using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using solution.DTOs;
using solution.Models;

namespace solution.Repository;

public class PatientRepository : IPatientRepository
{
    public readonly AppDbContext _appDbContext;

    public PatientRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<bool> CheckPatientExist(int patientId)
    {
        var patient =
            await _appDbContext.Patients.FirstOrDefaultAsync(p => p.IdPatient == patientId);
        if (patient == null) return false;
        return true;
    }

    public async Task<int> InsertNewPatient([FromBody] AddPrescriptionDTO addPrescriptionDto)
    {
        var patient =
            new Patient
            {
                BirthDate = addPrescriptionDto.Patient.BirthDate,
                FirstName = addPrescriptionDto.Patient.FirstName,
                IdPatient = addPrescriptionDto.Patient.IdPatient,
                LastName = addPrescriptionDto.Patient.LastName,
                Prescriptions = new List<Prescription>()
            };
        await _appDbContext.Patients.AddAsync(patient);
        var result = await _appDbContext.SaveChangesAsync();
        return result;
    }

    public async Task<PatientDTO> GetPatientInformation(int patientId)
    {
        var patient = await _appDbContext.Patients.FirstOrDefaultAsync(p => p.IdPatient == patientId);
        var patientInformation = new PatientDTO
        {
            BirthDate = patient.BirthDate,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            IdPatient = patientId
        };

        return patientInformation;
    }
    
}