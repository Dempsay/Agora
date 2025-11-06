namespace Desktop.Views
{
    partial class InscripcionesView
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
            panel1 = new Panel();
            label1 = new Label();
            ComboCapacitaciones = new ComboBox();
            label2 = new Label();
            GridInscripciones = new DataGridView();
            panel2 = new Panel();
            label4 = new Label();
            ComboTIpoInscripcion = new ComboBox();
            BtnAgregarUsuario = new FontAwesome.Sharp.IconButton();
            BtnBuscar = new FontAwesome.Sharp.IconButton();
            TxtBuscarInscriptos = new TextBox();
            GridUsiarios = new DataGridView();
            label3 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GridInscripciones).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GridUsiarios).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-1, -1);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1215, 75);
            panel1.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(13, 19);
            label1.Name = "label1";
            label1.Size = new Size(230, 39);
            label1.TabIndex = 1;
            label1.Text = "Inscripciones";
            // 
            // ComboCapacitaciones
            // 
            ComboCapacitaciones.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboCapacitaciones.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ComboCapacitaciones.FormattingEnabled = true;
            ComboCapacitaciones.Location = new Point(177, 121);
            ComboCapacitaciones.Name = "ComboCapacitaciones";
            ComboCapacitaciones.Size = new Size(416, 39);
            ComboCapacitaciones.TabIndex = 9;
            ComboCapacitaciones.SelectedIndexChanged += ComboCapacitaciones_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 124);
            label2.Name = "label2";
            label2.Size = new Size(151, 31);
            label2.TabIndex = 10;
            label2.Text = "Capacitación:";
            // 
            // GridInscripciones
            // 
            GridInscripciones.AllowUserToAddRows = false;
            GridInscripciones.AllowUserToDeleteRows = false;
            GridInscripciones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GridInscripciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            GridInscripciones.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            GridInscripciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridInscripciones.Location = new Point(25, 187);
            GridInscripciones.Name = "GridInscripciones";
            GridInscripciones.ReadOnly = true;
            GridInscripciones.RowHeadersVisible = false;
            GridInscripciones.RowHeadersWidth = 51;
            GridInscripciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridInscripciones.Size = new Size(550, 410);
            GridInscripciones.TabIndex = 11;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(label4);
            panel2.Controls.Add(ComboTIpoInscripcion);
            panel2.Controls.Add(BtnAgregarUsuario);
            panel2.Controls.Add(BtnBuscar);
            panel2.Controls.Add(TxtBuscarInscriptos);
            panel2.Controls.Add(GridUsiarios);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(599, 100);
            panel2.Name = "panel2";
            panel2.Size = new Size(590, 511);
            panel2.TabIndex = 12;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(25, 364);
            label4.Name = "label4";
            label4.Size = new Size(208, 31);
            label4.TabIndex = 17;
            label4.Text = "TIpo de Inscripcion";
            // 
            // ComboTIpoInscripcion
            // 
            ComboTIpoInscripcion.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ComboTIpoInscripcion.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboTIpoInscripcion.Font = new Font("Segoe UI", 12F);
            ComboTIpoInscripcion.FormattingEnabled = true;
            ComboTIpoInscripcion.Location = new Point(25, 408);
            ComboTIpoInscripcion.Name = "ComboTIpoInscripcion";
            ComboTIpoInscripcion.Size = new Size(527, 36);
            ComboTIpoInscripcion.TabIndex = 16;
            // 
            // BtnAgregarUsuario
            // 
            BtnAgregarUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnAgregarUsuario.IconChar = FontAwesome.Sharp.IconChar.FileCirclePlus;
            BtnAgregarUsuario.IconColor = Color.Black;
            BtnAgregarUsuario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnAgregarUsuario.ImageAlign = ContentAlignment.MiddleLeft;
            BtnAgregarUsuario.Location = new Point(466, 85);
            BtnAgregarUsuario.Margin = new Padding(2);
            BtnAgregarUsuario.Name = "BtnAgregarUsuario";
            BtnAgregarUsuario.Size = new Size(118, 51);
            BtnAgregarUsuario.TabIndex = 15;
            BtnAgregarUsuario.Text = "&Agregar inscripto";
            BtnAgregarUsuario.TextAlign = ContentAlignment.MiddleRight;
            BtnAgregarUsuario.UseCompatibleTextRendering = true;
            BtnAgregarUsuario.UseVisualStyleBackColor = true;
            BtnAgregarUsuario.Click += BtnAgregarUsuario_Click;
            // 
            // BtnBuscar
            // 
            BtnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            BtnBuscar.IconColor = Color.Black;
            BtnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnBuscar.Location = new Point(353, 85);
            BtnBuscar.Margin = new Padding(2);
            BtnBuscar.Name = "BtnBuscar";
            BtnBuscar.Size = new Size(109, 51);
            BtnBuscar.TabIndex = 14;
            BtnBuscar.Text = "&Buscar";
            BtnBuscar.TextAlign = ContentAlignment.MiddleRight;
            BtnBuscar.UseVisualStyleBackColor = true;
            BtnBuscar.Click += BtnBuscar_Click;
            // 
            // TxtBuscarInscriptos
            // 
            TxtBuscarInscriptos.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtBuscarInscriptos.Location = new Point(25, 102);
            TxtBuscarInscriptos.Name = "TxtBuscarInscriptos";
            TxtBuscarInscriptos.PlaceholderText = "Buscar Inscriptos...";
            TxtBuscarInscriptos.Size = new Size(323, 34);
            TxtBuscarInscriptos.TabIndex = 13;
            TxtBuscarInscriptos.TextChanged += TxtBuscarInscriptos_TextChanged;
            TxtBuscarInscriptos.KeyPress += TxtBuscarInscriptos_KeyPress;
            // 
            // GridUsiarios
            // 
            GridUsiarios.AllowUserToAddRows = false;
            GridUsiarios.AllowUserToDeleteRows = false;
            GridUsiarios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GridUsiarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridUsiarios.Location = new Point(25, 163);
            GridUsiarios.Name = "GridUsiarios";
            GridUsiarios.ReadOnly = true;
            GridUsiarios.RowHeadersVisible = false;
            GridUsiarios.RowHeadersWidth = 51;
            GridUsiarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridUsiarios.Size = new Size(541, 190);
            GridUsiarios.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(19, 17);
            label3.Name = "label3";
            label3.Size = new Size(214, 31);
            label3.TabIndex = 11;
            label3.Text = "Agregar inscripción";
            // 
            // InscripcionesView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1212, 609);
            Controls.Add(panel2);
            Controls.Add(GridInscripciones);
            Controls.Add(label2);
            Controls.Add(ComboCapacitaciones);
            Controls.Add(panel1);
            Name = "InscripcionesView";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Inscripciones";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)GridInscripciones).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)GridUsiarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private ComboBox ComboCapacitaciones;
        private Label label2;
        private DataGridView GridInscripciones;
        private Panel panel2;
        private Label label3;
        private DataGridView GridUsiarios;
        private TextBox TxtBuscarInscriptos;
        private FontAwesome.Sharp.IconButton BtnBuscar;
        private FontAwesome.Sharp.IconButton BtnAgregarUsuario;
        private Label label4;
        private TextBox textBox1;
        private ComboBox ComboTIpoInscripcion;
        private TextBox TxtCosto;
    }
}