using solution.DTOs;

namespace solution.ServiceInterfaces;

public interface IPrescriptionMedicamentService
{
    public Task<int> CompletePrescriptionInsert(AddPrescriptionDto addPrescriptionDto, int prescriptionId);

}