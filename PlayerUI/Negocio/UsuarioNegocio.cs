using System;
using System.Data;
using System.Text.RegularExpressions;
using PlayerUI.Datos;
using PlayerUI.Modelos;

namespace PlayerUI.Negocio
{
    public class UsuarioNegocio
    {
        private UsuarioDatos datos = new UsuarioDatos();

        /// Valida el login de un usuario
        public Usuario ValidarLogin(string email, string password, out string mensajeError)
        {
            mensajeError = string.Empty;

            try
            {
                // 1. Validar formato de email
                if (!ValidarEmail(email))
                {
                    mensajeError = "Formato de email inválido";
                    return null;
                }

                // 2. Validar que la contraseña no esté vacía
                if (string.IsNullOrWhiteSpace(password))
                {
                    mensajeError = "La contraseña es requerida";
                    return null;
                }

                // 3. Llamar a la capa de datos
                DataTable dt = datos.ValidarLogin(email, password);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    return new Usuario
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Nombre = row["nombre"].ToString(),
                        Email = row["email"].ToString(),
                        Tipo = row["tipo"].ToString()
                    };
                }
                else
                {
                    mensajeError = "Email o contraseña incorrectos";
                    return null;
                }
            }
            catch (Exception ex)
            {
                mensajeError = $"Error al validar login: {ex.Message}";
                return null;
            }
        }

        private bool ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
    }
}