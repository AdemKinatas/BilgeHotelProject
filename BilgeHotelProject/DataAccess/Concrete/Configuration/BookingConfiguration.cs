using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Configuration
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.PersonName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.PersonLastName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(13);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
        }
    }
}
