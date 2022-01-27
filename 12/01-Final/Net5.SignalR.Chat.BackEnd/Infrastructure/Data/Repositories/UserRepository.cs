using Net5.SignalR.Chat.BackEnd.Infrastructure.Data.Contexts;
using Net5.SignalR.Chat.BackEnd.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Net5.SignalR.Chat.BackEnd.Infrastructure.Data.Entities;

namespace Net5.SignalR.Chat.BackEnd.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SignalRChatContext _context;
        public UserRepository(SignalRChatContext context)
        {
            _context = context;
        }
        public UserDto GetByUserName(string userName)
        {
            var query = from u in _context.Users
                        where u.UserName == userName
                        select new UserDto
                        {
                            UserId = u.UserId,
                            UserName = u.UserName
                        };
            UserDto user = query.FirstOrDefault();

            return user;
        }

        public List<UserDto> ListUsersByRoomId(int roomId)
        {
            var query = from u in _context.Users
                        join ru in _context.RoomUsers
                        on u.UserId equals ru.UserId
                        where ru.RoomId == roomId
                        select new UserDto
                        {
                            UserId = u.UserId,
                            UserName = u.UserName
                        };
            List<UserDto> users = query.ToList();

            return users;
        }
        public List<UserDto> ListUsersByRoomIdAndStatus(int roomId, string status)
        {
            var query = from u in _context.Users
                        join ru in _context.RoomUsers
                        on u.UserId equals ru.UserId
                        where ru.RoomId == roomId && ru.Status == status
                        select new UserDto
                        {
                            UserId = u.UserId,
                            UserName = u.UserName
                        };
            List<UserDto> users = query.ToList();

            return users;
        }

        public List<UserDto> ListUsersByRoomIdAndUserIdAndStatus(int roomId, int userId, string status)
        {
            var query = from u in _context.Users
                        join ru in _context.RoomUsers
                        on u.UserId equals ru.UserId
                        where ru.RoomId == roomId && ru.UserId == userId && ru.Status == status
                        select new UserDto
                        {
                            UserId = u.UserId,
                            UserName = u.UserName
                        };
            List<UserDto> users = query.ToList();

            return users;
        }

        public UserDto Insert(UserDto user)
        {
            User newUser = new User { UserName = user.UserName };
            _context.Users.Add(newUser);
            _context.SaveChanges();

            user.UserId = newUser.UserId;
            return user;
        }
    }
}
