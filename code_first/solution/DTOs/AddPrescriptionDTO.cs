using System.ComponentModel.DataAnnotations;

namespace solution.DTOs;

public class AddPrescriptionDTO
{
    [Required]
    public int PrescriptionId { get; set; }
    [Required]
    public int DoctorId { get; set; }
    [Required]
    public List<int> MedicationIds { get; set; }
    public DateTime PrescriptionDate { get; set; }
    public DateTime PrescriptionDueDate { get; set; }
    public int MedicamentDose { get; set; }
    public string MedicamentDetails{ get; set; }
    [Required]
    public int PatientId { get; set; }
    public string PatientFirstName { get; set; }
    public string PatientLastName { get; set; }
    public DateTime PatientBirthDate { get; set;  }
    
}