using Net5.SignalR.Chat.BackEnd.Infrastructure.Data.Entities;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Net5.SignalR.Chat.BackEnd.Infrastructure.Data.Contexts
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("User");

            entity.HasIndex(e => e.UserName)
                .HasName("UQ__User__C9F284568175C925")
                .IsUnique();

            entity.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}
