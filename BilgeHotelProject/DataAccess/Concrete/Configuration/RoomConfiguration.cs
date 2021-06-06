using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Configuration
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.RoomDescription).IsRequired().HasMaxLength(500);
            builder.Property(x => x.RoomFeatures).IsRequired().HasMaxLength(500);
        }
    }
}
