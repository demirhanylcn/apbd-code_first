using Microsoft.EntityFrameworkCore;
using solution.DTOs;
using solution.Models;
using solution.RepositoryInterfaces;

namespace solution.Repository;

public class PrescriptionMedicamentRepository : IPrescriptionMedicamentRepository
{
    public readonly AppDbContext AppDbConext;

    public PrescriptionMedicamentRepository(AppDbContext appDbContext)
    {
        AppDbConext = appDbContext;
    }


    public async Task<int> CompletePrescriptionInsert(MedicamentDTO medicamentDto, int prescriptionId)
    {

        var medicament =
            await AppDbConext.Medicaments.FirstOrDefaultAsync(m =>
                m.IdMedicament == medicamentDto.IdMedicament);
        var prescription =
            await AppDbConext.Prescriptions
                .FirstOrDefaultAsync(p => p.Id == prescriptionId);
        await AppDbConext.PrescriptionMedicaments
            .AddAsync(new PrescriptionMedicament
            {
                Details = medicamentDto.Description,
                Medicament = medicament,
                Dose = medicamentDto.Dose,
                MedicamentId = medicamentDto.IdMedicament,
                Prescription = prescription,
                PrescriptionId = prescriptionId
            });

        var result = await AppDbConext.SaveChangesAsync();
        return result;

    }
}