using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project_mobile_app.Interfaces.Repositories;

namespace Project_mobile_app.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAdminRepository Admins { get; }

        IUserRepository Users { get; }

        IGameRepository Games { get; }

        Task<int> CommitAsync();
    }
}
