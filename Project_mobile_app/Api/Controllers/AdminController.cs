using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project_mobile_app.Models;
using Project_mobile_app.Interfaces.Services;
using Project_mobile_app.Api.Resources.AdminResources;
using Project_mobile_app.Api.Validators;
using AutoMapper;

namespace Project_mobile_app.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;
        public AdminController(IAdminService adminService, IMapper mapper)
        {
            this._mapper = mapper;
            this._adminService = adminService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<AdminResource>>> GetAllAdmins()
        {
            var admins = await _adminService.GetAll();
            var adminResources = _mapper.Map<IEnumerable<Admin>, IEnumerable<AdminResource>>(admins);
            return Ok(adminResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<AdminResource>>> GetAdminById(int id)
        {
            var admin = await _adminService.GetById(id);
            var adminResource = _mapper.Map<Admin, AdminResource>(admin);
            return Ok(adminResource);
        }
        
        [HttpPost("")]
        public async Task<ActionResult<AdminResource>> CreateAdmin([FromBody] AdminSaveResource admin)
        {
            var validator = new AdminSaveResourceValidator();
            var validationResult = await validator.ValidateAsync(admin);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var adminToCreate = _mapper.Map<AdminSaveResource, Admin>(admin);

            var newAdmin = await _adminService.CreateAdmin(adminToCreate);

            var createdAdmin = await _adminService.GetById(newAdmin.Id);

            var adminResource = _mapper.Map<Admin, AdminResource>(createdAdmin);

            return Ok(adminResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AdminResource>> UpdateAdmin(int id, [FromBody] AdminSaveResource admin)
        {
            var validator = new AdminSaveResourceValidator();
            var validationResult = await validator.ValidateAsync(admin);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var adminToBeUpdate = await _adminService.GetById(id);

            if (adminToBeUpdate == null)
                return NotFound();

            var mappedAdmin = _mapper.Map<AdminSaveResource, Admin>(admin);

            await _adminService.UpdateAdmin(adminToBeUpdate, mappedAdmin);

            var updatedAdmin = await _adminService.GetById(id);
            var updatedAdminResource = _mapper.Map<Admin, AdminResource>(updatedAdmin);

            return Ok(updatedAdminResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            var admin = await _adminService.GetById(id);

            await _adminService.DeleteAdmin(admin);

            return NoContent();
        }
    }
}
