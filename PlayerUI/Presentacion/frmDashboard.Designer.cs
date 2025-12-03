namespace PlayerUI
{
    partial class frmDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDashboard));
            this.button5 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTotalMultas = new System.Windows.Forms.Label();
            this.lblLibrosDisponibles = new System.Windows.Forms.Label();
            this.lblMultasPendientes = new System.Windows.Forms.Label();
            this.lblPrestamosActivos = new System.Windows.Forms.Label();
            this.lblTotalLibros = new System.Windows.Forms.Label();
            this.lblTotalUsuarios = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvTopUsuarios = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvMultas = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopUsuarios)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMultas)).BeginInit();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.LightGray;
            this.button5.Location = new System.Drawing.Point(1, 1);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(33, 31);
            this.button5.TabIndex = 9;
            this.button5.Text = "X";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(43, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(333, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTotalMultas);
            this.groupBox1.Controls.Add(this.lblLibrosDisponibles);
            this.groupBox1.Controls.Add(this.lblMultasPendientes);
            this.groupBox1.Controls.Add(this.lblPrestamosActivos);
            this.groupBox1.Controls.Add(this.lblTotalLibros);
            this.groupBox1.Controls.Add(this.lblTotalUsuarios);
            this.groupBox1.Font = new System.Drawing.Font("Baskerville Old Face", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.PapayaWhip;
            this.groupBox1.Location = new System.Drawing.Point(43, 162);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1228, 229);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Estadisticas";
            // 
            // lblTotalMultas
            // 
            this.lblTotalMultas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTotalMultas.AutoSize = true;
            this.lblTotalMultas.Font = new System.Drawing.Font("Baskerville Old Face", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMultas.ForeColor = System.Drawing.Color.PapayaWhip;
            this.lblTotalMultas.Location = new System.Drawing.Point(385, 183);
            this.lblTotalMultas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalMultas.Name = "lblTotalMultas";
            this.lblTotalMultas.Size = new System.Drawing.Size(117, 23);
            this.lblTotalMultas.TabIndex = 22;
            this.lblTotalMultas.Text = "Total Multas:";
            // 
            // lblLibrosDisponibles
            // 
            this.lblLibrosDisponibles.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblLibrosDisponibles.AutoSize = true;
            this.lblLibrosDisponibles.Font = new System.Drawing.Font("Baskerville Old Face", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLibrosDisponibles.ForeColor = System.Drawing.Color.PapayaWhip;
            this.lblLibrosDisponibles.Location = new System.Drawing.Point(375, 91);
            this.lblLibrosDisponibles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLibrosDisponibles.Name = "lblLibrosDisponibles";
            this.lblLibrosDisponibles.Size = new System.Drawing.Size(229, 23);
            this.lblLibrosDisponibles.TabIndex = 21;
            this.lblLibrosDisponibles.Text = "Total de libros Disponibles:";
            // 
            // lblMultasPendientes
            // 
            this.lblMultasPendientes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblMultasPendientes.AutoSize = true;
            this.lblMultasPendientes.Font = new System.Drawing.Font("Baskerville Old Face", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMultasPendientes.ForeColor = System.Drawing.Color.PapayaWhip;
            this.lblMultasPendientes.Location = new System.Drawing.Point(21, 183);
            this.lblMultasPendientes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMultasPendientes.Name = "lblMultasPendientes";
            this.lblMultasPendientes.Size = new System.Drawing.Size(160, 23);
            this.lblMultasPendientes.TabIndex = 20;
            this.lblMultasPendientes.Text = "Multas Pendientes:";
            // 
            // lblPrestamosActivos
            // 
            this.lblPrestamosActivos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPrestamosActivos.AutoSize = true;
            this.lblPrestamosActivos.Font = new System.Drawing.Font("Baskerville Old Face", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrestamosActivos.ForeColor = System.Drawing.Color.PapayaWhip;
            this.lblPrestamosActivos.Location = new System.Drawing.Point(21, 133);
            this.lblPrestamosActivos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrestamosActivos.Name = "lblPrestamosActivos";
            this.lblPrestamosActivos.Size = new System.Drawing.Size(154, 23);
            this.lblPrestamosActivos.TabIndex = 19;
            this.lblPrestamosActivos.Text = "Prestamos activos:";
            // 
            // lblTotalLibros
            // 
            this.lblTotalLibros.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTotalLibros.AutoSize = true;
            this.lblTotalLibros.Font = new System.Drawing.Font("Baskerville Old Face", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalLibros.ForeColor = System.Drawing.Color.PapayaWhip;
            this.lblTotalLibros.Location = new System.Drawing.Point(21, 91);
            this.lblTotalLibros.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalLibros.Name = "lblTotalLibros";
            this.lblTotalLibros.Size = new System.Drawing.Size(131, 23);
            this.lblTotalLibros.TabIndex = 18;
            this.lblTotalLibros.Text = "Total de libros:";
            // 
            // lblTotalUsuarios
            // 
            this.lblTotalUsuarios.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTotalUsuarios.AutoSize = true;
            this.lblTotalUsuarios.Font = new System.Drawing.Font("Baskerville Old Face", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalUsuarios.ForeColor = System.Drawing.Color.PapayaWhip;
            this.lblTotalUsuarios.Location = new System.Drawing.Point(21, 47);
            this.lblTotalUsuarios.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalUsuarios.Name = "lblTotalUsuarios";
            this.lblTotalUsuarios.Size = new System.Drawing.Size(157, 23);
            this.lblTotalUsuarios.TabIndex = 17;
            this.lblTotalUsuarios.Text = "Total de Usuarios:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvTopUsuarios);
            this.groupBox2.Font = new System.Drawing.Font("Baskerville Old Face", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.PapayaWhip;
            this.groupBox2.Location = new System.Drawing.Point(43, 434);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1228, 229);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Top Usuarios";
            // 
            // dgvTopUsuarios
            // 
            this.dgvTopUsuarios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.dgvTopUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopUsuarios.Location = new System.Drawing.Point(8, 25);
            this.dgvTopUsuarios.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTopUsuarios.Name = "dgvTopUsuarios";
            this.dgvTopUsuarios.ReadOnly = true;
            this.dgvTopUsuarios.RowHeadersWidth = 51;
            this.dgvTopUsuarios.Size = new System.Drawing.Size(1212, 197);
            this.dgvTopUsuarios.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvMultas);
            this.groupBox3.Font = new System.Drawing.Font("Baskerville Old Face", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.PapayaWhip;
            this.groupBox3.Location = new System.Drawing.Point(43, 725);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(1228, 229);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Multas";
            // 
            // dgvMultas
            // 
            this.dgvMultas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.dgvMultas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMultas.Location = new System.Drawing.Point(8, 25);
            this.dgvMultas.Margin = new System.Windows.Forms.Padding(4);
            this.dgvMultas.Name = "dgvMultas";
            this.dgvMultas.RowHeadersWidth = 51;
            this.dgvMultas.Size = new System.Drawing.Size(1212, 197);
            this.dgvMultas.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Silver;
            this.button1.Location = new System.Drawing.Point(1021, 57);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(229, 49);
            this.button1.TabIndex = 17;
            this.button1.Text = "Exportar PDF";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1319, 1002);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDashboard";
            this.Text = "Form5";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopUsuarios)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMultas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvTopUsuarios;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvMultas;
        private System.Windows.Forms.Label lblMultasPendientes;
        private System.Windows.Forms.Label lblPrestamosActivos;
        private System.Windows.Forms.Label lblTotalLibros;
        private System.Windows.Forms.Label lblTotalUsuarios;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblLibrosDisponibles;
        private System.Windows.Forms.Label lblTotalMultas;
    }
}