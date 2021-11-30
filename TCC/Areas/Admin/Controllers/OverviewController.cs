using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TCC.DataAccess.Repository.IRepository;
using TCC.Models;
using TCC.Models.ViewModels;
using TCC.Utility;

namespace TCC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class OverviewController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly MainCoordinates _mainCoordinates;

        public OverviewController(IUnitOfWork unityOfWork, IWebHostEnvironment hostEnvironment, IOptions<MainCoordinates> mainCoordinates)
        {
            _unitOfWork = unityOfWork;
            _hostEnvironment = hostEnvironment;
            _mainCoordinates = mainCoordinates.Value;
        }

        public async Task<IActionResult> Index()
        {
            OverviewVM overviewVM = new OverviewVM();


            var lotes = (await _unitOfWork.Lote.GetAllAsync()).Where(q => q.Deletado == false);
            var plantacoes = (await _unitOfWork.Plantacao.GetAllAsync()).Where(q => q.Deletado == false);
            var plantacoesAtivas = plantacoes.Where(q => q.Ativo == true).ToList();

            overviewVM.MainCoordinates = _mainCoordinates;
            overviewVM.PlantacoesAtivas = plantacoesAtivas;

            foreach (var l in lotes)
            {
                overviewVM.PlantacoesLote.Add(new PlantacaoLote()
                {
                    Lote = l,
                    Plantacoes = plantacoes.Where(q => q.LoteId == l.Id).OrderByDescending(q => q.DataCriacao).Take(3).ToList()
                });
            }

            var Sementes = (await _unitOfWork.Semente.GetAllAsync(includeProperties: "Cultura")).Where(q => q.Deletado == false);

            foreach (var p in overviewVM.PlantacoesAtivas)
            {
                p.Semente.Cultura = Sementes.Where(q => q.CulturaId == p.Semente.CulturaId).FirstOrDefault().Cultura;
            }

            return View(overviewVM);
        }

    }
}
