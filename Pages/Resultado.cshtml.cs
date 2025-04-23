using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EdadBiologicaCalculadora.Models;
using EdadBiologicaCalculadora.Services;

namespace EdadBiologicaCalculadora.Pages
{
    public class ResultadoModel : PageModel
    {
        private readonly HistorialService _historialService;
        public CalculadoraEdadBiologica? Calculadora { get; set; }

        public ResultadoModel(HistorialService historialService)
        {
            _historialService = historialService;
        }

        public IActionResult OnGet()
        {
            // Get the most recent calculation
            var historial = _historialService.ObtenerHistorial();
            if (historial.Count > 0)
            {
                Calculadora = historial[0]; // Get most recent
                return Page();
            }

            return RedirectToPage("/EdadBiologica");
        }
    }
}
