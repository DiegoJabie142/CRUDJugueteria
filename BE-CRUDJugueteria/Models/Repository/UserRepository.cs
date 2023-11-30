using Microsoft.EntityFrameworkCore;

namespace BE_CRUDJugueteria.Models.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task<User> AddUser(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }
        public async Task UpdateUser(User user)
        {
            var userItem = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);

            if (userItem is not null)
            {
                userItem.Name = user.Name;
                userItem.Password = user.Password;
                userItem.Role = user.Role;
                userItem.Email = user.Email;

                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteUser(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
        public async Task<List<User>> GetListUsers()
        {
            return await _context.Users.ToListAsync();
        }

    }
}
