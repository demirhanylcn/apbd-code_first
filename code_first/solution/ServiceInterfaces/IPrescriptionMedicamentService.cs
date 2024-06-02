using solution.DTOs;

namespace solution.Interface;

public interface IPrescriptionMedicamentService
{
    public Task<int> CompletePrescriptionInsert(AddPrescriptionDTO addPrescriptionDto, int prescriptionId);

}