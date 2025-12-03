using System;

namespace PlayerUI.Modelos
{
    /// <summary>
    /// Clase ESTÁTICA que guarda la información del usuario que está usando la aplicación
    /// Es como una "memoria" que recuerda quién inició sesión
    /// </summary>
    public static class SesionUsuario
    {
        // Propiedades del usuario logueado
        public static int UsuarioId { get; set; }
        public static string Nombre { get; set; }
        public static string Email { get; set; }
        public static string Tipo { get; set; } // "Admin" o "Usuario"

        // Para saber si hay alguien logueado
        public static bool EstaLogueado
        {
            get { return UsuarioId > 0; }
        }

        // Para saber si el usuario logueado es administrador
        public static bool EsAdmin
        {
            get { return Tipo == "Admin"; }
        }

        /// <summary>
        /// Inicia la sesión guardando los datos del usuario
        /// Se llama después de validar el login
        /// </summary>
        public static void IniciarSesion(Usuario usuario)
        {
            UsuarioId = usuario.Id;
            Nombre = usuario.Nombre;
            Email = usuario.Email;
            Tipo = usuario.Tipo;
        }

        /// <summary>
        /// Cierra la sesión limpiando todos los datos
        /// Se llama cuando el usuario hace logout
        /// </summary>
        public static void CerrarSesion()
        {
            UsuarioId = 0;
            Nombre = string.Empty;
            Email = string.Empty;
            Tipo = string.Empty;
        }

        /// <summary>
        /// Obtiene un saludo personalizado para mostrar en la interfaz
        /// </summary>
        public static string ObtenerSaludo()
        {
            if (!EstaLogueado)
                return "Bienvenido";

            string tipoUsuario = EsAdmin ? "Administrador" : "Usuario";
            return $"Hola, {Nombre} ({tipoUsuario})";
        }
    }
}
