using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerUI.Modelos
{
    public class Libro
    {
        // Propiedades principales
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public string Editorial { get; set; }

        // Relaciones
        public int CategoriaId { get; set; }
        public string CategoriaNombre { get; set; } // Para mostrar en DataGridView

        // Stock
        public string TipoRecurso { get; set; } // "Digital" o "Fisico"
        public int StockDisponible { get; set; }
        public int StockTotal { get; set; }

        // Información adicional
        public DateTime? FechaCreacion { get; set; }
        public int TotalPrestamos { get; set; } // Para estadísticas

        // Constructor vacío
        public Libro() { }

        // Constructor con parámetros básicos
        public Libro(string titulo, string autor, string isbn, string editorial, int categoriaId)
        {
            Titulo = titulo;
            Autor = autor;
            ISBN = isbn;
            Editorial = editorial;
            CategoriaId = categoriaId;
            TipoRecurso = "Digital"; // Por defecto
            StockDisponible = 1;
            StockTotal = 1;
            FechaCreacion = DateTime.Now;
        }

        // Método para validar datos básicos
        public string Validar()
        {
            if (string.IsNullOrWhiteSpace(Titulo))
                return "El título es obligatorio";

            if (string.IsNullOrWhiteSpace(Autor))
                return "El autor es obligatorio";

            if (string.IsNullOrWhiteSpace(ISBN))
                return "El ISBN es obligatorio";

            if (StockDisponible < 0)
                return "El stock disponible no puede ser negativo";

            if (StockTotal < 0)
                return "El stock total no puede ser negativo";

            if (StockDisponible > StockTotal)
                return "El stock disponible no puede ser mayor al stock total";

            return null; // Sin errores
        }

        // Método para verificar disponibilidad
        public bool EstaDisponible()
        {
            return StockDisponible > 0;
        }

        // ToString para mostrar información básica
        public override string ToString()
        {
            return $"{Titulo} - {Autor} ({StockDisponible}/{StockTotal} disponibles)";
        }
    }
}