using System.Threading.Tasks;
using Project_mobile_app.Interfaces;
using Project_mobile_app.Data;
using Project_mobile_app.Interfaces.Repositories;
using Project_mobile_app.Data.Repositories;

namespace Project_mobile_app.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Project_mobile_appContext _context;
        private AdminRepository _adminRepository;
        private GameRepository _gameRepository;
        private UserRepository _userRepository;

        public UnitOfWork(Project_mobile_appContext context)
        {
            this._context = context;
        }

        public IAdminRepository Admins => _adminRepository = _adminRepository ?? new AdminRepository(_context);

        public IGameRepository Games => _gameRepository = _gameRepository ?? new GameRepository(_context);

        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
