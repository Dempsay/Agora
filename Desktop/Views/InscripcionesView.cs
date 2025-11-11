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
using System.Windows.Controls;
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
            var GetComboTask = GetComboCapacitaciones();
            var GetGrillaTask = GetGrillaUsuarios();
            await Task.WhenAll(GetComboTask, GetGrillaTask);

        }

        private async Task GetGrillaUsuarios()
        {
            _usuarios = (await _usuarioService.GetAllAsync());
            _usuarios = _usuarios?.Where(u => _inscripciones != null && !_inscripciones.Any(i => i.UsuarioId == u.Id)).ToList();
            GridUsuarios.DataSource = _usuarios.OrderBy(u => u.Apellido).ThenBy(u => u.Nombre).ToList();
            GridUsuarios.HideColumns("Id", "DeleteDate", "IsDeleted");
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
                RefreshInscripciones(selectedCapacitacion);
                GetComboTiposDeInscripciones(selectedCapacitacion);
            }
        }

        private void GetComboTiposDeInscripciones(Capacitacion selectedCapacitacion)
        {
            ComboTIpoInscripcion.DataSource = selectedCapacitacion.TiposDeInscripciones.ToList();
            ComboTIpoInscripcion.DisplayMember = "TipoInscripcion";
            ComboTIpoInscripcion.ValueMember = "TipoInscripcionId";
            ComboTIpoInscripcion.SelectedIndex = -1;
        }

        private async void RefreshInscripciones(Capacitacion selectedCapacitacion)
        {
            _inscripciones = selectedCapacitacion.Inscripciones.ToList();
            //_inscripciones = await _inscripcionService.GetInscriptosAsync(selectedCapacitacion.Id);
            _inscripciones =_inscripciones?.OrderBy(i => i.Usuario.Apellido).ThenBy(i => i.Usuario.Nombre).ToList();
            GridInscripciones.DataSource = _inscripciones;
            GridInscripciones.HideColumns("Id", "UsuarioId", "TipoInscripcionId", "CapacitacionId", "Capacitacion", "UsuarioCobroId", "isDeleted", "UsuarioCobro", "Pagado");
            if (GridInscripciones.Columns.Contains("Importe"))
            {
                GridInscripciones.Columns["Importe"].DefaultCellStyle.Format = "C2";
                GridInscripciones.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            AgregarBotonAnularInscripcion();

            await GetGrillaUsuarios();
        }

        private void AgregarBotonAnularInscripcion()
        {
            if (GridInscripciones.Columns["Acciones"] == null)
            {
                // Agrego un botón para anular la inscripción
                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.Name = "Acciones"; // Especificamos el nombre para poder referenciarlo luego
                buttonColumn.HeaderText = "Acciones";
                buttonColumn.Text = "Anular inscripción";
                buttonColumn.UseColumnTextForButtonValue = true;
                GridInscripciones.Columns.Add(buttonColumn);
                // Defino el evento para el botón.
                GridInscripciones.CellContentClick += AnularInscripcion();
            }
        }

        private DataGridViewCellEventHandler AnularInscripcion()
        {
            return async (sender, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == GridInscripciones.Columns["Acciones"].Index)
                {
                    var selectedInscripcion = GridInscripciones.Rows[e.RowIndex].DataBoundItem as Inscripcion;
                    // obtenemos la inscripción seleccionada
                    if (selectedInscripcion == null)
                    {
                        MessageBox.Show("Seleccione una inscripción para anular.");
                        return;
                    }
                    //preguntamos si está seguro de anular la inscripción
                    var confirmResult = MessageBox.Show($"¿Está seguro de anular la inscripción de: {selectedInscripcion.Usuario}?", "Confirmar anulación", MessageBoxButtons.YesNo);
                    if (confirmResult != DialogResult.Yes)
                    {
                        return;
                    }
                    //selecciono la capacitación actual para actualizar
                    if (ComboCapacitaciones.SelectedItem is Capacitacion selectedCapacitacion)
                    {
                        selectedCapacitacion.Inscripciones.Remove(selectedInscripcion);
                        try
                        {
                            await _capacitacionService.UpdateAsync(selectedCapacitacion);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al anular la inscripción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            selectedCapacitacion.Inscripciones.Add(selectedInscripcion); // Revertir el cambio en caso de error
                            return;
                        }
                        RefreshInscripciones(selectedCapacitacion);
                    }
                    
                }
            };
        }
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            _usuarios = _usuarios?.Where(u => u.Nombre.Contains(TxtBuscarInscriptos.Text, StringComparison.OrdinalIgnoreCase) || u.Apellido.Contains(TxtBuscarInscriptos.Text, StringComparison.OrdinalIgnoreCase)).ToList();
            GridUsuarios.DataSource = null;
            GridUsuarios.DataSource = _usuarios;
            GridUsuarios.HideColumns("Id", "DeleteDate", "IsDeleted");
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

        private async void BtnAgregarUsuario_Click(object sender, EventArgs e)
        {
            //si no hay usuario seleccionado advierte y sale
            if (GridUsuarios.CurrentRow?.DataBoundItem is not Usuario selectedUsuario)
            {
                MessageBox.Show("Seleccione un usuario para inscribir.");
                return;
            }
            //si no hay capacitación seleccionada advierte y sale
            if (ComboCapacitaciones.SelectedItem is not Capacitacion selectedCapacitacion)
            {
                MessageBox.Show("Seleccione una capacitación para inscribir al usuario.");
                return;
            }
            //si no hay un tipo de inscripción seleccionado advierte y sale
            if (ComboTIpoInscripcion.SelectedItem is not TipoInscripcionCapacitacion selectedTipoInscipcion)
            {
                MessageBox.Show("La capacitación seleccionada no tiene tipos de inscripción disponibles.");
                return;
            }
            var nuevaInscripcion = new Inscripcion
            {
                UsuarioId = selectedUsuario.Id,
                Usuario = selectedUsuario,
                Importe = selectedTipoInscipcion.Costo,
                CapacitacionId = selectedCapacitacion.Id,
                TipoInscripcionId = selectedTipoInscipcion.TipoInscripcionId,
                TipoInscripcion = selectedTipoInscipcion.TipoInscripcion,
                UsuarioCobroId = null
            };
            selectedCapacitacion.Inscripciones.Add(nuevaInscripcion);
            RefreshInscripciones(selectedCapacitacion);
            try
            {
                await _capacitacionService.UpdateAsync(selectedCapacitacion);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inscribir el usuario: {ex.Message}");
            }
            await _capacitacionService.UpdateAsync(selectedCapacitacion);

        }

        private void GridInscripciones_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuInscripcion.Show(GridInscripciones, new Point(e.X, e.Y));
            }
        }
    }
}
