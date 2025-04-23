using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EdadBiologicaCalculadora.Models;
using EdadBiologicaCalculadora.Services;
using System.Collections.Generic;

namespace EdadBiologicaCalculadora.Pages
{
    public class HistorialModel : PageModel
    {
        private readonly HistorialService _historialService;
        public List<CalculadoraEdadBiologica> Historial { get; set; } = new();

        public HistorialModel(HistorialService historialService)
        {
            _historialService = historialService;
        }

        public void OnGet()
        {
            Historial = _historialService.ObtenerHistorial();
        }
    }
}
