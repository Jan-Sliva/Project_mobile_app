using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project_mobile_app.Models;
using Project_mobile_app.Interfaces.Repositories;
using Project_mobile_app.Data;

namespace Project_mobile_app.Data.Repositories
{
    public class AdminRepository : Repository<Admin>, IAdminRepository
    {
        public AdminRepository(Project_mobile_appContext context)
            : base(context)
        { }

        private Project_mobile_appContext AppContext
        {
            get { return Context as Project_mobile_appContext; }
        }
    }
}
