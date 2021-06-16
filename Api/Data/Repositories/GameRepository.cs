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
                .Include("Stops.Questions.Choices.OpensMapPositions") // For both TextQuestion and ChoiceQuestion
                .Include("Stops.Questions.DefaultChoice.OpensMapPositions")
                .Include("Stops.Questions.ChoicesThatOpensThis.OpensMapPositions")
                .Include("Stops.DisplayObjectsHints.DisplayObject")
                .Include("Stops.DisplayObjectsRewards.DisplayObject")
                .Include("Stops.Position")
                .Include("Stops.PositionsDisplayAfterDisplay")
                .Include("Stops.PositionsDisplayAfterUnlock")
                .Include("Stops.ChoicesOpenThis.ChoiceOpensThis")
                .Include("Stops.Passwords.Passwords")
                .Include("Stops.Opens.Opens")
                .Include("Introduction.MapPositions")
                .Include("Introduction.DisplayObjects")
                .Include("Owners")
                .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Game> GetFullGameWithoutUsersByIdAsync(int id)
        {
            return await AppContext.Games
                .Include("Stops.Questions.Choices.OpensMapPositions") // For both TextQuestion and ChoiceQuestion
                .Include("Stops.Questions.DefaultChoice.OpensMapPositions")
                .Include("Stops.Questions.ChoicesThatOpensThis.OpensMapPositions")
                .Include("Stops.DisplayObjectsHints.DisplayObject")
                .Include("Stops.DisplayObjectsRewards.DisplayObject")
                .Include("Stops.Position")
                .Include("Stops.PositionsDisplayAfterDisplay")
                .Include("Stops.PositionsDisplayAfterUnlock")
                .Include("Stops.ChoicesOpenThis.ChoiceOpensThis")
                .Include("Stops.Passwords.Passwords")
                .Include("Stops.Opens.Opens")
                .Include("Introduction.MapPositions")
                .Include("Introduction.DisplayObjects")
                .SingleOrDefaultAsync(c => c.Id == id);
        }
    }
}
