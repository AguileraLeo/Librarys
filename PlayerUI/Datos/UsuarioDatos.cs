using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using PlayerUI.Modelos;

namespace PlayerUI.Datos
{
    public class UsuarioDatos
    {
        /// Valida el login de un usuario
        public DataTable ValidarLogin(string email, string password)
        {
            try
            {
                SqlParameter[] parametros = {
                    new SqlParameter("@email", email),
                    new SqlParameter("@password", password)
                };

                return ConexionDB.EjecutarConsulta("sp_ValidarLogin", parametros);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al validar login: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }
        /// Crea un nuevo usuario
        public bool Crear(Usuario usuario)
        {
            try
            {
                SqlParameter[] parametros = {
                    new SqlParameter("@nombre", usuario.Nombre),
                    new SqlParameter("@email", usuario.Email),
                    new SqlParameter("@password", usuario.Password),
                    new SqlParameter("@tipo", usuario.Tipo)
                };

                ConexionDB.EjecutarComando("sp_CrearUsuario", parametros);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear usuario: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// Obtiene todos los usuarios
        public DataTable ListarTodos()
        {
            try
            {
                return ConexionDB.EjecutarConsulta("sp_ObtenerUsuarios", null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al listar usuarios: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }
        public bool Actualizar(Usuario usuario)
        {
            try
            {
                SqlParameter[] parametros = {
            new SqlParameter("@usuarioID", usuario.Id),
            new SqlParameter("@nombre", usuario.Nombre),
            new SqlParameter("@email", usuario.Email),
            new SqlParameter("@tipo", usuario.Tipo)
        };

                ConexionDB.EjecutarComando("sp_ActualizarUsuario", parametros);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar usuario: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}