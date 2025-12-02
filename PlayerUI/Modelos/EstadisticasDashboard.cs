using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerUI.Modelos
{
    //Opcional, sugerida por IA para mostrar estadísticas en el dashboard
    public class EstadisticasDashboard
    {
        // Totales
        public int TotalUsuarios { get; set; }
        public int TotalLibros { get; set; }
        public int PrestamosActivos { get; set; }
        public int TotalPrestamos { get; set; }
        public decimal MultasPendientes { get; set; }
        public decimal TasaDevolucionPorcentaje { get; set; }

        // Método para obtener porcentaje formateado
        public string TasaDevolucionFormateada
        {
            get { return $"{TasaDevolucionPorcentaje:F2}%"; }
        }

        // Método para obtener multas formateadas
        public string MultasPendientesFormateada
        {
            get { return MultasPendientes.ToString("C"); }
        }
    }
}
