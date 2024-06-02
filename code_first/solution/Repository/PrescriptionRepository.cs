using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using solution.DTOs;
using solution.Models;

namespace solution.Repository;

public class PrescriptionRepository : IPrescriptionRepository
{

    public readonly AppDbContext _appDbContext;
    public PrescriptionRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<int> AddPrescription([FromBody] AddPrescriptionDTO addPrescriptionDto)
    {

        var doctor =
            await _appDbContext.Doctors.FirstOrDefaultAsync(d => d.IdDoctor == addPrescriptionDto.DoctorId);
        var patient =
            await _appDbContext.Patients.FirstOrDefaultAsync(p => p.IdPatient == addPrescriptionDto.Patient.IdPatient);
        var prescription =
            new Prescription
            {
                Date = addPrescriptionDto.PrescriptionDate,
                DoctorId = addPrescriptionDto.DoctorId,
                Doctor = doctor,
                DueDate = addPrescriptionDto.PrescriptionDueDate,
                Patient = patient,
                PatientId = addPrescriptionDto.Patient.IdPatient,
                Prescription_Medicaments = new List<Prescription_Medicament>()
            };
       await _appDbContext.Prescriptions.AddAsync(prescription);
       await _appDbContext.SaveChangesAsync();
       return prescription.PrescriptionId;
    }


    
    
}