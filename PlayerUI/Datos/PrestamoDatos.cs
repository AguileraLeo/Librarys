using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PlayerUI.Datos
{
    public class PrestamoDatos
    {
        /// Obtiene préstamos de un usuario
        public DataTable ObtenerPorUsuario(int usuarioId, bool soloActivos = false)
        {
            try
            {
                SqlParameter[] parametros = {
                    new SqlParameter("@usuarioID", usuarioId),
                    new SqlParameter("@soloActivos", soloActivos ? 1 : 0)
                };

                return ConexionDB.EjecutarConsulta("sp_ObtenerPrestamosUsuario", parametros);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener préstamos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// Renueva un préstamo
        public bool Renovar(int prestamoId, int diasExtension = 7)
        {
            try
            {
                SqlParameter[] parametros = {
                    new SqlParameter("@prestamoID", prestamoId),
                    new SqlParameter("@diasExtension", diasExtension)
                };

                ConexionDB.EjecutarComando("sp_RenovarPrestamo", parametros);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al renovar préstamo: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public DataTable ObtenerTodos(bool soloActivos = false)
        {
            try
            {
                SqlParameter[] parametros = {
            new SqlParameter("@soloActivos", soloActivos ? 1 : 0)
        };

                return ConexionDB.EjecutarConsulta("sp_ObtenerTodosPrestamos", parametros);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener todos los préstamos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }
    }

}