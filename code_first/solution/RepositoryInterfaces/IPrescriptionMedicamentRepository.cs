using solution.DTOs;

namespace solution.RepositoryInterfaces;

public interface IPrescriptionMedicamentRepository
{
    public Task<int> CompletePrescriptionInsert(MedicamentDTO medicamentDto, int prescriptionId);

}