namespace solution.DTOs;

public class MedicamentDTO
{
    public int IdMedicament { get; set; }
    public int Dose { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public List<PrescriptionMedicamentDTO> PrescriptionMedicaments { get; set; }
  
}