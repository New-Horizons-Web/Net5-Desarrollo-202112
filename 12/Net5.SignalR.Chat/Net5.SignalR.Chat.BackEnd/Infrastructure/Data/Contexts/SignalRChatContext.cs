using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Net5.SignalR.Chat.BackEnd.Infrastructure.Data.Entities;

namespace Net5.SignalR.Chat.BackEnd.Infrastructure.Data.Contexts
{
    public partial class SignalRChatContext : DbContext
    {
        public SignalRChatContext()
        {
        }

        public SignalRChatContext(DbContextOptions<SignalRChatContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Entities.Chat> Chats { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomUser> RoomUsers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ChatConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new RoomUserConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
