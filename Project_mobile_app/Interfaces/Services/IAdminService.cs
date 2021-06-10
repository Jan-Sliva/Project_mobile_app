using System.Collections.Generic;
using System.Threading.Tasks;
using Project_mobile_app.Models;

namespace Project_mobile_app.Interfaces.Services
{
    public interface IAdminService
    {
        Task<IEnumerable<Admin>> GetAll();

        Task<Admin> GetById(int id);

        Task<Admin> CreateAdmin(Admin newAdmin);

        Task UpdateAdmin(Admin adminToBeUpdated, Admin admin);

        Task DeleteAdmin(Admin admin);
    }
}
