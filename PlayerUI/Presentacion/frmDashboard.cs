using System;
using System.Data;
using System.Windows.Forms;
using PlayerUI.Datos;
using PlayerUI.Modelos;

namespace PlayerUI
{
    /// <summary>
    /// Formulario Dashboard - Estadísticas del sistema
    /// Muestra información general de la biblioteca
    /// </summary>
    public partial class frmDashboard : Form
    {
        private LibroDatos libroDatos;

        public frmDashboard()
        {
            InitializeComponent();
            libroDatos = new LibroDatos();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Mostrar saludo personalizado
            MostrarSaludo();

            // Cargar estadísticas
            CargarEstadisticas();

            // Cargar top libros más prestados
            CargarTopLibros();
        }

        /// <summary>
        /// Muestra un saludo personalizado con el nombre del usuario
        /// </summary>
        private void MostrarSaludo()
        {
            string saludo = SesionUsuario.ObtenerSaludo();
            this.Text = $"Dashboard - {saludo}";
        }

        /// <summary>
        /// Carga las estadísticas generales del sistema
        /// </summary>
        private void CargarEstadisticas()
        {
            try
            {
                DataTable stats = libroDatos.ObtenerEstadisticasDashboard();

                if (stats.Rows.Count > 0)
                {
                    DataRow row = stats.Rows[0];

                    // Mostrar estadísticas en labels (si existen en el diseño)
                    // Si tu diseñador tiene labels, puedes descomentar esto:

                    /*
                    lblTotalLibros.Text = row["totalLibros"].ToString();
                    lblTotalUsuarios.Text = row["totalUsuarios"].ToString();
                    lblPrestamosActivos.Text = row["prestamosActivos"].ToString();
                    lblLibrosDisponibles.Text = row["librosDisponibles"].ToString();
                    lblMultasPendientes.Text = row["multasPendientes"].ToString();
                    lblMontoMultas.Text = string.Format("${0:N2}", row["montoMultasPendientes"]);
                    */

                    // Mostrar en un MessageBox temporal (para demostración)
                    string mensaje = $"=== ESTADÍSTICAS GORDONT LIBRARY ===\n\n" +
                                   $"📚 Total de Libros: {row["totalLibros"]}\n" +
                                   $"👥 Total de Usuarios: {row["totalUsuarios"]}\n" +
                                   $"📖 Préstamos Activos: {row["prestamosActivos"]}\n" +
                                   $"✅ Libros Disponibles: {row["librosDisponibles"]}\n" +
                                   $"⚠️ Multas Pendientes: {row["multasPendientes"]}\n" +
                                   $"💰 Monto Multas: ${row["montoMultasPendientes"]:N2}";

                    // Puedes comentar esto si ya tienes labels en el diseño
                    MessageBox.Show(mensaje, "Estadísticas del Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar estadísticas: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga los libros más prestados
        /// </summary>
        private void CargarTopLibros()
        {
            try
            {
                DataTable topLibros = libroDatos.ObtenerTopLibrosMasPrestados(10);

                // Si tienes un DataGridView en el diseño, puedes mostrarlo ahí
                // dataGridViewTop.DataSource = topLibros;

                // Temporalmente mostrar en mensaje
                if (topLibros.Rows.Count > 0)
                {
                    string mensaje = "=== TOP 10 LIBROS MÁS PRESTADOS ===\n\n";

                    int posicion = 1;
                    foreach (DataRow row in topLibros.Rows)
                    {
                        mensaje += $"{posicion}. {row["titulo"]} - {row["autor"]}\n" +
                                 $"   ({row["totalPrestamos"]} préstamos)\n\n";
                        posicion++;

                        if (posicion > 10) break;
                    }

                    MessageBox.Show(mensaje, "Libros Más Populares",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar top libros: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
