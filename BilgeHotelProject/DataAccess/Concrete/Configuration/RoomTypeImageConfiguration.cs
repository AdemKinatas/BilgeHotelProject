using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Configuration
{
    public class RoomTypeImageConfiguration : IEntityTypeConfiguration<RoomTypeImage>
    {
        public void Configure(EntityTypeBuilder<RoomTypeImage> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ImageUrl).IsRequired().HasMaxLength(250);
        }
    }
}
