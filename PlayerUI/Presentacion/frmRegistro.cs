using System;
using System.Drawing;
using System.Windows.Forms;
using PlayerUI.Modelos;
using PlayerUI.Negocio;
using PlayerUI.Datos;

namespace PlayerUI.Presentacion
{
    /// <summary>
    /// Formulario de Registro de nuevos usuarios
    /// Permite crear una cuenta nueva en el sistema
    /// </summary>
    public partial class frmRegistro : Form
    {
        private UsuarioDatos usuarioDatos;

        public frmRegistro()
        {
            InitializeComponent();
            usuarioDatos = new UsuarioDatos();

            // Configurar campos de contraseña
            txtPassword.UseSystemPasswordChar = true;
            txtConfirmarPassword.UseSystemPasswordChar = true;
        }

        private void frmRegistro_Load(object sender, EventArgs e)
        {
            // Centrar formulario
            this.CenterToScreen();

            // Por defecto, crear usuarios normales (no admin)
            cboTipo.Items.Add("Usuario");
            cboTipo.Items.Add("Admin");
            cboTipo.SelectedIndex = 0; // Usuario por defecto

            // Poner foco en nombre
            txtNombre.Focus();
        }

        /// <summary>
        /// Botón REGISTRAR
        /// Crea el nuevo usuario en la base de datos
        /// </summary>
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Limpiar mensajes anteriores
            lblError.Text = "";

            // 1. VALIDAR CAMPOS VACÍOS
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MostrarError("El nombre es obligatorio");
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MostrarError("El email es obligatorio");
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MostrarError("La contraseña es obligatoria");
                txtPassword.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtConfirmarPassword.Text))
            {
                MostrarError("Debes confirmar la contraseña");
                txtConfirmarPassword.Focus();
                return;
            }

            // 2. VALIDAR FORMATO DE EMAIL
            Usuario usuarioTemp = new Usuario();
            usuarioTemp.Email = txtEmail.Text.Trim();
            if (!usuarioTemp.EmailEsValido())
            {
                MostrarError("El formato del email no es válido");
                txtEmail.Focus();
                return;
            }

            // 3. VALIDAR QUE LAS CONTRASEÑAS COINCIDAN
            if (txtPassword.Text != txtConfirmarPassword.Text)
            {
                MostrarError("Las contraseñas no coinciden");
                txtConfirmarPassword.Clear();
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            // 4. VALIDAR LONGITUD DE CONTRASEÑA
            if (txtPassword.Text.Length < 4)
            {
                MostrarError("La contraseña debe tener al menos 4 caracteres");
                txtPassword.Focus();
                return;
            }

            // 5. CREAR EL USUARIO
            try
            {
                Usuario nuevoUsuario = new Usuario
                {
                    Nombre = txtNombre.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Password = txtPassword.Text, // En producción, esto debería hashearse
                    Tipo = cboTipo.SelectedItem.ToString()
                };

                bool exito = usuarioDatos.Crear(nuevoUsuario);

                if (exito)
                {
                    MessageBox.Show(
                        $"¡Usuario creado exitosamente!\n\nNombre: {nuevoUsuario.Nombre}\nEmail: {nuevoUsuario.Email}\nTipo: {nuevoUsuario.Tipo}",
                        "Registro Exitoso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Cerrar el formulario de registro
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MostrarError("No se pudo crear el usuario. Verifica que el email no esté registrado.");
                }
            }
            catch (Exception ex)
            {
                MostrarError($"Error al registrar: {ex.Message}");
            }
        }

        /// <summary>
        /// Botón CANCELAR
        /// Cierra el formulario sin guardar
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Muestra un mensaje de error en rojo
        /// </summary>
        private void MostrarError(string mensaje)
        {
            lblError.Text = mensaje;
            lblError.ForeColor = Color.Red;
        }

        /// <summary>
        /// Permite registrar con ENTER en el último campo
        /// </summary>
        private void txtConfirmarPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnRegistrar_Click(sender, e);
            }
        }
    }
}
