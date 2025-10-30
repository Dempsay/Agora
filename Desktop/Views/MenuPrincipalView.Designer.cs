namespace Desktop
{
    partial class MenuPrincipalView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            MenuPrincipal = new FontAwesome.Sharp.IconMenuItem();
            SubMenuUsuarios = new FontAwesome.Sharp.IconMenuItem();
            SubMenuCapacitaciones = new FontAwesome.Sharp.IconMenuItem();
            SubMenuTiposDeInscripciones = new FontAwesome.Sharp.IconMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            SubMenuInscripciones = new FontAwesome.Sharp.IconMenuItem();
            MenuSalir = new FontAwesome.Sharp.IconMenuItem();
            SubMenuSalirDelSistema = new FontAwesome.Sharp.IconMenuItem();
            SubMenuCerrarSesion = new FontAwesome.Sharp.IconMenuItem();
            toolStrip1 = new ToolStrip();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { MenuPrincipal, MenuSalir });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // MenuPrincipal
            // 
            MenuPrincipal.DropDownItems.AddRange(new ToolStripItem[] { SubMenuUsuarios, SubMenuCapacitaciones, SubMenuTiposDeInscripciones, toolStripSeparator1, SubMenuInscripciones });
            MenuPrincipal.IconChar = FontAwesome.Sharp.IconChar.HomeLg;
            MenuPrincipal.IconColor = Color.Black;
            MenuPrincipal.IconFont = FontAwesome.Sharp.IconFont.Auto;
            MenuPrincipal.Name = "MenuPrincipal";
            MenuPrincipal.Size = new Size(100, 24);
            MenuPrincipal.Text = "Principal";
            // 
            // SubMenuUsuarios
            // 
            SubMenuUsuarios.IconChar = FontAwesome.Sharp.IconChar.UserFriends;
            SubMenuUsuarios.IconColor = Color.Black;
            SubMenuUsuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            SubMenuUsuarios.Name = "SubMenuUsuarios";
            SubMenuUsuarios.Size = new Size(238, 26);
            SubMenuUsuarios.Text = "Usuarios";
            SubMenuUsuarios.Click += SubMenuUsuarios_Click;
            // 
            // SubMenuCapacitaciones
            // 
            SubMenuCapacitaciones.IconChar = FontAwesome.Sharp.IconChar.Book;
            SubMenuCapacitaciones.IconColor = Color.Black;
            SubMenuCapacitaciones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            SubMenuCapacitaciones.Name = "SubMenuCapacitaciones";
            SubMenuCapacitaciones.Size = new Size(238, 26);
            SubMenuCapacitaciones.Text = "Capacitaciones";
            SubMenuCapacitaciones.Click += SubMenuCapacitaciones_Click;
            // 
            // SubMenuTiposDeInscripciones
            // 
            SubMenuTiposDeInscripciones.IconChar = FontAwesome.Sharp.IconChar.PeopleGroup;
            SubMenuTiposDeInscripciones.IconColor = Color.Black;
            SubMenuTiposDeInscripciones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            SubMenuTiposDeInscripciones.Name = "SubMenuTiposDeInscripciones";
            SubMenuTiposDeInscripciones.Size = new Size(238, 26);
            SubMenuTiposDeInscripciones.Text = "TIpos de Inscripciones";
            SubMenuTiposDeInscripciones.Click += SubMenuTiposDeInscripciones_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(235, 6);
            // 
            // SubMenuInscripciones
            // 
            SubMenuInscripciones.IconChar = FontAwesome.Sharp.IconChar.Pencil;
            SubMenuInscripciones.IconColor = Color.Black;
            SubMenuInscripciones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            SubMenuInscripciones.Name = "SubMenuInscripciones";
            SubMenuInscripciones.Size = new Size(238, 26);
            SubMenuInscripciones.Text = "Inscripciones";
            SubMenuInscripciones.Click += SubMenuInscripciones_Click;
            // 
            // MenuSalir
            // 
            MenuSalir.DropDownItems.AddRange(new ToolStripItem[] { SubMenuSalirDelSistema, SubMenuCerrarSesion });
            MenuSalir.IconChar = FontAwesome.Sharp.IconChar.DoorClosed;
            MenuSalir.IconColor = Color.Black;
            MenuSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            MenuSalir.Name = "MenuSalir";
            MenuSalir.Size = new Size(72, 24);
            MenuSalir.Text = "Salir";
            // 
            // SubMenuSalirDelSistema
            // 
            SubMenuSalirDelSistema.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            SubMenuSalirDelSistema.IconColor = Color.Black;
            SubMenuSalirDelSistema.IconFont = FontAwesome.Sharp.IconFont.Auto;
            SubMenuSalirDelSistema.Name = "SubMenuSalirDelSistema";
            SubMenuSalirDelSistema.Size = new Size(224, 26);
            SubMenuSalirDelSistema.Text = "Salir del Sistema";
            SubMenuSalirDelSistema.Click += SubMenuSalirDelSistema_Click;
            // 
            // SubMenuCerrarSesion
            // 
            SubMenuCerrarSesion.IconChar = FontAwesome.Sharp.IconChar.None;
            SubMenuCerrarSesion.IconColor = Color.Black;
            SubMenuCerrarSesion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            SubMenuCerrarSesion.Name = "SubMenuCerrarSesion";
            SubMenuCerrarSesion.Size = new Size(224, 26);
            SubMenuCerrarSesion.Text = "Cerrar Sesion";
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Location = new Point(0, 28);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // MenuPrincipalView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "MenuPrincipalView";
            Text = "Ágora: Software de acreditacion de capacitaciones Isp20";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStrip toolStrip1;
        private FontAwesome.Sharp.IconMenuItem MenuPrincipal;
        private FontAwesome.Sharp.IconMenuItem MenuSalir;
        private FontAwesome.Sharp.IconMenuItem SubMenuSalirDelSistema;
        private FontAwesome.Sharp.IconMenuItem SubMenuUsuarios;
        private FontAwesome.Sharp.IconMenuItem SubMenuCapacitaciones;
        private FontAwesome.Sharp.IconMenuItem SubMenuTiposDeInscripciones;
        private ToolStripSeparator toolStripSeparator1;
        private FontAwesome.Sharp.IconMenuItem SubMenuInscripciones;
        private FontAwesome.Sharp.IconMenuItem SubMenuCerrarSesion;
    }
}
