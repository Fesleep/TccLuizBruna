using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TCC.Utility;

namespace TCC.Models.ViewModels
{
    public class OverviewVM
    {
        public MainCoordinates? MainCoordinates { get; set; }
        public List<PlantacaoLote>? PlantacoesLote { get; set; }
        public List<Plantacao>? PlantacoesAtivas { get; set; }

        public OverviewVM()
        {
            PlantacoesLote = new List<PlantacaoLote>();
            PlantacoesAtivas = new List<Plantacao>();
        }

    }

    public class PlantacaoLote
    {
        public Lote? Lote { get; set; }
        public List<Plantacao>? Plantacoes { get; set; }

        public PlantacaoLote()
        {
            Plantacoes = new List<Plantacao>();
        }
    }
}