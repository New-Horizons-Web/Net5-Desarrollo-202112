using Net5.SignalR.Chat.BackEnd.Infrastructure.Data.Entities;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Net5.SignalR.Chat.BackEnd.Infrastructure.Data.Contexts
{
    public class RoomUserConfiguration : IEntityTypeConfiguration<RoomUser>
    {
        public void Configure(EntityTypeBuilder<RoomUser> entity)
        {
            entity.ToTable("RoomUser");

            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Room)
                .WithMany(p => p.RoomUsers)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoomUserRoom");

            entity.HasOne(d => d.User)
                .WithMany(p => p.RoomUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoomUserUser");
        }
    }
}
