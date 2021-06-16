using System.Collections.Generic;
using System.Threading.Tasks;
using Project_mobile_app.Models;

namespace Project_mobile_app.Interfaces.Repositories
{
    public interface IGameRepository : IRepository<Game>
    {
        Task<IEnumerable<Game>> GetAllWithUsersAsync();
        
        Task<Game> GetWithUsersByIdAsync(int id);

        Task<IEnumerable<Game>> GetByUserIdAsync(int userId);

        Task<IEnumerable<Game>> GetWithUsersByUserIdAsync(int userId);

        Task<Game> GetFullGameByIdAsync(int id);

        Task<Game> GetFullGameWithoutUsersByIdAsync(int id);
    }
}
