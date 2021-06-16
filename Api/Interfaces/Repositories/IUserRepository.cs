using System.Collections.Generic;
using System.Threading.Tasks;
using Project_mobile_app.Models;

namespace Project_mobile_app.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetAllWithStatAsync();

        Task<User> GetWithStatByIdAsync(int id);

        Task<IEnumerable<User>> GetAllWithGamesAsync();

        Task<User> GetWithGamesByIdAsync(int id);

        Task<IEnumerable<User>> GetAllWithStatAndGamesAsync();

        Task<User> GetWithStatAndGamesByIdAsync(int id);

        Task<IEnumerable<User>> GetByGameIdAsync(int gameId);

        Task<IEnumerable<User>> GetWithStatByGameIdAsync(int gameId);

        Task<IEnumerable<User>> GetWithGamesByGameIdAsync(int gameId);

        Task<IEnumerable<User>> GetWithStatAndGamesByGameIdAsync(int gameId);
    }
}
