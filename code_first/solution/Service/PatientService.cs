using Microsoft.AspNetCore.Mvc;
using solution.DTOs;
using solution.Interface;
using solution.Repository;

namespace solution.Service;

public class PatientService : IPatientService
{
    public IPatientRepository _PatientRepository;

    public PatientService(IPatientRepository patientRepository)
    {
        _PatientRepository = patientRepository;
    }
    public async Task<int> InsertNewPatient([FromBody] AddPrescriptionDTO addPrescriptionDto)
    {
        var result = await _PatientRepository.InsertNewPatient(addPrescriptionDto);
        return result;
    }

    public async Task<bool> CheckPatientExist([FromBody] AddPrescriptionDTO addPrescriptionDto)
    {
        var result = await _PatientRepository.CheckPatientExist(addPrescriptionDto);
        return result;
    }


}