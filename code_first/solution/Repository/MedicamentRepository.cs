using Microsoft.EntityFrameworkCore;

namespace solution.Repository;

public class MedicamentRepository : IMedicamentRepository
{
    public readonly AppDbContext _appDbContext;

    public MedicamentRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<bool> CheckMedicamentExists(int medicamentId)
    {
        var medicament = await _appDbContext.Medicaments.FirstOrDefaultAsync(m => m.IdMedicament == medicamentId);
        if (medicament == null) throw new MedicamentDoesntExistsException(medicamentId);
    }
}