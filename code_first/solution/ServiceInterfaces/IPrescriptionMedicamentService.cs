using solution.DTOs;

namespace solution.ServiceInterfaces;

public interface IPrescriptionMedicamentService
{
    public Task<int> CompletePrescriptionInsert(AddPrescriptionDTO addPrescriptionDto, int prescriptionId);

}