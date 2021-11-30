using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
    public class CultureController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CultureController(IUnitOfWork unityOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unityOfWork;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            Cultura cultura = new Cultura();
            if (id == null)
            {
                //this is for create
                return View(CulturaMapping.AsCulturaDTO(cultura));
            }
            //this is for edit
            cultura = await _unitOfWork.Cultura.GetAsync(id.GetValueOrDefault());
            if (cultura == null)
            {
                return NotFound();
            }
            return View(CulturaMapping.AsCulturaDTO(cultura));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(CulturaDTO culturaDTO)
        {
            Cultura cultura = CulturaMapping.AsCultura(culturaDTO);
            if (ModelState.IsValid)
            {
                string webRootPath = _hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images\products");
                    var extenstion = Path.GetExtension(files[0].FileName);

                    if (cultura.ImagemUrl != null)
                    {
                        //this is an edit and we need to remove old image
                        var imagePath = Path.Combine(webRootPath, cultura.ImagemUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }
                    }
                    using (var filesStreams = new FileStream(Path.Combine(uploads, fileName + extenstion), FileMode.Create))
                    {
                        files[0].CopyTo(filesStreams);
                    }
                    cultura.ImagemUrl = @"\images\products\" + fileName + extenstion;
                }
                else
                {
                    //update when they do not change the image
                    if (cultura.Id != 0)
                    {
                        Cultura objFromDb = await _unitOfWork.Cultura.GetAsync(cultura.Id);
                        cultura.ImagemUrl = objFromDb.ImagemUrl;
                    }
                }


                if (cultura.Id == 0)
                {
                    await _unitOfWork.Cultura.AddAsync(cultura);

                }
                else
                {
                    _unitOfWork.Cultura.Update(cultura);
                }
                await _unitOfWork.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(CulturaMapping.AsCulturaDTO(cultura));
        }


        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = (await _unitOfWork.Cultura.GetAllAsync()).Where(q => q.Deletado == false);
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _unitOfWork.Cultura.GetAsync(id);
            if (objFromDb == null)
            {
                TempData["Error"] = "Erro ao deletar Cultura";
                return Json(new { success = false, message = "Error while deleting" });
            }
            string webRootPath = _hostEnvironment.WebRootPath;
            var imagePath = Path.Combine(webRootPath, objFromDb.ImagemUrl.TrimStart('\\'));
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
            await _unitOfWork.Cultura.RemoveAsync(objFromDb);
            await _unitOfWork.SaveAsync();
            TempData["Success"] = "Cultura deletada com sucesso.";
            return Json(new { success = true, message = "Delete Successful" });

        }

        #endregion

    }
}
