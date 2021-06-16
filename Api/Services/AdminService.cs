using System.Collections.Generic;
using System.Threading.Tasks;
using Project_mobile_app.Interfaces;
using Project_mobile_app.Interfaces.Services;
using Project_mobile_app.Models;

namespace Project_mobile_app.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdminService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Admin>> GetAll()
        {
            return await _unitOfWork.Admins.GetAllAsync();
        }

        public async Task<Admin> GetById(int id)
        {
            return await _unitOfWork.Admins.GetByIdAsync(id);
        }

        public async Task<Admin> CreateAdmin(Admin newAdmin)
        {
            await _unitOfWork.Admins.AddAsync(newAdmin);
            await _unitOfWork.CommitAsync();
            return newAdmin;
        }

        public async Task UpdateAdmin(Admin adminToBeUpdated, Admin admin)
        {
            adminToBeUpdated.UserName = admin.UserName;
            adminToBeUpdated.Password = admin.Password;
            adminToBeUpdated.Email = admin.Email;

            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAdmin(Admin admin)
        {
            _unitOfWork.Admins.Remove(admin);
            await _unitOfWork.CommitAsync();
        }
    }
}
