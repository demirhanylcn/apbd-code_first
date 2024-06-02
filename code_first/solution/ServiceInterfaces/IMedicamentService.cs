using solution.DTOs;

namespace solution.ServiceInterfaces;

public interface IMedicamentService
{
    public void CheckMedicamentExists(AddPrescriptionDTO addPrescriptionDto);

    public void CheckMedicamentLowerThan10(AddPrescriptionDTO addPrescriptionDto);
}