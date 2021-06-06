using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Configuration
{
    public class DutyConfiguration : IEntityTypeConfiguration<Duty>
    {
        public void Configure(EntityTypeBuilder<Duty> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.DutyName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(100);
        }
    }
}
