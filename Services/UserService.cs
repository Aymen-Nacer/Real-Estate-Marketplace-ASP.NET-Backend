using System;
using System.Collections.Generic;
using System.Linq;
using real_estate_asp.Models;
using real_estate_asp.Data;
using real_estate_asp.DTO;



namespace real_estate_asp.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public User UpdateUser(long id, UserUpdateRequest request)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            user.Username = request.Username;
            user.Email = request.Email;

            _context.SaveChanges();
            return user;
        }

        public void DeleteUser(long id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public List<Listing> GetUserListings(long id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            return _context.Listings.Where(l => l.UserId == id.ToString()).ToList();
        }

        public User GetUserById(long id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            return user;
        }
    }
}
