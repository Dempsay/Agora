using System.Data;
using System.Threading.Tasks;
using Service.Models;
using Service.Services;

namespace Desktop.Views
{
    public partial class TipoInscripcionView : Form
    {
        GenericService<TipoInscripcion> _tipoInscripcionService = new();
        TipoInscripcion _currentTipoInscripcion;
        List<TipoInscripcion>? _tiposInscripciones;

        public TipoInscripcionView()
        {
            InitializeComponent();
            _ = GetAllData();
            CheckVerEliminados.CheckedChanged += DisplayHideControlsRestoreButton;

        }
        //ocultamos los botones cuando el checkbox cambia pero que no este relacionado con el evento del checkbox
        private void DisplayHideControlsRestoreButton(object sender, EventArgs e)
        {
            BtnRestaurar.Visible = CheckVerEliminados.Checked;
            BtnEliminar.Enabled = !CheckVerEliminados.Checked;
            BtnModificar.Enabled = !CheckVerEliminados.Checked;
            BtnAgregar.Enabled = !CheckVerEliminados.Checked;
            BtnModificar.Enabled = !CheckVerEliminados.Checked;
            BtnBuscar.Enabled = !CheckVerEliminados.Checked;

        }
        private async Task GetAllData()
        {
            if (CheckVerEliminados.Checked)
            {
                _tiposInscripciones = await _tipoInscripcionService.GetAllDeletedsAsync();
            }
            else
            {
                _tiposInscripciones = await _tipoInscripcionService.GetAllAsync();
            }
            DataGrid.DataSource = _tiposInscripciones;
            DataGrid.Columns["Id"].Visible = false;
            DataGrid.Columns["IsDeleted"].Visible = false;
        }

        private void GridPeliculas_SelectionChanged_1(object sender, EventArgs e)
        {
            if (DataGrid.RowCount > 0 && DataGrid.SelectedRows.Count > 0)
            {
                //Capacitacion _curr = (Pelicula)GridPeliculas.SelectedRows[0].DataBoundItem;
                //FilmPicture.ImageLocation = peliSeleccionada.portada;
            }
        }

        private async void BtnEliminar_Click_1(object sender, EventArgs e)
        {
            //checheamos que haya peliculas seleccionadas
            if (DataGrid.RowCount > 0 && DataGrid.SelectedRows.Count > 0)
            {
                TipoInscripcion entitySelected = (TipoInscripcion)DataGrid.SelectedRows[0].DataBoundItem;
                var respuesta = MessageBox.Show($"¿Seguro que desea eliminar la Inscripcion {entitySelected.Nombre}?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    if (await _tipoInscripcionService.DeleteAsync(entitySelected.Id))
                    {
                        LabelStatusMessage.Text = $"Tipo Inscripcion {entitySelected.Nombre} eliminada correctamente";
                        TimerStatusBar.Start(); // Iniciar el temporizador para mostrar el mensaje en la barra de estado
                        await GetAllData();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el Tipo de Inscripcion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un tipo de inscripcion a eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            LimpiarControlesAgregarEditar();
            TabControl.SelectedTab = TabPageAgregarEditar;
        }

        private void LimpiarControlesAgregarEditar()
        {
            TxtNombre.Clear();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            TabControl.SelectedTab = TabPageLista;

        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            TipoInscripcion entidadAGuardar = new TipoInscripcion
            {
                Id = _currentTipoInscripcion?.Id?? 0, 
                Nombre = TxtNombre.Text,

            };
            bool response = false;
            if (_currentTipoInscripcion != null)
            {
                 response = await _tipoInscripcionService.UpdateAsync(entidadAGuardar);
            }
            else
            {
               var nuevaentidad = await _tipoInscripcionService.AddAsync(entidadAGuardar);
                response = nuevaentidad != null;
            }
            if (response)
            {
                _currentTipoInscripcion = null; // Reset the modified movie after saving
                LabelStatusMessage.Text = $"Tipo de inscripcion {entidadAGuardar.Nombre} guardada correctamente";
                TimerStatusBar.Start(); // Iniciar el temporizador para mostrar el mensaje en la barra de estado
                await GetAllData();
                LimpiarControlesAgregarEditar();
                TabControl.SelectedTab=TabPageLista;
            }
            else
            {
                MessageBox.Show("Error al agregar el tipo de inscripcion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            //checheamos que haya capacitacion seleccionadas
             if (DataGrid.RowCount > 0 && DataGrid.SelectedRows.Count > 0)
            {
                _currentTipoInscripcion = (TipoInscripcion)DataGrid.SelectedRows[0].DataBoundItem;
                TxtNombre.Text = _currentTipoInscripcion.Nombre;
                TabControl.SelectedTab = TabPageAgregarEditar;
                
            }
            else
            {
                MessageBox.Show("Debe seleccionar un tipo de inscripcion a modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnBuscar_Click(object sender, EventArgs e)
        {
              DataGrid.DataSource = await _tipoInscripcionService.GetAllAsync(TxtBuscar.Text);
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            
               // BtnBuscar.PerformClick();
            
        }

        private void TimerStatusBar_Tick(object sender, EventArgs e)
        {
            LabelStatusMessage.Text = string.Empty;
            TimerStatusBar.Stop(); // Detener el temporizador después de mostrar el mensaje
        }

        private async void CheckVerEliminados_CheckedChanged(object sender, EventArgs e)
        {
            await GetAllData();
        }

        private async void BtnRestaurar_Click(object sender, EventArgs e)
        {
            if (!CheckVerEliminados.Checked) return;
            //chequeamos que haya películas seleccionadas
            if (DataGrid.Rows.Count > 0 && DataGrid.SelectedRows.Count > 0)
            {
                Capacitacion entitySelected = (Capacitacion)DataGrid.SelectedRows[0].DataBoundItem;
                var respuesta = MessageBox.Show($"¿Está seguro de recuperar la capacitación {entitySelected.Nombre} seleccionada?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    if (await _tipoInscripcionService.RestoreAsync(entitySelected.Id))
                    {
                        LabelStatusMessage.Text = $"Capacitación {entitySelected.Nombre} restaurada correctamente";
                        TimerStatusBar.Start();
                        await GetAllData();
                    }
                    else
                    {
                        MessageBox.Show("Error al restaurar la capacitacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una capacitación para restaurar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
