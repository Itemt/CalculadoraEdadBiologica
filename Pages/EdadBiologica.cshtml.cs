using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EdadBiologicaCalculadora.Models;
using EdadBiologicaCalculadora.Services;
using System;
namespace EdadBiologicaCalculadora.Pages
{
    public class EdadBiologicaModel : PageModel
    {
        private readonly HistorialService _historialService;

        [BindProperty]
        public CalculadoraEdadBiologica Calculadora { get; set; } = new();

        public EdadBiologicaModel(HistorialService historialService)
        {
            _historialService = historialService;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            try
            {
                // Calculate biological age
                Calculadora.CalcularEdadBiologica();
                
                // Save to history
                _historialService.AgregarCalculo(Calculadora);
                
                // Redirect to results
                return RedirectToPage("/Resultado");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
        }
    }
}
