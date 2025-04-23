using System;
using System.ComponentModel.DataAnnotations;

namespace EdadBiologicaCalculadora.Models
{
    public class CalculadoraEdadBiologica
    {
        public CalculadoraEdadBiologica()
        {
            Nombre = string.Empty;
            EdadCronologica = 0;
            DuermeSieteHoras = false;
            HaceEjercicio = false;
            Fuma = false;
            ConsumeFrutasVerduras = false;
            TieneEstres = false;
            EdadBiologica = 0;
            DiferenciaEdad = 0;
            Retroalimentacion = string.Empty;
            FechaCalculo = DateTime.Now;
        }

        [Required(ErrorMessage = "Por favor ingresa tu nombre")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Por favor ingresa tu edad")]
        [Range(1, 120, ErrorMessage = "La edad debe estar entre 1 y 120 años")]
        [Display(Name = "Edad cronológica")]
        public int EdadCronologica { get; set; }

        [Display(Name = "¿Duermes al menos 7 horas al día?")]
        public bool DuermeSieteHoras { get; set; }

        [Display(Name = "¿Haces ejercicio regularmente?")]
        public bool HaceEjercicio { get; set; }

        [Display(Name = "¿Fumas?")]
        public bool Fuma { get; set; }

        [Display(Name = "¿Consumes frutas y verduras a diario?")]
        public bool ConsumeFrutasVerduras { get; set; }

        [Display(Name = "¿Sufres de estrés frecuentemente?")]
        public bool TieneEstres { get; set; }

        public int EdadBiologica { get; set; }
        public int DiferenciaEdad { get; set; }
        public string Retroalimentacion { get; set; }
        public DateTime FechaCalculo { get; set; }

        public void CalcularEdadBiologica()
        {
            // Check if at least one option is selected
            if (!DuermeSieteHoras && !HaceEjercicio && !Fuma && !ConsumeFrutasVerduras && !TieneEstres)
            {
                throw new InvalidOperationException("Debes seleccionar al menos una opción para calcular tu edad biológica.");
            }

            EdadBiologica = EdadCronologica;
            var factores = 0;

            // Good habits reduce age moderately
            if (DuermeSieteHoras) factores -= 1;      // Sleep: -1 year
            if (HaceEjercicio) factores -= 1;         // Exercise: -1 year
            if (ConsumeFrutasVerduras) factores -= 1; // Good nutrition: -1 year

            // Bad habits increase age moderately
            if (Fuma) factores += 2;                  // Smoking: +2 years
            if (TieneEstres) factores += 1;           // Stress: +1 year

            // Each factor now only affects 1 year instead of 2
            EdadBiologica += factores;

            // Ensure biological age doesn't go too low (maximum reduction of 15%)
            int minEdad = (int)(EdadCronologica * 0.85);
            if (EdadBiologica < minEdad)
                EdadBiologica = minEdad;

            DiferenciaEdad = EdadBiologica - EdadCronologica;

            // Update feedback messages for more moderate differences
            if (DiferenciaEdad <= -3)
                Retroalimentacion = "¡Excelente! Tus hábitos saludables te mantienen más joven.";
            else if (DiferenciaEdad < 0)
                Retroalimentacion = "Buen trabajo. Tus hábitos te mantienen algo más joven.";
            else if (DiferenciaEdad == 0)
                Retroalimentacion = "Tus hábitos mantienen tu edad biológica igual a tu edad cronológica.";
            else if (DiferenciaEdad <= 2)
                Retroalimentacion = "Atención: Algunos hábitos están acelerando levemente tu envejecimiento.";
            else
                Retroalimentacion = "¡Alerta! Tus hábitos están acelerando tu envejecimiento.";

            FechaCalculo = DateTime.Now;
        }
    }
}
