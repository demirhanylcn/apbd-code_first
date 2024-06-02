using Microsoft.AspNetCore.Mvc;
using solution.DTOs;
using solution.Interface;
using solution.Repository;

namespace solution.Service;

public class DoctorService : IDoctorService
{
    public IDoctorRepository _DoctorRepository;
    public DoctorService(IDoctorRepository doctorRepository)
    {
        _DoctorRepository = doctorRepository;
    }
    public async Task<bool> CheckDoctorExist([FromBody] AddPrescriptionDTO addPrescriptionDto)
    {
       var result = await _DoctorRepository.CheckDoctorExist(addPrescriptionDto);
       return result;
    }

}