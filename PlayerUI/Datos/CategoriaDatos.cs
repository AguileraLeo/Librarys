using System;
using System.Data;
using System.Windows.Forms;

namespace PlayerUI.Datos
{
    public class CategoriaDatos
    {
        /// Obtiene todas las categorías
        public DataTable ListarTodas()
        {
            try
            {
                return ConexionDB.EjecutarConsulta("sp_ObtenerCategorias", null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener categorías: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }
    }
}