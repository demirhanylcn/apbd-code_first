using Microsoft.AspNetCore.Mvc;
using solution.DTOs;
using solution.Exception;
using solution.Models;
using solution.Repository;
using solution.Service;

namespace solution.Controller;


[ApiController]
[Route("api/[controller]")]
public class HospitalController : ControllerBase
{

    public IPrescriptionService _PrescriptionService;

    public HospitalController(IPrescriptionService prescriptionService)
    {
        _PrescriptionService = prescriptionService;
    }
    [HttpPost]
    public IActionResult getPrescription([FromBody] AddPrescriptionDTO addPrescriptionDto)
    {
        try
        {
            return Ok(addPrescriptionDto.MedicationIds);
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
}