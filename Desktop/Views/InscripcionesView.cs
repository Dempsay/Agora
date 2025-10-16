using Desktop.ExtensionMetthd;
using Service.Models;
using Service.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class InscripcionesView : Form
    {
        GenericService<Capacitacion> _capacitacionService = new();
        GenericService<Usuario> _usuarioService = new();
        InscripcionService _inscripcionService = new();
        List<Inscripcion>? _inscripciones = new();
        List<Usuario>? _usuarios = new();
        public InscripcionesView()
        {
            InitializeComponent();
            _ = GetAllData();
        }
        private async Task GetAllData()
        {
            await GetComboCapacitaciones();
            await GetGrillaUsuarios();

        }

        private async Task GetGrillaUsuarios()
        {
            _usuarios = (await _usuarioService.GetAllAsync());
            _usuarios = _usuarios?.Where(u => _inscripciones != null && !_inscripciones.Any(i => i.UsuarioId == u.Id)).ToList();
            GridUsiarios.DataSource = _usuarios;
            GridUsiarios.HideColumns("Id", "DeleteDate", "IsDeleted");
        }

        private async Task GetComboCapacitaciones()
        {
            var capacitaciones = await _capacitacionService.GetAllAsync();
            ComboCapacitaciones.DataSource = capacitaciones?.Where(c => c.InscripcionAbierta).ToList();
            ComboCapacitaciones.DisplayMember = "Nombre";
            ComboCapacitaciones.ValueMember = "Id";
        }

        private async void ComboCapacitaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            //controlamos que no sea null y haya una capacitación seleccionada
            if (ComboCapacitaciones.SelectedItem is Capacitacion selectedCapacitacion)
            {
                _inscripciones = await _inscripcionService.GetInscriptosAsync(selectedCapacitacion.Id);
                GridInscripciones.DataSource = _inscripciones;
                GridInscripciones.HideColumns("Id", "UsuarioId", "TipoInscripcionId", "CapacitacionId", "Capacitacion", "UsuarioCobroId", "isDeleted");
                await GetGrillaUsuarios();
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            _usuarios = _usuarios?.Where(u => u.Nombre.Contains(TxtBuscarInscriptos.Text, StringComparison.OrdinalIgnoreCase) || u.Apellido.Contains(TxtBuscarInscriptos.Text, StringComparison.OrdinalIgnoreCase)).ToList();
            GridUsiarios.DataSource = null;
            GridUsiarios.DataSource = _usuarios;
            GridUsiarios.HideColumns("Id", "DeleteDate", "IsDeleted");
        }

        private async void TxtBuscarInscriptos_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtBuscarInscriptos.Text))
            {
                await GetGrillaUsuarios();

            }
        }

        private void TxtBuscarInscriptos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                BtnBuscar.PerformClick();
                e.Handled = true;
            }
        }
    }
}
