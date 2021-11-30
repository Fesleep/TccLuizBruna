using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TCC.DataAccess.Data;
using TCC.DataAccess.Repository.IRepository;
using TCC.Models;
using TCC.Utility;

namespace TCC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _db;

        public UserController(IUnitOfWork unityOfWork, ApplicationDbContext db)
        {
            _unitOfWork = unityOfWork;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userList = await _unitOfWork.ApplicationUser.GetAllAsync();
            var userRole = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();
            foreach (var user in userList)
            {
                var roleId = userRole.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(u => u.Id == roleId).Name;
                if (user.Role == "Admin")
                {
                    user.Role = "Administrador";
                }
                else if (user.Role == "Employee")
                {
                    user.Role = "Funcionário";
                }
            }
            return Json(new { data = userList });
        }

        [HttpPost]
        public async Task<IActionResult> LockUnlock([FromBody] string id)
        {
            var objFromDb = await _unitOfWork.ApplicationUser.GetByIdStringAsync(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Erro ativar/desativando usuário." });
            }
            if (objFromDb != null && objFromDb.LockoutEnd > DateTime.Now)
            {
                //ativar
                objFromDb.LockoutEnd = DateTime.Now;
            }
            else
            {
                objFromDb.LockoutEnd = DateTime.Now.AddYears(1000);
            }
            await _unitOfWork.SaveAsync();
            return Json(new { success = true, message = "Operação feita com sucesso." });

        }
        #endregion


    }
}
