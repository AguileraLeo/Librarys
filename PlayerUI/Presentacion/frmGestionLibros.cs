using System;
using System.Data;
using System.Windows.Forms;
using PlayerUI.Datos;
using PlayerUI.Modelos;

namespace PlayerUI
{
    /// <summary>
    /// Formulario de Gestión de Libros (CRUD completo)
    /// Solo accesible para administradores
    /// </summary>
    public partial class frmGestionLibros : Form
    {
        private LibroDatos libroDatos;
        private CategoriaDatos categoriaDatos;
        private int libroIdSeleccionado = 0; // 0 = Nuevo libro, >0 = Editar libro

        public frmGestionLibros()
        {
            InitializeComponent();
            libroDatos = new LibroDatos();
            categoriaDatos = new CategoriaDatos();

            // Configurar controles
            ConfigurarDataGridView();
            ConfigurarComboBoxes();

            // Conectar eventos de botones
            button3.Click += btnGuardar_Click;    // Guardar
            button4.Click += btnEliminar_Click;   // Eliminar
            button9.Click += btnNuevo_Click;      // Nuevo (cambió de btnEditar a btnNuevo)
            button1.Click += button1_Click;       // Cerrar

            // Evento cuando hace click en una fila del grid - CARGA AUTOMÁTICA
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Verificar que el usuario sea admin
            if (!SesionUsuario.EsAdmin)
            {
                MessageBox.Show("Solo los administradores pueden gestionar libros",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            CargarLibros();
            LimpiarCampos();
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

            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id",
                HeaderText = "ID",
                DataPropertyName = "id",
                Width = 50
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "titulo",
                HeaderText = "Título",
                DataPropertyName = "titulo",
                Width = 200
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "autor",
                HeaderText = "Autor",
                DataPropertyName = "autor",
                Width = 150
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
                Width = 120
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "stockDisponible",
                HeaderText = "Disponible",
                DataPropertyName = "stockDisponible",
                Width = 80
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
        /// Configura los ComboBoxes (categorías y tipo de recurso)
        /// </summary>
        private void ConfigurarComboBoxes()
        {
            // ComboBox de categorías (comboBox1)
            DataTable categorias = categoriaDatos.ListarTodas();
            comboBox1.DataSource = categorias;
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "id";

            // ComboBox de tipo de recurso (comboBox2)
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Digital");
            comboBox2.Items.Add("Fisico");
            comboBox2.SelectedIndex = 0;

            // Configurar DomainUpDown para stock (domainUpDown2)
            domainUpDown2.Items.Clear();
            for (int i = 1; i <= 100; i++)
            {
                domainUpDown2.Items.Add(i.ToString());
            }
            domainUpDown2.SelectedIndex = 0;
        }

        /// <summary>
        /// Carga todos los libros en el DataGridView
        /// </summary>
        private void CargarLibros()
        {
            try
            {
                DataTable libros = libroDatos.ListarTodos();
                dataGridView1.DataSource = libros;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar libros: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento cuando hace CLICK en una celda del DataGridView
        /// CARGA AUTOMÁTICAMENTE los datos del libro en los TextBox
        /// </summary>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que no sea el header y que haya una fila válida
            if (e.RowIndex < 0 || e.RowIndex >= dataGridView1.Rows.Count)
                return;

            try
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];

                // Verificar que la fila no esté vacía
                if (fila.Cells["id"].Value == null)
                    return;

                // Cargar datos en los TextBox automáticamente
                libroIdSeleccionado = Convert.ToInt32(fila.Cells["id"].Value);
                textBox1.Text = fila.Cells["titulo"].Value?.ToString() ?? "";
                textBox2.Text = fila.Cells["autor"].Value?.ToString() ?? "";
                textBox3.Text = fila.Cells["isbn"].Value?.ToString() ?? "";

                // Obtener datos completos del libro para categoría, editorial, tipo y stock
                DataTable libroCompleto = libroDatos.ObtenerPorId(libroIdSeleccionado);
                if (libroCompleto.Rows.Count > 0)
                {
                    DataRow row = libroCompleto.Rows[0];
                    textBox4.Text = row["editorial"]?.ToString() ?? "";
                    comboBox1.SelectedValue = row["categoriaID"];
                    comboBox2.SelectedItem = row["tipoRecurso"]?.ToString() ?? "Digital";
                    domainUpDown2.Text = row["stockTotal"]?.ToString() ?? "1";
                }

                // Poner foco en el primer campo para editar
                textBox1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos del libro: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Botón NUEVO - Limpia los campos para crear un libro nuevo
        /// </summary>
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            textBox1.Focus(); // Poner foco en título
        }

        /// <summary>
        /// Botón GUARDAR - Crea o actualiza un libro
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar campos
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("El título es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("El autor es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("El ISBN es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("La editorial es obligatoria", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox4.Focus();
                return;
            }

            try
            {
                // Crear objeto Libro
                Libro libro = new Libro
                {
                    Id = libroIdSeleccionado,
                    Titulo = textBox1.Text.Trim(),
                    Autor = textBox2.Text.Trim(),
                    ISBN = textBox3.Text.Trim(),
                    Editorial = textBox4.Text.Trim(),
                    CategoriaId = Convert.ToInt32(comboBox1.SelectedValue),
                    TipoRecurso = comboBox2.SelectedItem.ToString(),
                    StockTotal = Convert.ToInt32(domainUpDown2.Text)
                };

                // Validar con el método del modelo
                string errorValidacion = libro.Validar();
                if (!string.IsNullOrEmpty(errorValidacion))
                {
                    MessageBox.Show(errorValidacion, "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool exito;

                if (libroIdSeleccionado == 0)
                {
                    // CREAR nuevo libro
                    exito = libroDatos.Crear(libro);
                    if (exito)
                    {
                        MessageBox.Show("Libro creado exitosamente",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // ACTUALIZAR libro existente
                    exito = libroDatos.Actualizar(libro);
                    if (exito)
                    {
                        MessageBox.Show("Libro actualizado exitosamente",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (exito)
                {
                    CargarLibros();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar libro: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Botón ELIMINAR - Elimina el libro seleccionado
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un libro para eliminar",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow fila = dataGridView1.SelectedRows[0];
            int libroId = Convert.ToInt32(fila.Cells["id"].Value);
            string titulo = fila.Cells["titulo"].Value.ToString();

            // Confirmar eliminación
            DialogResult confirmacion = MessageBox.Show(
                $"¿Estás seguro de eliminar el libro '{titulo}'?\n\n" +
                "Esta acción no se puede deshacer.",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    bool exito = libroDatos.Eliminar(libroId);

                    if (exito)
                    {
                        MessageBox.Show("Libro eliminado exitosamente",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CargarLibros();
                        LimpiarCampos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar libro: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Limpia todos los campos del formulario
        /// </summary>
        private void LimpiarCampos()
        {
            libroIdSeleccionado = 0;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear(); // Búsqueda

            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;

            if (comboBox2.Items.Count > 0)
                comboBox2.SelectedIndex = 0;

            if (domainUpDown2.Items.Count > 0)
                domainUpDown2.SelectedIndex = 0;
        }

        /// <summary>
        /// Búsqueda en tiempo real
        /// </summary>
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string criterio = textBox5.Text.Trim();

            try
            {
                DataTable libros = libroDatos.BuscarLibros(criterio, null, false);
                dataGridView1.DataSource = libros;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            // No se usa, pero se mantiene para no romper el designer
        }

        /// <summary>
        /// Botón Cerrar
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}