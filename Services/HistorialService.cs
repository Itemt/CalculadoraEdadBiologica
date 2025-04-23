using System;
using System.Collections.Generic;
using System.Linq;
using EdadBiologicaCalculadora.Models;

namespace EdadBiologicaCalculadora.Services
{
    public class HistorialService
    {
        private readonly List<CalculadoraEdadBiologica> _historial = new();

        public void AgregarCalculo(CalculadoraEdadBiologica calculo)
        {
            var copia = new CalculadoraEdadBiologica
            {
                Nombre = calculo.Nombre,
                EdadCronologica = calculo.EdadCronologica,
                DuermeSieteHoras = calculo.DuermeSieteHoras,
                HaceEjercicio = calculo.HaceEjercicio,
                Fuma = calculo.Fuma,
                ConsumeFrutasVerduras = calculo.ConsumeFrutasVerduras,
                TieneEstres = calculo.TieneEstres,
                EdadBiologica = calculo.EdadBiologica,
                DiferenciaEdad = calculo.DiferenciaEdad,
                Retroalimentacion = calculo.Retroalimentacion,
                FechaCalculo = DateTime.Now
            };
            
            _historial.Add(copia);
        }

        public List<CalculadoraEdadBiologica> ObtenerHistorial()
        {
            return _historial.OrderByDescending(c => c.FechaCalculo).ToList();
        }
    }
}
