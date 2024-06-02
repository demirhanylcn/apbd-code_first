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


    public async Task<int> CompletePrescriptionInsert(MedicamentDTO medicamentDto, int prescriptionId)
    {

        var medicament =
            await _appDbConext.Medicaments.FirstOrDefaultAsync(m =>
                m.IdMedicament == medicamentDto.IdMedicament);
        var prescription =
            await _appDbConext.Prescriptions
                .FirstOrDefaultAsync(p => p.PrescriptionId == prescriptionId);
        await _appDbConext.PrescriptionMedicaments
            .AddAsync(new Prescription_Medicament
            {
                Details = medicamentDto.Description,
                Medicament = medicament,
                Dose = medicamentDto.Dose,
                MedicamentId = medicamentDto.IdMedicament,
                Prescription = prescription,
                PrescriptionId = prescriptionId
            });

        var result = await _appDbConext.SaveChangesAsync();
        return result;

    }
}