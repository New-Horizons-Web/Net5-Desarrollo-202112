using Net5.SignalR.Chat.BackEnd.Infrastructure.Data.Entities;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Net5.SignalR.Chat.BackEnd.Infrastructure.Data.Contexts
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> entity)
        {
            entity.ToTable("Room");

            entity.HasIndex(e => e.RoomName)
                .HasName("UQ__Room__6B500B558C2ADB86")
                .IsUnique();

            entity.Property(e => e.RoomName)
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}
