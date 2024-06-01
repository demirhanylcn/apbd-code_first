using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using solution.Models;

namespace solution.Data;

public class PrescriptionMedicamentConfiguration : IEntityTypeConfiguration<Prescription_Medicament>
{
    public void Configure(EntityTypeBuilder<Prescription_Medicament> builder)
    {
        builder.HasKey(e => new { e.PrescriptionId, e.MedicamentId});
        builder.Property(e => e.Details).HasMaxLength(100);
        
        builder.HasOne(e => e.Prescription)
            .WithMany(p => p.Prescription_Medicaments)
            .HasForeignKey(e => e.PrescriptionId);

        builder.HasOne(e => e.Medicament)
            .WithMany(m => m.Prescription_Medicaments)
            .HasForeignKey(e => e.MedicamentId);
        

    }
}