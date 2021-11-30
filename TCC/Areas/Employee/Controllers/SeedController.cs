using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TCC.DataAccess.Repository.IRepository;
using TCC.Models;
using TCC.Models.DTO;
using TCC.Models.Mappings;
using TCC.Models.ViewModels;
using TCC.Utility;

namespace TCC.Areas.Employee.Controllers
{
    [Area("Employee")]
    [Authorize(Roles = SD.Role_Employee + "," + SD.Role_Admin)]
    public class SeedController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SeedController(IUnitOfWork unityOfWork)
        {
            _unitOfWork = unityOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            IEnumerable<Cultura> CultureList = (await _unitOfWork.Cultura.GetAllAsync()).Where(q => q.Deletado == false);
            IEnumerable<Fornecedor> ProviderList = (await _unitOfWork.Fornecedor.GetAllAsync()).Where(q => q.Deletado == false);
            SementeVM sementeVM = new SementeVM()
            {
                Semente = new Semente(),
                CultureList = CultureList.Select(i => new SelectListItem
                {
                    Text = i.Nome,
                    Value = i.Id.ToString()
                }),
                ProviderList = ProviderList.Select(i => new SelectListItem
                {
                    Text = i.Nome,
                    Value = i.Id.ToString()
                })
            };
            if (id == null)
            {
                //this is for create
                return View(SementeVMMapping.AsSementeVMDTO(sementeVM));
            }
            //this is for edit
            sementeVM.Semente = await _unitOfWork.Semente.GetAsync(id.GetValueOrDefault());
            if (sementeVM.Semente == null)
            {
                return NotFound();
            }

            return View(SementeVMMapping.AsSementeVMDTO(sementeVM));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(SementeVMDTO sementeVMDTO)
        {
            SementeVM sementeVM = SementeVMMapping.AsSementeVM(sementeVMDTO);
            try
            {

                if (ModelState.IsValid)
                {
                    if (sementeVM.Semente.Id == 0)
                    {
                        await _unitOfWork.Semente.AddAsync(sementeVM.Semente);

                    }
                    else
                    {
                        _unitOfWork.Semente.Update(sementeVM.Semente);
                    }
                    await _unitOfWork.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    IEnumerable<Cultura> CultureList = (await _unitOfWork.Cultura.GetAllAsync()).Where(q => q.Deletado == false);
                    IEnumerable<Fornecedor> ProviderList = (await _unitOfWork.Fornecedor.GetAllAsync()).Where(q => q.Deletado == false);
                    sementeVM.CultureList = CultureList.Select(i => new SelectListItem
                    {
                        Text = i.Nome,
                        Value = i.Id.ToString()
                    });
                    sementeVM.ProviderList = ProviderList.Select(i => new SelectListItem
                    {
                        Text = i.Nome,
                        Value = i.Id.ToString()
                    });
                }

            }
            catch (Exception ex)
            {

            }
            return View(SementeVMMapping.AsSementeVMDTO(sementeVM));
        }


        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = (await _unitOfWork.Semente.GetAllAsync(includeProperties: "Cultura,Fornecedor")).Where(q => q.Deletado == false);
            return Json(new { data = allObj });
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _unitOfWork.Semente.GetAsync(id);
            if (objFromDb == null)
            {
                TempData["Error"] = "Erro ao deletar Semente";
                return Json(new { sucess = false, message = "Erro ao deletar" });
            }
            await _unitOfWork.Semente.RemoveAsync(objFromDb);
            await _unitOfWork.SaveAsync();

            TempData["Success"] = "Semente deletada com sucesso!";
            return Json(new { sucess = true, message = "Deletado com sucesso" });
        }
        #endregion


    }
}
