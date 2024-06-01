using Microsoft.AspNetCore.Mvc;
using solution.DTOs;
using solution.Models;

namespace solution.Controller;


[ApiController]
[Route("api/[controller]")]
public class HospitalController : ControllerBase
{

    [HttpPost]
    public IActionResult getPrescription([FromBody] AddPrescriptionDTO addPrescriptionDto)
    {
        return Ok(addPrescriptionDto.MedicationIds);
    }
}