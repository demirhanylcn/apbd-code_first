namespace solution.DTOs;

public class AddPrescriptionDTO
{
    public int PrescriptionId { get; set; }
    public int DoctorId { get; set; }
    public List<int> MedicationIds { get; set; }
    public DateTime PrescriptionDate { get; set; }
    public DateTime PrescriptionDueDate { get; set; }
    public int MedicamentDose { get; set; }
    public string MedicamentDescription { get; set; }
    public int PatientId { get; set; }
    public string PatientFirstName { get; set; }
    public string PatientLastName { get; set; }
    public DateTime PatientBirthDate { get; set;  }
    
}