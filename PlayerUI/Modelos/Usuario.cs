using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerUI.Modelos
{
    public class Usuario
    {
        // Propiedades
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // Hash
        public string Tipo { get; set; } // "Admin" o "Usuario"
        public DateTime FechaRegistro { get; set; }

        // Constructor vacío
        public Usuario() { }

        // Constructor con parámetros
        public Usuario(string nombre, string email, string password, string tipo = "Usuario")
        {
            Nombre = nombre;
            Email = email;
            Password = password;
            Tipo = tipo;
            FechaRegistro = DateTime.Now;
        }

        // Método para validar formato de email
        public bool EmailEsValido()
        {
            if (string.IsNullOrWhiteSpace(Email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(Email);
                return addr.Address == Email;
            }
            catch
            {
                return false;
            }
        }

        // Método para verificar si es admin
        public bool EsAdmin()
        {
            return Tipo == "Admin";
        }
    }
}
