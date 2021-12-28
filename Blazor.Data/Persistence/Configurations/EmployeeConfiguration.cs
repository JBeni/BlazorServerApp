using Blazor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blazor.Data.Persistence.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");

            builder.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

            builder.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.Department)
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.Gender)
                .HasMaxLength(6)
                .IsUnicode(false);

            builder.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        }
    }
}
