using System;
using System.Data;
using System.Windows.Forms;
using PlayerUI.Datos;
using PlayerUI.Modelos;

namespace PlayerUI
{
    /// <summary>
    /// Formulario del Catálogo de Libros
    /// Permite buscar libros y solicitarlos en préstamo
    /// </summary>
    public partial class frmCatalogo : Form
    {
        private LibroDatos libroDatos;

        public frmCatalogo()
        {
            InitializeComponent();
            libroDatos = new LibroDatos();

            // Conectar evento de búsqueda mientras escribes
            textBox1.TextChanged += textBox1_TextChanged;

            // Configurar DataGridView
            ConfigurarDataGridView();
        }

        /// <summary>
        /// Se ejecuta al cargar el formulario
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CargarLibros(); // Cargar todos los libros al inicio
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

            // Limpiar columnas existentes
            dataGridView1.Columns.Clear();

            // Agregar columnas personalizadas
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id",
                HeaderText = "ID",
                DataPropertyName = "id",
                Width = 50,
                Visible = false // Ocultar el ID
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "titulo",
                HeaderText = "Título",
                DataPropertyName = "titulo",
                Width = 250
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "autor",
                HeaderText = "Autor",
                DataPropertyName = "autor",
                Width = 180
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "isbn",
                HeaderText = "ISBN",
                DataPropertyName = "isbn",
                Width = 120
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "categoriaNombre",
                HeaderText = "Categoría",
                DataPropertyName = "categoriaNombre",
                Width = 150
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "stockDisponible",
                HeaderText = "Disponibles",
                DataPropertyName = "stockDisponible",
                Width = 100
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "stockTotal",
                HeaderText = "Total",
                DataPropertyName = "stockTotal",
                Width = 80
            });
        }

        /// <summary>
        /// Carga todos los libros o libros filtrados
        /// </summary>
        private void CargarLibros(string criterio = null)
        {
            try
            {
                DataTable libros = libroDatos.BuscarLibros(criterio, null, false);
                dataGridView1.DataSource = libros;

                // Mostrar cantidad de resultados
                label1.Text = $"Filtro ({libros.Rows.Count} libros encontrados):";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar libros: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Búsqueda en tiempo real mientras escribe
        /// </summary>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string criterio = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(criterio))
            {
                CargarLibros(); // Si está vacío, mostrar todos
            }
            else
            {
                CargarLibros(criterio); // Buscar por criterio
            }
        }

        /// <summary>
        /// Botón PEDIR LIBRO (Realizar Préstamo)
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            // Verificar que haya un libro seleccionado
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor selecciona un libro para solicitar",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Obtener el libro seleccionado
                DataGridViewRow fila = dataGridView1.SelectedRows[0];
                int libroId = Convert.ToInt32(fila.Cells["id"].Value);
                string titulo = fila.Cells["titulo"].Value.ToString();
                int stockDisponible = Convert.ToInt32(fila.Cells["stockDisponible"].Value);

                // Verificar disponibilidad
                if (stockDisponible <= 0)
                {
                    MessageBox.Show($"El libro '{titulo}' no está disponible en este momento",
                        "No Disponible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirmar préstamo
                DialogResult confirmacion = MessageBox.Show(
                    $"¿Deseas solicitar el libro '{titulo}'?\n\n" +
                    $"• Duración: 14 días\n" +
                    $"• Multa por retraso: $50 por día\n",
                    "Confirmar Préstamo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    // Realizar el préstamo
                    bool exito = libroDatos.RealizarPrestamo(
                        SesionUsuario.UsuarioId,
                        libroId,
                        14); // 14 días de préstamo

                    if (exito)
                    {
                        MessageBox.Show(
                            $"¡Préstamo realizado exitosamente!\n\n" +
                            $"Libro: {titulo}\n" +
                            $"Fecha de devolución: {DateTime.Now.AddDays(14):dd/MM/yyyy}",
                            "Préstamo Exitoso",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        // Recargar la lista para actualizar el stock
                        CargarLibros(textBox1.Text.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al realizar el préstamo: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Botón Cerrar (X)
        /// </summary>
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Botón Volver
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
