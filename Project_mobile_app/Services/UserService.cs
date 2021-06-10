using System.Collections.Generic;
using System.Threading.Tasks;
using Project_mobile_app.Interfaces;
using Project_mobile_app.Interfaces.Services;
using Project_mobile_app.Models;

namespace Project_mobile_app.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _unitOfWork.Users.GetAllAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _unitOfWork.Users.GetByIdAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllWithStatsAndGames()
        {
            return await _unitOfWork.Users.GetAllWithStatAndGamesAsync();
        }

        public async Task<User> GetWithStatsAndGamesById(int id)
        {
            return await _unitOfWork.Users.GetWithStatAndGamesByIdAsync(id);
        }

        public async Task<User> GetWithStatsById(int id)
        {
            return await _unitOfWork.Users.GetWithStatByIdAsync(id);
        }

        public async Task<User> CreateUser(User newUser)
        {
            await _unitOfWork.Users.AddAsync(newUser);
            await _unitOfWork.CommitAsync();
            return newUser;
        }

        public async Task UpdateUser(User userToBeUpdated, User user)
        {
            userToBeUpdated.UserName = user.UserName;
            userToBeUpdated.Password = user.Password;
            userToBeUpdated.Email = user.Email;

            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateUserWithStat(User userToBeUpdated, User user)
        {
            userToBeUpdated.UserName = user.UserName;
            userToBeUpdated.Password = user.Password;
            userToBeUpdated.Email = user.Email;

            userToBeUpdated.Statistics.NumberOfGamesPlayed = user.Statistics.NumberOfGamesPlayed;
            userToBeUpdated.Statistics.SuccesfullGames = user.Statistics.SuccesfullGames;
            userToBeUpdated.Statistics.TimeInGames = user.Statistics.TimeInGames;

            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteUser(User user)
        {
            _unitOfWork.Users.Remove(user);
            await _unitOfWork.CommitAsync();
        }
    }
}
