using System.Collections.Generic;
using System.Threading.Tasks;
using Project_mobile_app.Models;

namespace Project_mobile_app.Interfaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();

        Task<User> GetById(int id);

        Task<IEnumerable<User>> GetAllWithStatsAndGames();

        Task<User> GetWithStatsAndGamesById(int id);

        Task<User> GetWithStatsById(int id);

        Task<User> CreateUser(User newUser);

        Task UpdateUser(User userToBeUpdated, User user);

        Task UpdateUserWithStat(User userToBeUpdated, User user);

        Task DeleteUser(User user);
    }
}
