using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerUI.Modelos
{
    public class Multa
    {
        // Propiedades
        public int Id { get; set; }
        public int PrestamoId { get; set; }

        // Información del préstamo (para mostrar)
        public string UsuarioNombre { get; set; }
        public string LibroTitulo { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucionEsperada { get; set; }

        // Información de la multa
        public decimal Monto { get; set; }
        public string Estado { get; set; } // "Pendiente", "Pagada"
        public DateTime? FechaPago { get; set; }

        // Información calculada
        public int DiasRetraso
        {
            get
            {
                var fechaBase = FechaPago ?? DateTime.Now;
                var retraso = (fechaBase - FechaDevolucionEsperada).Days;
                return retraso > 0 ? retraso : 0;
            }
        }

        public bool EstaPagada
        {
            get { return Estado == "Pagada"; }
        }

        // Constructor vacío
        public Multa() { }

        // Constructor con parámetros
        public Multa(int prestamoId, decimal monto)
        {
            PrestamoId = prestamoId;
            Monto = monto;
            Estado = "Pendiente";
        }

        // Método para pagar la multa
        public void Pagar()
        {
            Estado = "Pagada";
            FechaPago = DateTime.Now;
        }
    }
}
