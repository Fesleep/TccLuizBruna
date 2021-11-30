using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TCC.DataAccess.Repository.IRepository;
using TCC.Models;
using TCC.Utility;

namespace TCC.Areas.Employee.Controllers
{
    [Area("Employee")]
    [Authorize(Roles = SD.Role_Employee + "," + SD.Role_Admin)]
    public class ProviderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProviderController(IUnitOfWork unityOfWork)
        {
            _unitOfWork = unityOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            Fornecedor fornecedor = new();
            if (id == null)
            {
                //create
                return View(fornecedor);
            }
            //edit
            fornecedor = await _unitOfWork.Fornecedor.GetAsync(id.GetValueOrDefault());
            if (fornecedor == null)
            {
                return NotFound();
            }
            return View(fornecedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                if (fornecedor.Id == 0)
                {
                    await _unitOfWork.Fornecedor.AddAsync(fornecedor);
                }
                else
                {
                    _unitOfWork.Fornecedor.Update(fornecedor);
                }
                await _unitOfWork.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedor);
        }


        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = (await _unitOfWork.Fornecedor.GetAllAsync()).Where(q => q.Deletado == false);
            return Json(new { data = allObj });
        }
        

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _unitOfWork.Fornecedor.GetAsync(id);
            if (objFromDb == null)
            {
                TempData["Error"] = "Erro ao deletar Fornecedor";
                return Json(new { sucess = false, message = "Erro ao deletar" });
            }
            await _unitOfWork.Fornecedor.RemoveAsync(objFromDb);
            await _unitOfWork.SaveAsync();

            TempData["Success"] = "Fornecedor deletado com sucesso!";
            return Json(new { sucess = true, message = "Deletado com sucesso" });
        }
        #endregion


    }
}
