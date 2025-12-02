using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using PlayerUI.Datos;
using PlayerUI.Modelos;

namespace PlayerUI.Negocio
{
    /// Maneja toda la lógica de negocio relacionada con Libros
    public class LibroNegocio
    {
        private LibroDatos datos = new LibroDatos();

        // =============================================
        // MÉTODOS PARA OBTENER LIBROS (CON LÓGICA)
        // =============================================

        /// Obtiene todos los libros para mostrar en catálogo
        public List<Libro> ListarParaCatalogo()
        {
            try
            {
                DataTable dt = datos.ListarTodos();
                return ConvertirDataTableALibros(dt);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al listar libros para catálogo: {ex.Message}");
            }
        }

        /// Busca libros con filtros aplicados

        public List<Libro> Buscar(string criterio, int? categoriaId, bool soloDisponibles)
        {
            try
            {
                DataTable dt = datos.BuscarLibros(criterio, categoriaId, soloDisponibles);
                return ConvertirDataTableALibros(dt);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar libros: {ex.Message}");
            }
        }

        /// Obtiene libros disponibles para préstamo (con validaciones)
        public List<Libro> ListarDisponiblesParaPrestamo(int usuarioId)
        {
            try
            {
                // Obtener libros disponibles
                DataTable dt = datos.ListarDisponibles();
                var libros = ConvertirDataTableALibros(dt);
                return libros;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener libros disponibles: {ex.Message}");
            }
        }

        // =============================================
        // MÉTODOS CRUD CON VALIDACIONES DE NEGOCIO
        // =============================================

        /// Crea un nuevo libro con validaciones de negocio
        public bool Crear(Libro libro, out string mensajeError)
        {
            mensajeError = string.Empty;

            try
            {
                // 1. Validar datos del libro (reglas de negocio)
                string validacion = libro.Validar();
                if (!string.IsNullOrEmpty(validacion))
                {
                    mensajeError = validacion;
                    return false;
                }

                // 2. Validar que el ISBN sea único (regla de negocio)
                // Nota: Esta validación también está en el SP, pero la duplicamos aquí
                // para dar feedback inmediato al usuario
                if (ISBNExisteEnMemoria(libro.ISBN))
                {
                    mensajeError = "El ISBN ya existe en el sistema";
                    return false;
                }

                // 3. Aplicar reglas de negocio para valores por defecto
                if (libro.StockDisponible == 0 && libro.StockTotal > 0)
                {
                    libro.StockDisponible = libro.StockTotal;
                }

                // 4. Llamar a la capa de datos
                bool resultado = datos.Crear(libro);

                if (resultado)
                {
                    mensajeError = "Libro creado exitosamente";
                    return true;
                }
                else
                {
                    mensajeError = "Error al guardar el libro en la base de datos";
                    return false;
                }
            }
            catch (Exception ex)
            {
                mensajeError = $"Error inesperado: {ex.Message}";
                return false;
            }
        }

        /// Actualiza un libro existente con validaciones
        public bool Actualizar(Libro libro, out string mensajeError)
        {
            mensajeError = string.Empty;

            try
            {
                // 1. Validar datos del libro
                string validacion = libro.Validar();
                if (!string.IsNullOrEmpty(validacion))
                {
                    mensajeError = validacion;
                    return false;
                }

                // 2. Verificar que el libro existe
                DataTable dt = datos.ObtenerPorId(libro.Id);
                if (dt.Rows.Count == 0)
                {
                    mensajeError = "El libro no existe en el sistema";
                    return false;
                }

                // 3. Obtener información actual del libro
                int stockActual = Convert.ToInt32(dt.Rows[0]["stockDisponible"]);
                int stockTotalActual = Convert.ToInt32(dt.Rows[0]["stockTotal"]);

                // 4. No reducir stock disponible por debajo de 0
                int stockPrestado = stockTotalActual - stockActual;
                if (libro.StockTotal < stockPrestado)
                {
                    mensajeError = $"No se puede reducir el stock total a menos de {stockPrestado} (libros prestados actualmente)";
                    return false;
                }

                // 5. Calcular nuevo stock disponible
                libro.StockDisponible = libro.StockTotal - stockPrestado;

                // 6. Llamar a la capa de datos
                bool resultado = datos.Actualizar(libro);

                if (resultado)
                {
                    mensajeError = "Libro actualizado exitosamente";
                    return true;
                }
                else
                {
                    mensajeError = "Error al actualizar el libro";
                    return false;
                }
            }
            catch (Exception ex)
            {
                mensajeError = $"Error inesperado: {ex.Message}";
                return false;
            }
        }

