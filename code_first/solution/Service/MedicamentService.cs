using solution.DTOs;
using solution.Exception;
using solution.Repository;
using solution.RepositoryInterfaces;
using solution.ServiceInterfaces;

namespace solution.Service;

public class MedicamentService : IMedicamentService
{
    public readonly IMedicamentRepository _MedicamentRepository;

    public MedicamentService(IMedicamentRepository medicamentRepository)
    {
        _MedicamentRepository = medicamentRepository;
    }

    public async void CheckMedicamentExists(AddPrescriptionDTO addPrescriptionDto)
    {
        foreach (var medicament in addPrescriptionDto.Medicaments)
        {
          await _MedicamentRepository.CheckMedicamentExists(medicament.IdMedicament);
        }
    }

    public void CheckMedicamentLowerThan10(AddPrescriptionDTO addPrescriptionDto)
    {
        var result = addPrescriptionDto.Medicaments.Count >= 10;
        if (result!) throw new MedicamentGreaterThan10Exception();
    }

}