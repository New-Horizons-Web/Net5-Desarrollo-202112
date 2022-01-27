using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Net5.SignalR.Chat.BackEnd.Infrastructure.Data.Contexts
{
    public class ChatConfiguration : IEntityTypeConfiguration<Entities.Chat>
    {
        public void Configure(EntityTypeBuilder<Entities.Chat> entity)
        {
            entity.ToTable("Chat");

            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.Property(e => e.Message)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Room)
                .WithMany(p => p.Chats)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChatRoom");

            entity.HasOne(d => d.User)
                .WithMany(p => p.Chats)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChatUser");
        }
    }
}
