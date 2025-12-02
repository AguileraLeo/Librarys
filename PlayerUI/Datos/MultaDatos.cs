using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PlayerUI.Datos
{
    public class MultaDatos
    {
        public DataTable ObtenerPorUsuario(int usuarioId, bool soloPendientes = false)
        {
            try
            {
                SqlParameter[] parametros = {
                    new SqlParameter("@usuarioID", usuarioId),
                    new SqlParameter("@soloPendientes", soloPendientes ? 1 : 0)
                };

                return ConexionDB.EjecutarConsulta("sp_ObtenerMultasUsuario", parametros);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener multas del usuario: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        public DataTable ObtenerTodas(bool soloPendientes = false)
        {
            try
            {
                SqlParameter[] parametros = {
                    new SqlParameter("@soloPendientes", soloPendientes ? 1 : 0)
                };

                return ConexionDB.EjecutarConsulta("sp_ObtenerTodasMultas", parametros);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener todas las multas: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        public bool Pagar(int multaId)
        {
            try
            {
                SqlParameter[] parametros = {
                    new SqlParameter("@multaID", multaId)
                };

                ConexionDB.EjecutarComando("sp_PagarMulta", parametros);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al pagar multa: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}