using solution.DTOs;
using solution.Interface;
using solution.Repository;

namespace solution.Service;

public class PrescriptionMedicamentService : IPrescriptionMedicamentService
{
    public IPrescriptionMedicamentRepository _PrescriptionMedicamentRepository;

    public PrescriptionMedicamentService(IPrescriptionMedicamentRepository prescriptionMedicamentRepository)
    {
        _PrescriptionMedicamentRepository = prescriptionMedicamentRepository;
    }

    public async Task<int> CompletePrescriptionInsert(AddPrescriptionDTO addPrescriptionDto, int prescriptionId)
    {
        var result = 0;
        foreach (var each in addPrescriptionDto.Medicaments)
        {
            result = await _PrescriptionMedicamentRepository.CompletePrescriptionInsert(each, prescriptionId);
        }

        return result;
    }
}