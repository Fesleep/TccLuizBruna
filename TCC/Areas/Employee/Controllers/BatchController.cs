using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class BatchController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BatchController(IUnitOfWork unityOfWork)
        {
            _unitOfWork = unityOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            LoteVM loteVM = new LoteVM()
            {
                Lote = new Lote()
            };
            if (id == null)
            {
                //this is for create
                return View(LoteVMMapping.AsLoteVMDTO(loteVM));
            }
            //this is for edit
            loteVM.Lote = await _unitOfWork.Lote.GetAsync(id.GetValueOrDefault());
            if (loteVM.Lote == null)
            {
                return NotFound();
            }
            return View(LoteVMMapping.AsLoteVMDTO(loteVM));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(LoteVMDTO loteVMDTO)
        {
            LoteVM loteVM = LoteVMMapping.AsLoteVM(loteVMDTO);

            try
            {
                if (ModelState.IsValid)
                {
                    if (loteVM.Lote.Id == 0)
                    {
                        await _unitOfWork.Lote.CustomAddAsync(loteVM.Lote);

                    }
                    else
                    {
                        _unitOfWork.Lote.Update(loteVM.Lote);
                    }
                    await _unitOfWork.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {

            }
            return View(LoteVMMapping.AsLoteVMDTO(loteVM));
        }


        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = (await _unitOfWork.Lote.GetAllAsync()).Where(q => q.Deletado == false);
            return Json(new { data = allObj });
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _unitOfWork.Lote.GetAsync(id);
            if (objFromDb == null)
            {
                TempData["Error"] = "Erro ao deletar Lote";
                return Json(new { sucess = false, message = "Erro ao deletar" });
            }
            await _unitOfWork.Lote.RemoveAsync(objFromDb);
            await _unitOfWork.SaveAsync();

            TempData["Success"] = "Lote deletado com sucesso!";
            return Json(new { sucess = true, message = "Deletado com sucesso" });
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> BatchReport(int id)
        {
            try
            {

                var plantacoes = (await _unitOfWork.Plantacao.GetAllAsync(includeProperties: "Semente,Lote")).Where(q => q.LoteId == id && q.Deletado == false).OrderByDescending(q => q.DataCriacao).ToList();

                if (plantacoes.Count < 3)
                {
                    throw new ArgumentException("É necessário já terem se passado 3 anos de safra nesse lote.");
                }
                plantacoes = plantacoes.Take(3).ToList();

                var Sementes = (await _unitOfWork.Semente.GetAllAsync(includeProperties: "Cultura,Fornecedor")).Where(q => q.Deletado == false);
                var objList = new List<object>();
                int anoSafra = 0;
                foreach (var p in plantacoes)
                {
                    p.Semente.Cultura = Sementes.Where(q => q.CulturaId == p.Semente.CulturaId).FirstOrDefault().Cultura;
                    var obj = new
                    {
                        Nome = p.Nome,
                        Cultura = p.Semente.Cultura.Nome,
                        Semente = p.Semente.Nome,
                        PoderGerminativo = p.Semente.PoderGerminativo + "%",
                        Fornecedor = p.Semente.Fornecedor.Nome,
                        Lote = p.Lote.Nome,
                        AnoSafra = p.Ativo ? "Ano Safra 03" : anoSafra == 1 ? "Ano Safra 02" : "Ano Safra 01",
                        Espaçamento = p.Semente.Cultura.EspacamentoEntreLinhas + " m",
                        Hectares = p.Lote.Hectares,
                        MetragemLinear = string.Format("{0:0.00}", p.MetragemLinear) + " m",
                        SementesPorMetroLinear = p.SementesPorMetroLinear,
                        SementesNaPlantacao = p.SementesTotal,
                        PesoMilSementes = p.Semente.PesoMilSementesKg + "kg",
                        PesoSementes = p.PesoTotalSementes + "kg",
                        PesoSaca = p.Semente.PesoSacaKg + "kg",
                        QuantidadeSacas = string.Format("{0:0.00}", p.QuantidadeDeSacas),
                        PrecoSaca = "R$" + p.Semente.CustoSaca,
                        CustoPorHectare = "R$" + p.CustoPorHectare,
                        CustoPlantacao = "R$" + p.CustoTotalPlantacao,
                    };
                    objList.Add(obj);
                    anoSafra++;
                }
                string headerLine = string.Join(";", objList[0].GetType().GetProperties().Select(p => p.Name));

                var dataLines = from plant in objList
                                let dataLine = string.Join(";", plant.GetType()
                                .GetProperties().Select(p => p.GetValue(plant)))
                                select dataLine;

                var csvData = new List<string>();
                csvData.Add(headerLine);
                csvData.AddRange(dataLines);

                string csvFilePath = @"D:\relatorioLote" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss")+".csv";
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
