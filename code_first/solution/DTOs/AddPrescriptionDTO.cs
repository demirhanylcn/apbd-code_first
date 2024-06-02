using System.ComponentModel.DataAnnotations;

namespace solution.DTOs;

public class AddPrescriptionDTO
{
    
    [Required]
    public PatientDTO Patient { get; set; }
    [Required]
    public List<MedicamentDTO> Medicaments { get; set; }
    public DateTime PrescriptionDate { get; set; }
    public DateTime PrescriptionDueDate { get; set; }
    [Required]
    public int DoctorId { get; set; }
    
}