using Server.Database;
using Server.Modal;
using System.Linq;

namespace Server.Service
{
    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        // Create a new user in the database
        public void Create(User userObj)
        {
            _context.Users.Add(userObj);
            _context.SaveChanges();
        }

        // Read: Get a user by their ID
        public User GetById(long userId)
        {
            return _context.Users.FirstOrDefault(u => u.Id == userId);
        }

        // Read: Get all users
        public User[] GetAll()
        {
            return _context.Users.ToArray();
        }

        // Update: Update an existing user
        public void Update(User updatedUser)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Id == updatedUser.Id);
            if (existingUser != null)
            {
                existingUser.Name = updatedUser.Name;
                existingUser.Email = updatedUser.Email;
                existingUser.Password = updatedUser.Password;
                existingUser.Phone = updatedUser.Phone;
                existingUser.Address = updatedUser.Address;
                existingUser.Role = updatedUser.Role;

                _context.Users.Update(existingUser);
                _context.SaveChanges();
            }
        }

        // Delete: Delete a user by their ID
        public void Delete(long userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        // Check email and password, return the validated user object
        public User Validate(string email, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        // Return all users with the Volunteer role
        public User[] GetAllVolunteer()
        {
            return _context.Users.Where(u => u.Role == Role.Volunteer).ToArray();
        }

        // Return all users with the Cooperator role
        public User[] GetAllCooperator()
        {
            return _context.Users.Where(u => u.Role == Role.Cooperator).ToArray();
        }
    }
}