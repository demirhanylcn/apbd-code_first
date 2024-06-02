using Microsoft.EntityFrameworkCore;
using solution.DTOs;
using solution.Models;

namespace solution.Repository;

public class PrescriptionMedicamentRepository : IPrescriptionMedicamentRepository
{
    public readonly AppDbContext _appDbConext;

    public PrescriptionMedicamentRepository(AppDbContext appDbContext)
    {
        _appDbConext = appDbContext;
    }


    public async Task<int> AddRecord(PrescriptionMedicamentDTO prescriptionMedicamentDto)
    {

        var medicament =
            await _appDbConext.Medicaments.FirstOrDefaultAsync(m =>
                m.IdMedicament == prescriptionMedicamentDto.MedicamentId);
        var prescription =
            await _appDbConext.Prescriptions
                .FirstOrDefaultAsync(p => p.PrescriptionId == prescriptionMedicamentDto.PrescriptionId);
        await _appDbConext.PrescriptionMedicaments
            .AddAsync(new Prescription_Medicament
            {
                Details = prescriptionMedicamentDto.Details,
                Medicament = medicament,
                Dose = prescriptionMedicamentDto.Dose,
                MedicamentId = prescriptionMedicamentDto.MedicamentId,
                Prescription = prescription,
                PrescriptionId = prescriptionMedicamentDto.PrescriptionId
            });

        var result = await _appDbConext.SaveChangesAsync();
        return result;

    }
}