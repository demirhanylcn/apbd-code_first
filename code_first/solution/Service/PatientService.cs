using Microsoft.AspNetCore.Mvc;
using solution.DTOs;
using solution.Repository;
using solution.RepositoryInterfaces;
using solution.ServiceInterfaces;

namespace solution.Service;

public class PatientService : IPatientService
{
    public readonly IPatientRepository _PatientRepository;

    public PatientService(IPatientRepository patientRepository)
    {
        _PatientRepository = patientRepository;
    }
    public async Task<int> InsertNewPatient([FromBody] AddPrescriptionDTO addPrescriptionDto)
    {
        var result = await _PatientRepository.InsertNewPatient(addPrescriptionDto);
        return result;
    }

    public async Task<bool> CheckPatientExist(int patientId)
    {
        var result = await _PatientRepository.CheckPatientExist(patientId);
        return result;
    }

    public async Task<GetPatientDTO> GetPatientInformation(int patientId)
    {
       var result = await _PatientRepository.GetPatientInformation(patientId);
       return result;
    }
    



}