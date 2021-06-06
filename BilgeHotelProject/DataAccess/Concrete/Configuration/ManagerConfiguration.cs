using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Address).IsRequired().HasMaxLength(500);
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(13);
            builder.Property(x => x.NationalIdentificationNumber).IsRequired().HasMaxLength(100);
        }
    }
}
