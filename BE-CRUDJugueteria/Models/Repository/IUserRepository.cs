namespace BE_CRUDJugueteria.Models.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int id);
        Task<User> AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(User user);
        Task<List<User>> GetListUsers();
    }
}
