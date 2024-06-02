using solution.Models;

namespace solution.DTOs;

public class GetPatientDTO
{
    public PatientDTO Patient { get; set; }
    public List<PrescriptionDTO> Prescriptions { get; set; }
    public List<MedicamentDTO> Medicaments { get; set; }
    public List<DoctorDTO> Doctors { get; set; }
    
}