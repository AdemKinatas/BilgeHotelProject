using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Configuration
{
    public class BookingPackageConfiguration : IEntityTypeConfiguration<BookingPackage>
    {
        public void Configure(EntityTypeBuilder<BookingPackage> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.BookingPackageName).IsRequired().HasMaxLength(100);
        }
    }
}
