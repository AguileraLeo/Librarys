using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using PlayerUI.Modelos;

namespace PlayerUI.Datos
{

    /// Maneja todas las operaciones de base de datos para Libros
    public class LibroDatos
    {
        // =============================================
        // MÉTODOS PARA CONSULTAS (SELECT)
        // =============================================

        /// Busca libros con filtros 
        public DataTable BuscarLibros(string criterio = null, int? categoriaId = null, bool soloDisponibles = false)
        {
            try
            {
                SqlParameter[] parametros = {
                    new SqlParameter("@criterio", (object)criterio ?? DBNull.Value),
                    new SqlParameter("@categoriaID", (object)categoriaId ?? DBNull.Value),
                    new SqlParameter("@soloDisponibles", soloDisponibles ? 1 : 0)
                };

                return ConexionDB.EjecutarConsulta("sp_BuscarLibros", parametros);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar libros: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// Obtiene un libro por su ID 
        public DataTable ObtenerPorId(int id)
        {
            try
            {
                SqlParameter[] parametros = {
                    new SqlParameter("@libroID", id)
                };

                return ConexionDB.EjecutarConsulta("sp_ObtenerLibroPorID", parametros);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener libro: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// Obtiene todos los libros 
        public DataTable ListarTodos()
        {
            try
            {
                return BuscarLibros(null, null, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al listar libros: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// Obtiene libros disponibles 
        public DataTable ListarDisponibles()
        {
            try
            {
                return BuscarLibros(null, null, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener libros disponibles: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        // =============================================
        // MÉTODOS PARA CRUD (INSERT, UPDATE, DELETE)
        // =============================================

        /// Crea un nuevo libro 
        public bool Crear(Libro libro)
        {
            try
            {
                SqlParameter[] parametros = {
                    new SqlParameter("@titulo", libro.Titulo),
                    new SqlParameter("@autor", libro.Autor),
                    new SqlParameter("@isbn", libro.ISBN),
                    new SqlParameter("@editorial", libro.Editorial),
                    new SqlParameter("@categoriaID", libro.CategoriaId),
                    new SqlParameter("@tipoRecurso", libro.TipoRecurso),
                    new SqlParameter("@stockTotal", libro.StockTotal)
                };

                ConexionDB.EjecutarComando("sp_CrearLibro", parametros);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear libro: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// Actualiza un libro existente 
        public bool Actualizar(Libro libro)
        {
            try
            {
                SqlParameter[] parametros = {
                    new SqlParameter("@libroID", libro.Id),
                    new SqlParameter("@titulo", libro.Titulo),
                    new SqlParameter("@autor", libro.Autor),
                    new SqlParameter("@isbn", libro.ISBN),
                    new SqlParameter("@editorial", libro.Editorial),
                    new SqlParameter("@categoriaID", libro.CategoriaId),
                    new SqlParameter("@tipoRecurso", libro.TipoRecurso),
                    new SqlParameter("@stockTotal", libro.StockTotal)
                };

                ConexionDB.EjecutarComando("sp_ActualizarLibro", parametros);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar libro: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// Elimina un libro por ID 
        public bool Eliminar(int id)
        {
            try
            {
                SqlParameter[] parametros = {
                    new SqlParameter("@libroID", id)
                };

                ConexionDB.EjecutarComando("sp_EliminarLibro", parametros);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar libro: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // =============================================
        // MÉTODOS PARA OPERACIONES DE PRÉSTAMOS
        // =============================================

        /// Realiza un préstamo de libro 
        public bool RealizarPrestamo(int usuarioId, int libroId, int diasPrestamo = 14)
        {
            try
            {
                SqlParameter[] parametros = {
                    new SqlParameter("@usuarioID", usuarioId),
                    new SqlParameter("@libroID", libroId),
                    new SqlParameter("@diasPrestamo", diasPrestamo)
                };

                ConexionDB.EjecutarComando("sp_RealizarPrestamo", parametros);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al realizar préstamo: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// Devuelve un libro prestado
        public bool DevolverLibro(int prestamoId)
        {
            try
            {
                SqlParameter[] parametros = {
                    new SqlParameter("@prestamoID", prestamoId)
                };

                ConexionDB.EjecutarComando("sp_DevolverLibro", parametros);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al devolver libro: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // =============================================
        // MÉTODOS PARA ESTADÍSTICAS Y REPORTES
        // =============================================

        /// Obtiene los libros más prestados

        public DataTable ObtenerTopLibrosMasPrestados(int cantidad = 10)
        {
            try
            {
                SqlParameter[] parametros = {
                    new SqlParameter("@cantidad", cantidad)
                };

                return ConexionDB.EjecutarConsulta("sp_ObtenerTopLibrosMasPrestados", parametros);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener libros más prestados: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// Obtiene estadísticas del dashboard 
        public DataTable ObtenerEstadisticasDashboard()
        {
            try
            {
                return ConexionDB.EjecutarConsulta("sp_ObtenerEstadisticasDashboard", null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener estadísticas: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// Obtiene distribución de préstamos por categoría 
        public DataTable ObtenerPrestamosPorCategoria()
        {
            try
            {
                return ConexionDB.EjecutarConsulta("sp_ObtenerPrestamosPorCategoria", null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener préstamos por categoría: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        // =============================================
        // MÉTODOS AUXILIARES
        // =============================================

        /// Verifica si un libro está disponible para préstamo

        public bool VerificarDisponibilidad(int libroId)
        {
            try
            {
                DataTable libro = ObtenerPorId(libroId);

                if (libro.Rows.Count > 0)
                {
                    int stockDisponible = Convert.ToInt32(libro.Rows[0]["stockDisponible"]);
                    return stockDisponible > 0;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar disponibilidad: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        /// Obtiene el stock disponible de un libro

        public int ObtenerStockDisponible(int libroId)
        {
            try
            {
                DataTable libro = ObtenerPorId(libroId);

                if (libro.Rows.Count > 0)
                {
                    return Convert.ToInt32(libro.Rows[0]["stockDisponible"]);
                }

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener stock: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
    }
}