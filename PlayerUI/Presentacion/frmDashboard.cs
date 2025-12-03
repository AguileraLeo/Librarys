using System;
using System.Data;
using System.Windows.Forms;
using PlayerUI.Datos;
using PlayerUI.Modelos;
using PlayerUI.Negocio;
using System.Collections.Generic;
using System.Linq;

namespace PlayerUI
{
    public partial class frmDashboard : Form
    {
        private DashboardNegocio dashboardNegocio;
        private LibroDatos libroDatos;

        public frmDashboard()
        {
            InitializeComponent();
            dashboardNegocio = new DashboardNegocio();
            libroDatos = new LibroDatos();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDatosDashboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el dashboard: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosDashboard()
        {
            try
            {
                // 1. Cargar estadísticas generales en labels
                CargarEstadisticasGenerales();

                // 3. Cargar top usuarios más activos
                CargarTopUsuariosMasActivos();

                // 4. Cargar multas pendientes
                CargarMultasPendientes();

                // 6. Cargar todos los préstamos
                CargarTodosPrestamos();

            }
            catch (Exception ex)
            {
                throw new Exception($"Error al cargar datos del dashboard: {ex.Message}");
            }
        }

        private void CargarEstadisticasGenerales()
        {
            try
            {
                // Obtener estadísticas desde el negocio
                var estadisticas = dashboardNegocio.ObtenerEstadisticasCompletas();

                if (estadisticas != null)
                {
                    // Mostrar estadísticas en los labels correspondientes
                    lblTotalUsuarios.Text = estadisticas.TotalUsuarios.ToString("N0");
                    lblTotalLibros.Text = estadisticas.TotalLibros.ToString("N0");
                    lblPrestamosActivos.Text = estadisticas.PrestamosActivos.ToString("N0");
                    lblTotalMultas.Text = estadisticas.MultasPendientes.ToString("C");

                    // Calcular libros disponibles (esto es un ejemplo, ajusta según tu lógica)
                    // Puedes obtenerlo del SP o calcularlo
                    lblLibrosDisponibles.Text = "Cargando..."; // Esto lo debes calcular
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar estadísticas: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CargarTopUsuariosMasActivos()
        {
            try
            {
                // Obtener top usuarios desde el negocio
                var topUsuarios = dashboardNegocio.ObtenerTopUsuariosMasActivos(10);

                if (topUsuarios != null && topUsuarios.Count > 0)
                {
                    // Configurar DataGridView para top usuarios
                    ConfigurarDataGridViewUsuarios();

                    // Asignar datos al DataGridView
                    dgvTopUsuarios.DataSource = topUsuarios;

                    // Opcional: Ajustar columnas automáticamente
                    dgvTopUsuarios.AutoResizeColumns();
                }
                else
                {
                    dgvTopUsuarios.DataSource = null;
                    dgvTopUsuarios.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar top usuarios: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CargarMultasPendientes()
        {
            try
            {
                // Obtener multas pendientes desde el negocio
                var multas = dashboardNegocio.ObtenerMultasPendientes();

                if (multas != null && multas.Count > 0)
                {
                    // Configurar DataGridView para multas
                    ConfigurarDataGridViewMultas();

                    // Asignar datos al DataGridView
                    dgvMultas.DataSource = multas;

                    // Actualizar label de multas pendientes
                    lblMultasPendientes.Text = multas.Count.ToString("N0");

                    // Opcional: Calcular monto total
                    decimal montoTotal = 0;
                    foreach (dynamic multa in multas)
                    {
                        // Extraer el monto del string formateado
                        string montoStr = multa.Monto.ToString().Replace("$", "").Replace(",", "");
                        if (decimal.TryParse(montoStr, out decimal monto))
                        {
                            montoTotal += monto;
                        }
                    }
                    lblTotalMultas.Text = montoTotal.ToString("C");

                    // Ajustar columnas automáticamente
                    dgvMultas.AutoResizeColumns();
                }
                else
                {
                    dgvMultas.DataSource = null;
                    dgvMultas.Rows.Clear();
                    lblMultasPendientes.Text = "0";
                    lblTotalMultas.Text = "$0.00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar multas: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CargarTodosPrestamos()
        {
            try
            {
                // Obtener todos los préstamos (solo activos para el dashboard)
                var todosPrestamos = dashboardNegocio.ObtenerTodosPrestamos(true);

                if (todosPrestamos != null && todosPrestamos.Count > 0)
                {
                    // Si tienes un DataGridView para todos los préstamos, asigna los datos
                    // dgvTodosPrestamos.DataSource = todosPrestamos;

                    // Actualizar contador de préstamos activos
                    lblPrestamosActivos.Text = todosPrestamos.Count.ToString("N0");
                }
            }
            catch (Exception ex)
            {
                // Silenciar este error o mostrar en debug
                Console.WriteLine($"Error al cargar todos los préstamos: {ex.Message}");
            }
        }

        // Métodos de configuración de DataGridViews

        private void ConfigurarDataGridViewUsuarios()
        {
            if (dgvTopUsuarios.Columns.Count == 0)
            {
                // Configurar columnas para top usuarios
                dgvTopUsuarios.AutoGenerateColumns = false;
                dgvTopUsuarios.Columns.Clear();

                // Añadir columnas manualmente
                DataGridViewTextBoxColumn colPosicion = new DataGridViewTextBoxColumn();
                colPosicion.HeaderText = "#";
                colPosicion.DataPropertyName = "Posicion";
                colPosicion.Width = 50;
                dgvTopUsuarios.Columns.Add(colPosicion);

                DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
                colNombre.HeaderText = "Nombre";
                colNombre.DataPropertyName = "Nombre";
                colNombre.Width = 150;
                dgvTopUsuarios.Columns.Add(colNombre);

                DataGridViewTextBoxColumn colEmail = new DataGridViewTextBoxColumn();
                colEmail.HeaderText = "Email";
                colEmail.DataPropertyName = "Email";
                colEmail.Width = 200;
                dgvTopUsuarios.Columns.Add(colEmail);

                DataGridViewTextBoxColumn colPrestamos = new DataGridViewTextBoxColumn();
                colPrestamos.HeaderText = "Préstamos";
                colPrestamos.DataPropertyName = "Prestamos";
                colPrestamos.Width = 80;
                dgvTopUsuarios.Columns.Add(colPrestamos);

                DataGridViewTextBoxColumn colMultas = new DataGridViewTextBoxColumn();
                colMultas.HeaderText = "Multas Pendientes";
                colMultas.DataPropertyName = "Multas";
                colMultas.Width = 120;
                dgvTopUsuarios.Columns.Add(colMultas);
            }
        }

        private void ConfigurarDataGridViewMultas()
        {
            if (dgvMultas.Columns.Count == 0)
            {
                // Configurar columnas para multas
                dgvMultas.AutoGenerateColumns = false;
                dgvMultas.Columns.Clear();

                // Añadir columnas manualmente
                DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
                colId.HeaderText = "ID";
                colId.DataPropertyName = "Id";
                colId.Width = 50;
                dgvMultas.Columns.Add(colId);

                DataGridViewTextBoxColumn colUsuario = new DataGridViewTextBoxColumn();
                colUsuario.HeaderText = "Usuario";
                colUsuario.DataPropertyName = "Usuario";
                colUsuario.Width = 150;
                dgvMultas.Columns.Add(colUsuario);

                DataGridViewTextBoxColumn colLibro = new DataGridViewTextBoxColumn();
                colLibro.HeaderText = "Libro";
                colLibro.DataPropertyName = "Libro";
                colLibro.Width = 200;
                dgvMultas.Columns.Add(colLibro);

                DataGridViewTextBoxColumn colMonto = new DataGridViewTextBoxColumn();
                colMonto.HeaderText = "Monto";
                colMonto.DataPropertyName = "Monto";
                colMonto.Width = 100;
                dgvMultas.Columns.Add(colMonto);

                DataGridViewTextBoxColumn colEstado = new DataGridViewTextBoxColumn();
                colEstado.HeaderText = "Estado";
                colEstado.DataPropertyName = "Estado";
                colEstado.Width = 100;
                dgvMultas.Columns.Add(colEstado);
            }
        }

        // Botón de exportar PDF (puedes implementarlo)
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Función de exportar PDF aún no implementada",
                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Botón de cerrar
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}