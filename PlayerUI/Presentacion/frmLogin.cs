using System;
using System.Drawing;
using System.Windows.Forms;
using PlayerUI.Modelos;
using PlayerUI.Negocio;

namespace PlayerUI.Presentacion
{
    /// <summary>
    /// Formulario de inicio de sesión (Login)
    /// Permite a los usuarios acceder al sistema con email y contraseña
    /// </summary>
    public partial class frmLogin : Form
    {
        private UsuarioNegocio usuarioNegocio;

        public frmLogin()
        {
            InitializeComponent();
            usuarioNegocio = new UsuarioNegocio();

            // Configurar el TextBox de contraseña para que muestre asteriscos
            txtPassword.UseSystemPasswordChar = true;
        }

        /// <summary>
        /// Se ejecuta cuando se carga el formulario
        /// </summary>
        private void frmLogin_Load(object sender, EventArgs e)
        {
            // Centrar el formulario en la pantalla
            this.CenterToScreen();

            // Poner el foco en el campo de email
            txtEmail.Focus();
        }

        /// <summary>
        /// Botón INICIAR SESIÓN
        /// Valida las credenciales y abre el menú principal
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 1. Limpiar mensaje de error anterior
            lblError.Text = "";

            // 2. Obtener los datos ingresados
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            // 3. Validaciones básicas de campos vacíos
            if (string.IsNullOrWhiteSpace(email))
            {
                MostrarError("Por favor ingresa tu email");
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MostrarError("Por favor ingresa tu contraseña");
                txtPassword.Focus();
                return;
            }

            // 4. Validar login en la base de datos
            try
            {
                string mensajeError;
                Usuario usuario = usuarioNegocio.ValidarLogin(email, password, out mensajeError);

                if (usuario != null)
                {
                    // ¡Login exitoso! 🎉

                    // Guardar la sesión del usuario
                    SesionUsuario.IniciarSesion(usuario);

                    // Mensaje de bienvenida
                    MessageBox.Show($"¡Bienvenido, {usuario.Nombre}!",
                        "Acceso Exitoso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Abrir el formulario principal
                    frmMain menuPrincipal = new frmMain();
                    menuPrincipal.Show();

                    // Ocultar el login (no cerrarlo, para poder volver)
                    this.Hide();
                }
                else
                {
                    // Login falló
                    MostrarError(mensajeError);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MostrarError($"Error al iniciar sesión: {ex.Message}");
            }
        }

        /// <summary>
        /// Botón REGISTRARSE
        /// Abre el formulario de registro para usuarios nuevos
        /// </summary>
        private void btnRegistro_Click(object sender, EventArgs e)
        {
            // Abrir el formulario de registro
            frmRegistro formRegistro = new frmRegistro();
            formRegistro.ShowDialog(); // ShowDialog = espera a que se cierre el registro

            // Cuando vuelva del registro, poner el foco en email
            txtEmail.Focus();
        }

        /// <summary>
        /// Botón SALIR
        /// Cierra la aplicación completamente
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Preguntar si está seguro
            DialogResult resultado = MessageBox.Show(
                "¿Estás seguro que deseas salir?",
                "Confirmar salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Permite hacer login con la tecla ENTER
        /// </summary>
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        /// <summary>
        /// Muestra un mensaje de error en rojo
        /// </summary>
        private void MostrarError(string mensaje)
        {
            lblError.Text = mensaje;
            lblError.ForeColor = Color.Red;
        }
    }
}
