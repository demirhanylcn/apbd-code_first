using System.ComponentModel.DataAnnotations;

namespace solution.Models;

public class PrescriptionMedicament
{
    public int Dose { get; set; }
    public string Details { get; set; }
    public int PrescriptionId { get; set; }
    public Prescription Prescription { get; set; }

    public int MedicamentId { get; set; }
    public Medicament Medicament { get; set; }

}