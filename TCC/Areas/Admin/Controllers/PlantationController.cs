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

namespace TCC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class PlantationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PlantationController(IUnitOfWork unityOfWork, IWebHostEnvironment hostEnvironment)
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
            IEnumerable<Semente> SeedList = (await _unitOfWork.Semente.GetAllAsync()).Where(q => q.Deletado == false);
            IEnumerable<Lote> BatchList = (await _unitOfWork.Lote.GetAllAsync()).Where(q => q.Deletado == false);
            PlantacaoVM plantacaoVM = new PlantacaoVM()
            {
                Plantacao = new Plantacao(),
                SeedList = SeedList.Select(i => new SelectListItem
                {
                    Text = i.Nome,
                    Value = i.Id.ToString()
                }),
                BatchList = BatchList.Select(i => new SelectListItem
                {
                    Text = i.Nome,
                    Value = i.Id.ToString()
                })
            };
            if (id == null)
            {
                //this is for create
                return View(PlantacaoVMMapping.AsPlantacaoVMDTO(plantacaoVM));
            }
            //this is for edit
            plantacaoVM.Plantacao = await _unitOfWork.Plantacao.GetAsync(id.GetValueOrDefault());
            if (plantacaoVM.Plantacao == null)
            {
                return NotFound();
            }
            return View(PlantacaoVMMapping.AsPlantacaoVMDTO(plantacaoVM));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(PlantacaoVMDTO plantacaoVMDTO)
        {
            PlantacaoVM plantacaoVM = PlantacaoVMMapping.AsPlantacaoVM(plantacaoVMDTO);
            try
            {

                if (ModelState.IsValid)
                {
                    if (plantacaoVM.Plantacao.Id == 0)
                    {
                        await _unitOfWork.Plantacao.CustomAddAsync(plantacaoVM.Plantacao);

                    }
                    else
                    {
                        _unitOfWork.Plantacao.Update(plantacaoVM.Plantacao);
                    }
                    await _unitOfWork.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    IEnumerable<Semente> SeedList = (await _unitOfWork.Semente.GetAllAsync()).Where(q => q.Deletado == false);
                    IEnumerable<Lote> BatchList = (await _unitOfWork.Lote.GetAllAsync()).Where(q => q.Deletado == false);
                    plantacaoVM.SeedList = SeedList.Select(i => new SelectListItem
                    {
                        Text = i.Nome,
                        Value = i.Id.ToString()
                    });
                    plantacaoVM.BatchList = BatchList.Select(i => new SelectListItem
                    {
                        Text = i.Nome,
                        Value = i.Id.ToString()
                    });
                }

            }
            catch (Exception ex)
            {

            }
            return View(PlantacaoVMMapping.AsPlantacaoVMDTO(plantacaoVM));
        }


        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var allObj = (await _unitOfWork.Plantacao.GetAllAsync(includeProperties: "Semente,Lote")).Where(q => q.Deletado == false && q.Ativo == true);
                return Json(new { data = allObj });
            }
            catch (Exception e)
            {
                return Json(new { data = "fail" });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _unitOfWork.Plantacao.GetAsync(id);
            if (objFromDb == null)
            {
                TempData["Error"] = "Erro ao deletar Lote";
                return Json(new { success = false, message = "Erro ao deletar" });
            }
            await _unitOfWork.Plantacao.RemoveAsync(objFromDb);
            await _unitOfWork.SaveAsync();
            TempData["Success"] = "Lote deletado com sucesso.";
            return Json(new { success = true, message = "Deletado com sucesso." });

        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> PlantationReport(int id)
        {
            try
            {

                var plantacao = (await _unitOfWork.Plantacao.GetAllAsync(includeProperties: "Semente,Lote")).Where(q => q.Id == id && q.Deletado == false).FirstOrDefault();

                if (plantacao == null)
                {
                    throw new ArgumentException("Plantação não encontrada.");
                }
                var Sementes = (await _unitOfWork.Semente.GetAllAsync(includeProperties: "Cultura,Fornecedor")).Where(q => q.Deletado == false);
                plantacao.Semente.Cultura = Sementes.Where(q => q.CulturaId == plantacao.Semente.CulturaId).FirstOrDefault().Cultura;
                var objList = new List<object>();
                var obj = new
                {
                    Nome = plantacao.Nome,
                    Cultura = plantacao.Semente.Cultura.Nome,
                    Semente = plantacao.Semente.Nome,
                    PoderGerminativo = plantacao.Semente.PoderGerminativo + "%",
                    Fornecedor = plantacao.Semente.Fornecedor.Nome,
                    Lote = plantacao.Lote.Nome,
                    AnoSafra = "Atual",
                    Espaçamento = plantacao.Semente.Cultura.EspacamentoEntreLinhas + " m",
                    Hectares = plantacao.Lote.Hectares,
                    MetragemLinear = string.Format("{0:0.00}", plantacao.MetragemLinear) + " m",
                    SementesPorMetroLinear = plantacao.SementesPorMetroLinear,
                    SementesNaPlantacao = plantacao.SementesTotal,
                    PesoMilSementes = plantacao.Semente.PesoMilSementesKg + "kg",
                    PesoSementes = plantacao.PesoTotalSementes + "kg",
                    PesoSaca = plantacao.Semente.PesoSacaKg + "kg",
                    QuantidadeSacas = string.Format("{0:0.00}", plantacao.QuantidadeDeSacas),
                    PrecoSaca = "R$" + plantacao.Semente.CustoSaca,
                    CustoPorHectare = "R$" + plantacao.CustoPorHectare,
                    CustoPlantacao = "R$" + plantacao.CustoTotalPlantacao,
                };
                objList.Add(obj);

                string headerLine = string.Join(";", objList[0].GetType().GetProperties().Select(p => p.Name));

                var dataLines = from plant in objList
                                let dataLine = string.Join(";", plant.GetType()
                                .GetProperties().Select(p => p.GetValue(plant)))
                                select dataLine;

                var csvData = new List<string>();
                csvData.Add(headerLine);
                csvData.AddRange(dataLines);

                string csvFilePath = @"D:\relatorioPlantacao" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ".csv";
                System.IO.File.WriteAllLines(csvFilePath, csvData);

                TempData["Success"] = "Relatório gerado com sucesso.";
                return Json(new { success = true, message = "Sucesso" });
            }
            catch (ArgumentException e)
            {
                TempData["Error"] = "Erro ao gerar Relatório: " + e.Message;
                return Json(new { success = false, message = "Erro ao gerar relatório: " + e.Message });
            }
            catch (Exception e)
            {
                TempData["Error"] = "Erro ao gerar Relatório ";
                return Json(new { success = false, message = "Erro" });
            }
        }
    }
}
