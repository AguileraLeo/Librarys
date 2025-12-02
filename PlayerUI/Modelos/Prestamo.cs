using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerUI.Modelos
{
    public class Prestamo
    {
        // Propiedades principales
        public int Id { get; set; }

        // Relaciones
        public int UsuarioId { get; set; }
        public string UsuarioNombre { get; set; }
        public string UsuarioEmail { get; set; }

        public int LibroId { get; set; }
        public string LibroTitulo { get; set; }
        public string LibroAutor { get; set; }

        // Fechas
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucionEsperada { get; set; }
        public DateTime? FechaDevolucionReal { get; set; }

        // Estado
        public string Estado { get; set; } // "Activo", "Devuelto", "Vencido"
        public decimal MultasAcumulada { get; set; }

        // Información calculada
        public int DiasRestantes
        {
            get
            {
                if (Estado == "Devuelto")
                    return 0;

                var dias = (FechaDevolucionEsperada - DateTime.Now).Days;
                return dias > 0 ? dias : 0;
            }
        }

        public int DiasRetraso
        {
            get
            {
                if (Estado == "Devuelto" && FechaDevolucionReal.HasValue)
                {
                    var retraso = (FechaDevolucionReal.Value - FechaDevolucionEsperada).Days;
                    return retraso > 0 ? retraso : 0;
                }
                else if (Estado == "Vencido" || (Estado == "Activo" && FechaDevolucionEsperada < DateTime.Now))
                {
                    var retraso = (DateTime.Now - FechaDevolucionEsperada).Days;
                    return retraso > 0 ? retraso : 0;
                }
                return 0;
            }
        }

        public decimal MultaCalculada
        {
            get
            {
                // $50 por día de retraso
                return DiasRetraso * 50;
            }
        }

        public string EstadoVisual
        {
            get
            {
                if (Estado == "Activo")
                {
                    if (FechaDevolucionEsperada < DateTime.Now)
                        return "Vencido";
                    else if (DiasRestantes <= 2)
                        return "Por vencer";
                    else
                        return "Activo";
                }
                return Estado;
            }
        }

        // Constructor vacío
        public Prestamo() { }

        // Constructor para nuevo préstamo
        public Prestamo(int usuarioId, int libroId, int diasPrestamo = 14)
        {
            UsuarioId = usuarioId;
            LibroId = libroId;
            FechaPrestamo = DateTime.Now;
            FechaDevolucionEsperada = FechaPrestamo.AddDays(diasPrestamo);
            Estado = "Activo";
            MultasAcumulada = 0;
        }

        // Método para verificar si está vencido
        public bool EstaVencido()
        {
            return Estado == "Vencido" || (Estado == "Activo" && FechaDevolucionEsperada < DateTime.Now);
        }

        // Método para verificar si puede ser renovado
        public bool PuedeRenovar()
        {
            return Estado == "Activo" && !EstaVencido() && MultasAcumulada == 0;
        }
    }
}
