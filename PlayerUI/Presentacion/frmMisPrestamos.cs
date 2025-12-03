using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using PlayerUI.Datos;
using PlayerUI.Modelos;

namespace PlayerUI
{
    /// <summary>
    /// Formulario Mis Préstamos
    /// Muestra los préstamos del usuario y permite renovarlos o devolverlos
    /// </summary>
    public partial class frmMisPrestamos : Form
    {
        private PrestamoDatos prestamoDatos;
        private LibroDatos libroDatos;
        private bool soloActivos = true; // Por defecto, mostrar solo activos

        public frmMisPrestamos()
        {
            InitializeComponent();
            prestamoDatos = new PrestamoDatos();
            libroDatos = new LibroDatos();

            // Conectar eventos de botones
            button7.Click += button7_Click; // Botón Activos
            button9.Click += button9_Click; // Botón Devolver

            // Configurar DataGridView
            ConfigurarDataGridView();
        }

        /// <summary>
        /// Se ejecuta al cargar el formulario
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Mostrar nombre del usuario
            label2.Text = $"Usuario: {SesionUsuario.Nombre}";

            // Cargar préstamos
            CargarPrestamos();
        }

        /// <summary>
        /// Configura las columnas del DataGridView
        /// </summary>
        private void ConfigurarDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;

            // Limpiar columnas
            dataGridView1.Columns.Clear();

            // Columna ID (oculta)
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id",
                HeaderText = "ID",
                DataPropertyName = "id",
                Visible = false
            });

            // Columna LibroID (oculta)
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "libroID",
                HeaderText = "LibroID",
                DataPropertyName = "libroID",
                Visible = false
            });

            // Título del libro
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "libroTitulo",
                HeaderText = "Libro",
                DataPropertyName = "libroTitulo",
                Width = 250
            });

            // Autor
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "libroAutor",
                HeaderText = "Autor",
                DataPropertyName = "libroAutor",
                Width = 180
            });

            // Fecha de préstamo
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "fechaPrestamo",
                HeaderText = "Fecha Préstamo",
                DataPropertyName = "fechaPrestamo",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            // Fecha de devolución esperada
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "fechaDevolucionEsperada",
                HeaderText = "Devolución Esperada",
                DataPropertyName = "fechaDevolucionEsperada",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            // Fecha de devolución real
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "fechaDevolucionReal",
                HeaderText = "Devolución Real",
                DataPropertyName = "fechaDevolucionReal",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            // Estado
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "estado",
                HeaderText = "Estado",
                DataPropertyName = "estado",
                Width = 100
            });

            // Multas acumuladas
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "multasAcumulada",
                HeaderText = "Multa",
                DataPropertyName = "multasAcumulada",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } // Formato moneda
            });
        }

        /// <summary>
        /// Carga los préstamos del usuario
        /// </summary>
        private void CargarPrestamos()
        {
            try
            {
                DataTable prestamos = prestamoDatos.ObtenerPorUsuario(
                    SesionUsuario.UsuarioId,
                    soloActivos);

                dataGridView1.DataSource = prestamos;

                // Actualizar encabezado
                label1.Text = soloActivos
                    ? $"Préstamos Activos ({prestamos.Rows.Count})"
                    : $"Historial de Préstamos ({prestamos.Rows.Count})";

                // Colorear filas según el estado
                ColorearFilas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar préstamos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Colorea las filas según el estado del préstamo
        /// </summary>
        private void ColorearFilas()
        {
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                string estado = fila.Cells["estado"].Value?.ToString();
                DateTime? fechaDevolucionEsperada = fila.Cells["fechaDevolucionEsperada"].Value as DateTime?;

                if (estado == "Devuelto")
                {
                    fila.DefaultCellStyle.BackColor = Color.LightGreen; // Verde si ya se devolvió
                }
                else if (estado == "Activo" && fechaDevolucionEsperada.HasValue)
                {
                    int diasRestantes = (fechaDevolucionEsperada.Value - DateTime.Now).Days;

                    if (diasRestantes < 0)
                    {
                        fila.DefaultCellStyle.BackColor = Color.LightCoral; // Rojo si está vencido
                    }
                    else if (diasRestantes <= 2)
                    {
                        fila.DefaultCellStyle.BackColor = Color.LightYellow; // Amarillo si está por vencer
                    }
                }
            }
        }

        /// <summary>
        /// Botón ACTIVOS / HISTORIAL (toggle)
        /// </summary>
        private void button7_Click(object sender, EventArgs e)
        {
            soloActivos = !soloActivos;
            button7.Text = soloActivos ? "Ver Historial" : "Ver Activos";
            CargarPrestamos();
        }

        /// <summary>
        /// Botón DEVOLVER libro
        /// </summary>
        private void button9_Click(object sender, EventArgs e)
        {
            // Verificar selección
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor selecciona un préstamo para devolver",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                DataGridViewRow fila = dataGridView1.SelectedRows[0];
                int prestamoId = Convert.ToInt32(fila.Cells["id"].Value);
                string libroTitulo = fila.Cells["libroTitulo"].Value.ToString();
                string estado = fila.Cells["estado"].Value.ToString();

                // Verificar que el préstamo esté activo
                if (estado != "Activo")
                {
                    MessageBox.Show("Solo puedes devolver préstamos activos",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirmar devolución
                DialogResult confirmacion = MessageBox.Show(
                    $"¿Confirmas la devolución del libro '{libroTitulo}'?",
                    "Confirmar Devolución",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    // Devolver el libro
                    bool exito = libroDatos.DevolverLibro(prestamoId);

                    if (exito)
                    {
                        MessageBox.Show(
                            $"Libro devuelto exitosamente!\n\n{libroTitulo}",
                            "Devolución Exitosa",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        // Recargar lista
                        CargarPrestamos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al devolver libro: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Botón cerrar (X)
        /// </summary>
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Botón Volver
        /// </summary>
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
