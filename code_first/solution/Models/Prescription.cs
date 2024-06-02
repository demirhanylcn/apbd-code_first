using System.ComponentModel.DataAnnotations;

namespace solution.Models;



public class Prescription
{
    public int PrescriptionId { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }

    public int PatientId { get; set; }
    public Patient Patient { get; set; }

    public ICollection<Prescription_Medicament> Prescription_Medicaments { get; set; }
}