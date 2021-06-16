using System.Collections.Generic;
using System.Threading.Tasks;
using Project_mobile_app.Models;

namespace Project_mobile_app.Interfaces.Services
{
    public interface IGameService
    {
        Task<IEnumerable<Game>> GetAllWithUsers();

        Task<Game> GetWithUsersById(int id);

        Task<Game> GetFullGameById(int id);
    }
}
