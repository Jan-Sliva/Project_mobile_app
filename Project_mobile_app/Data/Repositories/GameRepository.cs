using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project_mobile_app.Models;
using Project_mobile_app.Interfaces.Repositories;
using Project_mobile_app.Data;

namespace Project_mobile_app.Data.Repositories
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        public GameRepository(Project_mobile_appContext context)
            : base(context)
        { }

        private Project_mobile_appContext AppContext
        {
            get { return Context as Project_mobile_appContext; }
        }

        public async Task<IEnumerable<Game>> GetAllWithUsersAsync()
        {
            return await AppContext.Games
                .Include(c => c.Owners)
                .ToListAsync();
        }

        public async Task<Game> GetWithUsersByIdAsync(int id)
        {
            return await AppContext.Games
                .Include(c => c.Owners)
                .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Game>> GetByUserIdAsync(int userId)
        {
            return await AppContext.Games
                .Where(c => c.Owners.Any(u => u.Id == userId))
                .ToListAsync();
        }

        public async Task<IEnumerable<Game>> GetWithUsersByUserIdAsync(int userId)
        {
            return await AppContext.Games
                .Include(c => c.Owners)
                .Where(c => c.Owners.Any(u => u.Id == userId))
                .ToListAsync();
        }

        public async Task<Game> GetFullGameByIdAsync(int id)
        {
            return await AppContext.Games
                .Include("DefaultChoice.DisplayObjectStopDisplayAfterDisplay.DisplayObjectStopDisplayAfterUnlock.Game." +
                "GamePassword.ChoiceForChoiceQuestion.ChoiceForTextQuestion.ChoiceQuestion.ChoiceStop.Introduction." +
                "MapPosition.PasswordGameRequirement.Picture.Stop.StopStop.Text.TextQuestion.User")
                .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Game> GetFullGameWithoutUsersByIdAsync(int id)
        {
            return await AppContext.Games
                .Include("DefaultChoice.DisplayObjectStopDisplayAfterDisplay.DisplayObjectStopDisplayAfterUnlock.Game." +
                "GamePassword.ChoiceForChoiceQuestion.ChoiceForTextQuestion.ChoiceQuestion.ChoiceStop.Introduction." +
                "MapPosition.PasswordGameRequirement.Picture.Stop.StopStop.Text.TextQuestion")
                .SingleOrDefaultAsync(c => c.Id == id);
        }
    }
}