        /// Elimina un libro con validaciones de negocio
        public bool Eliminar(int libroId, out string mensajeError)
        {
            mensajeError = string.Empty;

            try
            {
                // 1. Verificar que el libro existe
                DataTable dt = datos.ObtenerPorId(libroId);
                if (dt.Rows.Count == 0)
                {
                    mensajeError = "El libro no existe";
                    return false;
                }

                // 2. Validar regla de negocio: no eliminar libros con stock prestado
                int stockDisponible = Convert.ToInt32(dt.Rows[0]["stockDisponible"]);
                int stockTotal = Convert.ToInt32(dt.Rows[0]["stockTotal"]);
                int stockPrestado = stockTotal - stockDisponible;

                if (stockPrestado > 0)
                {
                    mensajeError = $"No se puede eliminar el libro porque tiene {stockPrestado} ejemplares prestados";
                    return false;
                }

                // 3. Llamar a la capa de datos
                bool resultado = datos.Eliminar(libroId);

                if (resultado)
                {
                    mensajeError = "Libro eliminado exitosamente";
                    return true;
                }
                else
                {
                    mensajeError = "Error al eliminar el libro";
                    return false;
                }
            }
            catch (Exception ex)
            {
                mensajeError = $"Error inesperado: {ex.Message}";
                return false;
            }
        }

        // =============================================
        // MÉTODOS PARA ESTADÍSTICAS Y REPORTES
        // =============================================

        /// Obtiene los libros más prestados para el dashboard
        public List<dynamic> ObtenerTopLibrosMasPrestados(int cantidad = 10)
        {
            try
            {
                DataTable dt = datos.ObtenerTopLibrosMasPrestados(cantidad);

                var resultado = new List<dynamic>();
                foreach (DataRow row in dt.Rows)
                {
                    resultado.Add(new
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Titulo = row["titulo"].ToString(),
                        Autor = row["autor"].ToString(),
                        Categoria = row["categoria"].ToString(),
                        TotalPrestamos = Convert.ToInt32(row["totalPrestamos"]),
                        StockDisponible = Convert.ToInt32(row["stockDisponible"])
                    });
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener libros más prestados: {ex.Message}");
            }
        }

        /// Obtiene estadísticas para el dashboard
        public dynamic ObtenerEstadisticasDashboard()
        {
            try
            {
                DataTable dt = datos.ObtenerEstadisticasDashboard();

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    return new
                    {
                        TotalUsuarios = Convert.ToInt32(row["totalUsuarios"]),
                        TotalLibros = Convert.ToInt32(row["totalLibros"]),
                        PrestamosActivos = Convert.ToInt32(row["prestamosActivos"]),
                        TotalPrestamos = Convert.ToInt32(row["totalPrestamos"]),
                        MultasPendientes = Convert.ToDecimal(row["multasPendientes"]),
                        TasaDevolucion = Convert.ToDecimal(row["tasaDevolucionPorcentaje"])
                    };
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener estadísticas: {ex.Message}");
            }
        }

        // =============================================
        // MÉTODOS PRIVADOS DE AYUDA
        // =============================================

        /// Convierte DataTable a List<Libro> (transformación de datos)
        private List<Libro> ConvertirDataTableALibros(DataTable dt)
        {
            var libros = new List<Libro>();

            foreach (DataRow row in dt.Rows)
            {
                var libro = new Libro
                {
                    Id = Convert.ToInt32(row["id"]),
                    Titulo = row["titulo"].ToString(),
                    Autor = row["autor"].ToString(),
                    ISBN = row["isbn"].ToString(),
                    Editorial = row["editorial"].ToString(),
                    CategoriaId = Convert.ToInt32(row["categoriaID"]),
                    CategoriaNombre = row["categoria"].ToString(),
                    TipoRecurso = row["tipoRecurso"].ToString(),
                    StockDisponible = Convert.ToInt32(row["stockDisponible"]),
                    StockTotal = Convert.ToInt32(row["stockTotal"])
                };

                libros.Add(libro);
            }

            return libros;
        }

        /// Valida si un ISBN ya existe 
        private bool ISBNExisteEnMemoria(string isbn)
        {
            // Esto es un ejemplo simple. En una app real,
            // podrías cachear los ISBNs en memoria para validación rápida
            var libros = ListarParaCatalogo();
            return libros.Any(l => l.ISBN == isbn);
        }
    }
}