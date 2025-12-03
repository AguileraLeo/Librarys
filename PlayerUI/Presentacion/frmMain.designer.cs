namespace PlayerUI
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLtrlDashboard = new System.Windows.Forms.Button();
            this.btnLtrlGestionLibros = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnEqualizer = new System.Windows.Forms.Button();
            this.panelMediaSubMenu = new System.Windows.Forms.Panel();
            this.btnLtrlPrestamos = new System.Windows.Forms.Button();
            this.btnLtrlBuscarLibros = new System.Windows.Forms.Button();
            this.btnMedia = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.panelSideMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelMediaSubMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelChildForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.AutoScroll = true;
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panelSideMenu.Controls.Add(this.panel1);
            this.panelSideMenu.Controls.Add(this.btnExit);
            this.panelSideMenu.Controls.Add(this.btnEqualizer);
            this.panelSideMenu.Controls.Add(this.panelMediaSubMenu);
            this.panelSideMenu.Controls.Add(this.btnMedia);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(250, 814);
            this.panelSideMenu.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panel1.Controls.Add(this.btnLtrlDashboard);
            this.panel1.Controls.Add(this.btnLtrlGestionLibros);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 262);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 82);
            this.panel1.TabIndex = 10;
            // 
            // btnLtrlDashboard
            // 
            this.btnLtrlDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLtrlDashboard.FlatAppearance.BorderSize = 0;
            this.btnLtrlDashboard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(38)))), ((int)(((byte)(46)))));
            this.btnLtrlDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(38)))), ((int)(((byte)(46)))));
            this.btnLtrlDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLtrlDashboard.ForeColor = System.Drawing.Color.Silver;
            this.btnLtrlDashboard.Location = new System.Drawing.Point(0, 40);
            this.btnLtrlDashboard.Name = "btnLtrlDashboard";
            this.btnLtrlDashboard.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnLtrlDashboard.Size = new System.Drawing.Size(250, 36);
            this.btnLtrlDashboard.TabIndex = 1;
            this.btnLtrlDashboard.Text = "DashBoard";
            this.btnLtrlDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLtrlDashboard.UseVisualStyleBackColor = true;
            this.btnLtrlDashboard.Click += new System.EventHandler(this.btnLtrlDashboard_Click);
            // 
            // btnLtrlGestionLibros
            // 
            this.btnLtrlGestionLibros.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLtrlGestionLibros.FlatAppearance.BorderSize = 0;
            this.btnLtrlGestionLibros.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(38)))), ((int)(((byte)(46)))));
            this.btnLtrlGestionLibros.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(38)))), ((int)(((byte)(46)))));
            this.btnLtrlGestionLibros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLtrlGestionLibros.ForeColor = System.Drawing.Color.Silver;
            this.btnLtrlGestionLibros.Location = new System.Drawing.Point(0, 0);
            this.btnLtrlGestionLibros.Name = "btnLtrlGestionLibros";
            this.btnLtrlGestionLibros.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnLtrlGestionLibros.Size = new System.Drawing.Size(250, 40);
            this.btnLtrlGestionLibros.TabIndex = 0;
            this.btnLtrlGestionLibros.Text = "Gestion de Libros";
            this.btnLtrlGestionLibros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLtrlGestionLibros.UseVisualStyleBackColor = true;
            this.btnLtrlGestionLibros.Click += new System.EventHandler(this.btnLtrlGestionLibros_Click);
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.Silver;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(0, 769);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnExit.Size = new System.Drawing.Size(250, 45);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Salir";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnEqualizer
            // 
            this.btnEqualizer.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEqualizer.FlatAppearance.BorderSize = 0;
            this.btnEqualizer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.btnEqualizer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.btnEqualizer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEqualizer.ForeColor = System.Drawing.Color.Silver;
            this.btnEqualizer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEqualizer.Location = new System.Drawing.Point(0, 217);
            this.btnEqualizer.Name = "btnEqualizer";
            this.btnEqualizer.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnEqualizer.Size = new System.Drawing.Size(250, 45);
            this.btnEqualizer.TabIndex = 5;
            this.btnEqualizer.Text = "Inventario (Admin)";
            this.btnEqualizer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEqualizer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEqualizer.UseVisualStyleBackColor = true;
            this.btnEqualizer.Click += new System.EventHandler(this.btnEqualizer_Click);
            // 
            // panelMediaSubMenu
            // 
            this.panelMediaSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelMediaSubMenu.Controls.Add(this.btnLtrlPrestamos);
            this.panelMediaSubMenu.Controls.Add(this.btnLtrlBuscarLibros);
            this.panelMediaSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMediaSubMenu.Location = new System.Drawing.Point(0, 137);
            this.panelMediaSubMenu.Name = "panelMediaSubMenu";
            this.panelMediaSubMenu.Size = new System.Drawing.Size(250, 80);
            this.panelMediaSubMenu.TabIndex = 2;
            // 
            // btnLtrlPrestamos
            // 
            this.btnLtrlPrestamos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLtrlPrestamos.FlatAppearance.BorderSize = 0;
            this.btnLtrlPrestamos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(38)))), ((int)(((byte)(46)))));
            this.btnLtrlPrestamos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(38)))), ((int)(((byte)(46)))));
            this.btnLtrlPrestamos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLtrlPrestamos.ForeColor = System.Drawing.Color.Silver;
            this.btnLtrlPrestamos.Location = new System.Drawing.Point(0, 40);
            this.btnLtrlPrestamos.Name = "btnLtrlPrestamos";
            this.btnLtrlPrestamos.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnLtrlPrestamos.Size = new System.Drawing.Size(250, 40);
            this.btnLtrlPrestamos.TabIndex = 1;
            this.btnLtrlPrestamos.Text = "Prestamos";
            this.btnLtrlPrestamos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLtrlPrestamos.UseVisualStyleBackColor = true;
            this.btnLtrlPrestamos.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnLtrlBuscarLibros
            // 
            this.btnLtrlBuscarLibros.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLtrlBuscarLibros.FlatAppearance.BorderSize = 0;
            this.btnLtrlBuscarLibros.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(38)))), ((int)(((byte)(46)))));
            this.btnLtrlBuscarLibros.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(38)))), ((int)(((byte)(46)))));
            this.btnLtrlBuscarLibros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLtrlBuscarLibros.ForeColor = System.Drawing.Color.Silver;
            this.btnLtrlBuscarLibros.Location = new System.Drawing.Point(0, 0);
            this.btnLtrlBuscarLibros.Name = "btnLtrlBuscarLibros";
            this.btnLtrlBuscarLibros.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnLtrlBuscarLibros.Size = new System.Drawing.Size(250, 40);
            this.btnLtrlBuscarLibros.TabIndex = 0;
            this.btnLtrlBuscarLibros.Text = "Buscar Libros";
            this.btnLtrlBuscarLibros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLtrlBuscarLibros.UseVisualStyleBackColor = true;
            this.btnLtrlBuscarLibros.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnMedia
            // 
            this.btnMedia.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMedia.FlatAppearance.BorderSize = 0;
            this.btnMedia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.btnMedia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.btnMedia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMedia.ForeColor = System.Drawing.Color.Silver;
            this.btnMedia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMedia.Location = new System.Drawing.Point(0, 92);
            this.btnMedia.Name = "btnMedia";
            this.btnMedia.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnMedia.Size = new System.Drawing.Size(250, 45);
            this.btnMedia.TabIndex = 1;
            this.btnMedia.Text = "Libreria";
            this.btnMedia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMedia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMedia.UseVisualStyleBackColor = true;
            this.btnMedia.Click += new System.EventHandler(this.btnMedia_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(250, 92);
            this.panelLogo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 89);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelChildForm
            // 
            this.panelChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panelChildForm.Controls.Add(this.pictureBox9);
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(250, 0);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(989, 814);
            this.panelChildForm.TabIndex = 2;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
            this.pictureBox9.Location = new System.Drawing.Point(158, 219);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(667, 352);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox9.TabIndex = 2;
            this.pictureBox9.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1239, 814);
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.panelSideMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(950, 600);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panelSideMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelMediaSubMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelChildForm.ResumeLayout(false);
            this.panelChildForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Panel panelMediaSubMenu;
        private System.Windows.Forms.Button btnLtrlPrestamos;
        private System.Windows.Forms.Button btnLtrlBuscarLibros;
        private System.Windows.Forms.Button btnMedia;
        private System.Windows.Forms.Button btnEqualizer;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLtrlDashboard;
        private System.Windows.Forms.Button btnLtrlGestionLibros;
    }
}

