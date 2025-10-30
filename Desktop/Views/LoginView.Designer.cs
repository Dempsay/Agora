namespace Desktop.Views
{
    partial class LoginView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginView));
            pictureBox1 = new PictureBox();
            BtnIniciarSesion = new FontAwesome.Sharp.IconButton();
            BtnCancelar = new FontAwesome.Sharp.IconButton();
            CheckVerContraseña = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            TxtEmail = new TextBox();
            TxtContraseña = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(50, 88);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(249, 246);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // BtnIniciarSesion
            // 
            BtnIniciarSesion.IconChar = FontAwesome.Sharp.IconChar.None;
            BtnIniciarSesion.IconColor = Color.Black;
            BtnIniciarSesion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnIniciarSesion.Location = new Point(406, 267);
            BtnIniciarSesion.Name = "BtnIniciarSesion";
            BtnIniciarSesion.Size = new Size(135, 60);
            BtnIniciarSesion.TabIndex = 3;
            BtnIniciarSesion.Text = "Iniciar Sesion";
            BtnIniciarSesion.UseVisualStyleBackColor = true;
            BtnIniciarSesion.Click += BtnIniciarSesion_Click;
            // 
            // BtnCancelar
            // 
            BtnCancelar.IconChar = FontAwesome.Sharp.IconChar.Cancel;
            BtnCancelar.IconColor = Color.Black;
            BtnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnCancelar.Location = new Point(558, 267);
            BtnCancelar.Name = "BtnCancelar";
            BtnCancelar.Size = new Size(120, 60);
            BtnCancelar.TabIndex = 4;
            BtnCancelar.Text = "Cancelar";
            BtnCancelar.TextAlign = ContentAlignment.MiddleRight;
            BtnCancelar.UseVisualStyleBackColor = true;
            BtnCancelar.Click += BtnCancelar_Click;
            // 
            // CheckVerContraseña
            // 
            CheckVerContraseña.AutoSize = true;
            CheckVerContraseña.Location = new Point(508, 122);
            CheckVerContraseña.Name = "CheckVerContraseña";
            CheckVerContraseña.Size = new Size(128, 24);
            CheckVerContraseña.TabIndex = 5;
            CheckVerContraseña.Text = "Ver contraseña";
            CheckVerContraseña.UseVisualStyleBackColor = true;
            CheckVerContraseña.CheckedChanged += CheckVerContraseña_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(443, 63);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 6;
            label1.Text = "Email:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(406, 96);
            label2.Name = "label2";
            label2.Size = new Size(86, 20);
            label2.TabIndex = 7;
            label2.Text = "Contraseña:";
            // 
            // TxtEmail
            // 
            TxtEmail.Location = new Point(508, 56);
            TxtEmail.Name = "TxtEmail";
            TxtEmail.Size = new Size(196, 27);
            TxtEmail.TabIndex = 8;
            TxtEmail.KeyPress += TxtEmail_KeyPress;
            // 
            // TxtContraseña
            // 
            TxtContraseña.Location = new Point(508, 89);
            TxtContraseña.Name = "TxtContraseña";
            TxtContraseña.PasswordChar = '*';
            TxtContraseña.Size = new Size(196, 27);
            TxtContraseña.TabIndex = 9;
            TxtContraseña.TextChanged += TxtContraseña_TextChanged;
            TxtContraseña.KeyPress += TxtContraseña_KeyPress;
            // 
            // LoginView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(TxtContraseña);
            Controls.Add(TxtEmail);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(CheckVerContraseña);
            Controls.Add(BtnCancelar);
            Controls.Add(BtnIniciarSesion);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginView";
            Text = "LoginView";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton BtnIniciarSesion;
        private FontAwesome.Sharp.IconButton BtnCancelar;
        private CheckBox CheckVerContraseña;
        private Label label1;
        private Label label2;
        private TextBox TxtEmail;
        private TextBox TxtContraseña;
    }
}