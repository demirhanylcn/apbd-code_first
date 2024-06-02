using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using solution.DTOs;
using solution.Models;
using solution.RepositoryInterfaces;

namespace solution.Repository;

public class PatientRepository : IPatientRepository
{
    public readonly AppDbContext AppDbContext;

    public PatientRepository(AppDbContext appDbContext)
    {
        AppDbContext = appDbContext;
    }
    public async Task<bool> CheckPatientExist(int patientId)
    {
        var patient =
            await AppDbContext.Patients.FirstOrDefaultAsync(p => p.IdPatient == patientId);
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
        await AppDbContext.Patients.AddAsync(patient);
        var result = await AppDbContext.SaveChangesAsync();
        return result;
    }

    public async Task<GetPatientDTO> GetPatientInformation(int patientId)
    {
        var patient = await AppDbContext.Patients
            .Include(p => p.Prescriptions)
            .ThenInclude(pr => pr.Prescription_Medicaments)
            .ThenInclude(pm => pm.Medicament).ThenInclude(medicament => medicament.PrescriptionMedicaments)
            .Include(p => p.Prescriptions)
            .ThenInclude(pr => pr.Doctor)
            .FirstOrDefaultAsync(p => p.IdPatient == patientId);
        
        var result = new GetPatientDTO
        {
            Patient = new PatientDTO
            {
                IdPatient = patientId,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                BirthDate = patient.BirthDate
            },
            Prescriptions = patient.Prescriptions.Select(pr => new PrescriptionDTO
            {
                PrescriptionId = pr.Id,
                Date = pr.Date,
                DueDate = pr.DueDate,
            }).ToList(),
            Medicaments = patient.Prescriptions
                .SelectMany(pr => pr.Prescription_Medicaments)
                .Select(pm => pm.Medicament)
                .Select(m => new MedicamentDTO
                {
                    IdMedicament = m.IdMedicament,
                    Name = m.Name,
                    Description = m.Description,
                    PrescriptionMedicaments = m.PrescriptionMedicaments.Select(pm => new PrescriptionMedicamentDTO
                    {
                        Details = pm.Details,
                        Dose = pm.Dose
                    }).ToList()
                }).ToList(),
            Doctors = patient.Prescriptions
                .Select(pr => pr.Doctor)
                .Distinct()
                .Select(d => new DoctorDTO
                {
                    IdDoctor = d.IdDoctor,
                    FirstName = d.FirstName,
                    LastName = d.LastName
                }).ToList()
        };

        return result;
    }

    
}