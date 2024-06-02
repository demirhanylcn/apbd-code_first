using Microsoft.AspNetCore.Mvc;
using solution.DTOs;
using solution.Repository;
using solution.RepositoryInterfaces;
using solution.ServiceInterfaces;

namespace solution.Service;

public class DoctorService : IDoctorService
{
    public readonly IDoctorRepository _DoctorRepository;
    public DoctorService(IDoctorRepository doctorRepository)
    {
        _DoctorRepository = doctorRepository;
    }
    public void CheckDoctorExist([FromBody] AddPrescriptionDTO addPrescriptionDto)
    {
        _DoctorRepository.CheckDoctorExist(addPrescriptionDto);
       
    }

}