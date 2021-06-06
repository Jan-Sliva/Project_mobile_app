using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project_mobile_app.Models;
using Project_mobile_app.Interfaces.Repositories;
using Project_mobile_app.Data;

namespace Project_mobile_app.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(Project_mobile_appContext context)
            : base(context)
        { }

        private Project_mobile_appContext AppContext
        {
            get { return Context as Project_mobile_appContext; }
        }

        public async Task<IEnumerable<User>> GetAllWithStatAsync()
        {
            return await AppContext.Users
                .Include(c => c.Statistics)
                .ToListAsync();
        }

        public async Task<User> GetWithStatByIdAsync(int id)
        {
            return await AppContext.Users
                .Include(c => c.Statistics)
                .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<User>> GetAllWithGamesAsync()
        {
            return await AppContext.Users
                .Include(c => c.Games)
                .ToListAsync();
        }

        public async Task<User> GetWithGamesByIdAsync(int id)
        {
            return await AppContext.Users
                .Include(c => c.Games)
                .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<User>> GetAllWithStatAndGamesAsync()
        {
            return await AppContext.Users
                .Include(c => c.Statistics)
                .Include(c => c.Games)
                .ToListAsync();
        }

        public async Task<User> GetWithStatAndGamesByIdAsync(int id)
        {
            return await AppContext.Users
                .Include(c => c.Statistics)
                .Include(c => c.Games)
                .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<User>> GetByGameIdAsync(int gameId)
        {
            return await AppContext.Users
                .Where(c => c.Games.Any(g => g.Id == gameId))
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetWithStatByGameIdAsync(int gameId)
        {
            return await AppContext.Users
                .Include(c => c.Statistics)
                .Where(c => c.Games.Any(g => g.Id == gameId))
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetWithGamesByGameIdAsync(int gameId)
        {
            return await AppContext.Users
                .Include(c => c.Games)
                .Where(c => c.Games.Any(g => g.Id == gameId))
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetWithStatAndGamesByGameIdAsync(int gameId)
        {
            return await AppContext.Users
                .Include(c => c.Statistics)
                .Include(c => c.Games)
                .Where(c => c.Games.Any(g => g.Id == gameId))
                .ToListAsync();
        }
    }
}
