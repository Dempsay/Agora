using System.Data;
using System.Threading.Tasks;
using Service.Models;
using Service.Services;
using Service.Enums;

namespace Desktop.Views
{
    public partial class UsuariosView : Form
    {
        GenericService<Usuario> _usuarioService = new GenericService<Usuario>();
        Usuario _currentUsuario;
        List<Usuario>? _usuarios;

        public UsuariosView()
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
                _usuarios = await _usuarioService.GetAllDeletedsAsync();
            }
            else
            {
                _usuarios = await _usuarioService.GetAllAsync();
            }
            DataGrid.DataSource = _usuarios;
            DataGrid.Columns["Id"].Visible = false;
            DataGrid.Columns["IsDeleted"].Visible = false;
            DataGrid.Columns["DeleteDate"].Visible = false;

            await GetComboTiposDeUsuarios();
        }
        private async Task GetComboTiposDeUsuarios()
        {
            //cargo el combo con el enum TipoUsuario
            ComboTiposDeUsuarios.DataSource = Enum.GetValues(typeof(TipoUsuarioEnum));
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
                Usuario entitySelected = (Usuario)DataGrid.SelectedRows[0].DataBoundItem;
                var respuesta = MessageBox.Show($"¿Seguro que desea eliminar este usuario {entitySelected.Nombre}?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    if (await _usuarioService.DeleteAsync(entitySelected.Id))
                    {
                        LabelStatusMessage.Text = $"Usuario {entitySelected.Nombre} eliminado correctamente";
                        TimerStatusBar.Start(); // Iniciar el temporizador para mostrar el mensaje en la barra de estado
                        await GetAllData();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el Usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Usuario para eliminarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            TxtDni.Clear();
            TxtApellido.Clear();
            TxtEmail.Clear();
            GetComboTiposDeUsuarios();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            TabControl.SelectedTab = TabPageLista;

        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            Usuario usuarioAGuardar = new Usuario
            {
                Id = _currentUsuario?.Id ?? 0,
                Nombre = TxtNombre.Text,
                Apellido = TxtApellido.Text,
                Dni = TxtDni.Text,
                Email = TxtEmail.Text,
                TipoUsuario = (TipoUsuarioEnum)(ComboTiposDeUsuarios.SelectedItem ?? TipoUsuarioEnum.Asistente)

            };
            bool response = false;
            if (_currentUsuario != null)
            {
                response = await _usuarioService.UpdateAsync(usuarioAGuardar);
            }
            else
            {
                var nuevousuario = await _usuarioService.AddAsync(usuarioAGuardar);
                response = nuevousuario != null;
            }
            if (response)
            {
                _currentUsuario = null; // Reset the modified movie after saving
                LabelStatusMessage.Text = $"Usuario {usuarioAGuardar.Nombre} guardado correctamente";
                TimerStatusBar.Start(); // Iniciar el temporizador para mostrar el mensaje en la barra de estado
                await GetAllData();
                LimpiarControlesAgregarEditar();
                TabControl.SelectedTab = TabPageLista;
            }
            else
            {
                MessageBox.Show("Error al agregar al Usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            //checheamos que haya capacitacion seleccionadas
            if (DataGrid.RowCount > 0 && DataGrid.SelectedRows.Count > 0)
            {
                _currentUsuario = (Usuario)DataGrid.SelectedRows[0].DataBoundItem;
                TxtNombre.Text = _currentUsuario.Nombre;
                TxtApellido.Text = _currentUsuario.Apellido;
                TxtDni.Text = _currentUsuario.Dni;
                TxtEmail.Text = _currentUsuario.Email;
                ComboTiposDeUsuarios.SelectedItem = _currentUsuario.TipoUsuario;
                TabControl.SelectedTab = TabPageAgregarEditar;

            }
            else
            {
                MessageBox.Show("Debe seleccionar un Usuario a modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnBuscar_Click(object sender, EventArgs e)
        {
            DataGrid.DataSource = await _usuarioService.GetAllAsync(TxtBuscar.Text);
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
                Usuario entitySelected = (Usuario)DataGrid.SelectedRows[0].DataBoundItem;
                var respuesta = MessageBox.Show($"¿Está seguro de recuperar este usuario {entitySelected.Nombre} seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    if (await _usuarioService.RestoreAsync(entitySelected.Id))
                    {
                        LabelStatusMessage.Text = $"Usuario {entitySelected.Nombre} restaurado correctamente";
                        TimerStatusBar.Start();
                        await GetAllData();
                    }
                    else
                    {
                        MessageBox.Show("Error al restaurar el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario para restaurar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
