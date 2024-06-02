using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using solution.Models;

namespace solution.Data;

public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder.HasKey(e => e.PrescriptionId);
        builder.HasOne(e => e.Doctor).WithMany(e => e.Prescriptions).HasForeignKey(e => e.DoctorId);
        builder.HasOne(e => e.Patient).WithMany(e => e.Prescriptions).HasForeignKey(e => e.PatientId);
    }
}