using Microsoft.AspNetCore.Mvc;
using solution.DTOs;
using solution.Exception;
using solution.Interface;
using solution.Service;
using solution.ServiceInterfaces;

namespace solution.Controller;


[ApiController]
[Route("api/[controller]")]
public class HospitalController : ControllerBase
{

    public IPrescriptionService _PrescriptionService;
    public IDoctorService _DoctorService;
    public IMedicamentService _MedicamentService;
    public IPrescriptionMedicamentService _PrescriptionMedicamentService;
    public IPatientService _PatientService;
    

    public HospitalController(IPrescriptionService prescriptionService,
        IPatientService patientService,
        IMedicamentService medicamentService,
        IDoctorService doctorService,
        IPrescriptionMedicamentService prescriptionMedicamentService)
    {
        _PrescriptionService = prescriptionService;
        _MedicamentService = medicamentService;
        _DoctorService = doctorService;
        _PrescriptionMedicamentService = prescriptionMedicamentService;
        _PatientService = patientService;
    }
    [HttpPost]
    public async Task<IActionResult> AddPrescription([FromBody] AddPrescriptionDTO addPrescriptionDto)
    {
        try
        {
            var patientExists = await _PatientService.CheckPatientExist(addPrescriptionDto.Patient.IdPatient);
            if (patientExists!) await _PatientService.InsertNewPatient(addPrescriptionDto);
             _MedicamentService.CheckMedicamentExists(addPrescriptionDto);
             _MedicamentService.CheckMedicamentLowerThan10(addPrescriptionDto);
             _PrescriptionService.CheckDueDate(addPrescriptionDto);
            var prescriptionId = await _PrescriptionService.AddPrescription(addPrescriptionDto);
             var result = await _PrescriptionMedicamentService.CompletePrescriptionInsert(addPrescriptionDto, prescriptionId);
            return Ok(result);
        }
        catch (DoctorDoesntExistsException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (MedicamentDoesntExistsException ex)
        {
            return BadRequest(ex.Message);
        }
        
    }

    [HttpGet]
    public async Task<IActionResult> GetPatientInformation(int patientId)
    {

        try
        {
            var patientExists= await _PatientService.CheckPatientExist(patientId);
            if (patientExists!) throw new PatientDoesntExistsException(patientId);
            return Ok();
        }
        catch (PatientDoesntExistsException ex)
        {
            return BadRequest(ex.Message);
        }
      
    }
}