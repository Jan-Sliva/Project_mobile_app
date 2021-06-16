using System.Collections.Generic;
using System.Threading.Tasks;
using Project_mobile_app.Interfaces;
using Project_mobile_app.Interfaces.Services;
using Project_mobile_app.Models;

namespace Project_mobile_app.Services
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GameService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Game>> GetAllWithUsers()
        {
            return await _unitOfWork.Games.GetAllWithUsersAsync();
        }

        public async Task<Game> GetWithUsersById(int id)
        {
            return await _unitOfWork.Games.GetWithUsersByIdAsync(id);
        }

        public async Task<Game> GetFullGameById(int id)
        {
            return await _unitOfWork.Games.GetFullGameByIdAsync(id);
        }
    }
}
