using solution.DTOs;

namespace solution.Repository;

public interface IPrescriptionMedicamentRepository
{
    public Task<int> CompletePrescriptionInsert(MedicamentDTO medicamentDto, int prescriptionId);

}