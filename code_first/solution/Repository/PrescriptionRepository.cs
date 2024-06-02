using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using solution.DTOs;
using solution.Exception;
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
            await _appDbContext.Patients.FirstOrDefaultAsync(p => p.IdPatient == addPrescriptionDto.PatientId);
       await _appDbContext.Prescriptions.AddAsync(new Prescription
        {
            Date = addPrescriptionDto.PrescriptionDate,
            DoctorId = addPrescriptionDto.DoctorId,
            Doctor = doctor,
            DueDate = addPrescriptionDto.PrescriptionDueDate,
            PrescriptionId = addPrescriptionDto.PrescriptionId,
            Patient = patient,
            PatientId = addPrescriptionDto.PatientId,
            Prescription_Medicaments = new List<Prescription_Medicament>()
        });
        var result = _appDbContext.SaveChanges();
        return result;
    }


    
    
}