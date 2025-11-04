using System.Data;
using System.Threading.Tasks;
using Service.Models;
using Service.Services;
using Service.Enums;
using Firebase.Auth;
using Firebase.Auth.Providers;
using System.Net.Http.Headers;
// 25 209 750 - 83562
//
namespace Desktop.Views
{
    public partial class UsuariosView : Form
    {
        FirebaseAuthClient _firebaseAuthClient;
        GenericService<Usuario> _usuarioService = new GenericService<Usuario>();
        Usuario _currentUsuario;
        List<Usuario>? _usuarios;

        public UsuariosView()
        {
            InitializeComponent();
            _ = GetAllData();
            SettingFirebase();
            CheckVerEliminados.CheckedChanged += DisplayHideControlsRestoreButton;

        }

        private void SettingFirebase()
        {
            var config = new FirebaseAuthConfig()
            {
                ApiKey = Service.Properties.Resources.ApiKeyFireBase,
                AuthDomain = Service.Properties.Resources.AuthDomainFireBase,
                Providers = new FirebaseAuthProvider[]
    {
         new EmailProvider()

    }
            };
            _firebaseAuthClient = new FirebaseAuthClient(config);
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
            try
            {
            if (CheckVerEliminados.Checked)
            {
                _usuarios = await _usuarioService.GetAllDeletedsAsync();
            }
            else
            {
                _usuarios = await _usuarioService.GetAllAsync();
            }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error al obtener los usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
            TxtPassword.Clear();
            TxtPassword2.Clear();
            GetComboTiposDeUsuarios();
            LabelPassword.Text = "Contraseña";
            LabelPassword2.Text = "Repetir Contraseña";
            TxtPassword.PlaceholderText = "Minimo 6 caracteres";
            TxtPassword2.PlaceholderText = "Minimo 6 caracteres";
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            TabControl.SelectedTab = TabPageLista;

        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!DataControl())
                return;

            Usuario usuarioAGuardar = GetUserDataFromScreen();
            bool responseSuccessfull = false;
            if (_currentUsuario != null)
            {
                responseSuccessfull = await _usuarioService.UpdateAsync(usuarioAGuardar);
                if (responseSuccessfull && !string.IsNullOrWhiteSpace(TxtPassword.Text))
                    await UpdatePasswordInFirebase(usuarioAGuardar);// Modificar la contraseña en Firebase Authentication

            }
            if (_currentUsuario == null)//agregamos un nuevo usuario
            {
                try
                {
                    var nuevousuario = await _usuarioService.AddAsync(usuarioAGuardar);
                    responseSuccessfull = nuevousuario != null;
                    if (responseSuccessfull)
                        await CreateUserInFirebase(nuevousuario);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar el Usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (!responseSuccessfull)
            {
                MessageBox.Show("Error al guardar el Usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _currentUsuario = null; // Reset the modified movie after saving
            LabelStatusMessage.Text = $"Usuario {usuarioAGuardar.Nombre} guardado correctamente";
            TimerStatusBar.Start(); // Iniciar el temporizador para mostrar el mensaje en la barra de estado
            await GetAllData();
            LimpiarControlesAgregarEditar();
            TabControl.SelectedTab = TabPageLista;
        }

        private async Task CreateUserInFirebase(Usuario? nuevousuario)
        {
            try
            {
                var userCredential = await _firebaseAuthClient.CreateUserWithEmailAndPasswordAsync(
                    nuevousuario.Email,
                    TxtPassword.Text.Trim(),
                    nuevousuario.Nombre + " " + nuevousuario.Apellido// Contraseña por defecto, se recomienda cambiarla luego
                );
                await SendEmailVerificationAsync(userCredential.User.GetIdTokenAsync().Result);
            }
            catch (FirebaseAuthException ex)
            {
                MessageBox.Show($"Error al crear el usuario en Firebase: {ex.Reason}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task UpdatePasswordInFirebase(Usuario usuarioAGuardar)
        {
            try
            {
                var userCredential = await _firebaseAuthClient.SignInWithEmailAndPasswordAsync(
                    usuarioAGuardar.Email,
                    TxtPassword.Text.Trim() // Contraseña actual
                );
                await userCredential.User.ChangePasswordAsync(
                    TxtPassword2.Text.Trim() // Nueva contraseña
                );
            }
            catch (FirebaseAuthException ex)
            {
                MessageBox.Show($"Error al modificar la contraseña en Firebase: {ex.Reason}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Usuario GetUserDataFromScreen()
        {
            return new Usuario
            {
                Id = _currentUsuario?.Id ?? 0,
                Nombre = TxtNombre.Text,
                Apellido = TxtApellido.Text,
                Dni = TxtDni.Text,
                Email = TxtEmail.Text,
                TipoUsuario = (TipoUsuarioEnum)(ComboTiposDeUsuarios.SelectedItem ?? TipoUsuarioEnum.Asistente)

            };
        }

        private bool DataControl()
        {
            //valiidaciones simples 
            if (string.IsNullOrWhiteSpace(TxtNombre.Text))
            {
                MessageBox.Show("El campo Nombre es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(TxtApellido.Text))
            {
                MessageBox.Show("El campo Apellido es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(TxtDni.Text))
            {
                MessageBox.Show("El campo DNI es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(TxtEmail.Text))
            {
                MessageBox.Show("El campo Email es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_currentUsuario == null && (TxtPassword.Text != TxtPassword2.Text))
            {
                MessageBox.Show("Las contraseñas ingresadas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_currentUsuario == null && (string.IsNullOrWhiteSpace(TxtPassword.Text) || string.IsNullOrWhiteSpace(TxtPassword2.Text)))
            {
                MessageBox.Show("Debe completar el campo contraseña y su verificacion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_currentUsuario != null && (string.IsNullOrWhiteSpace(TxtPassword.Text) && string.IsNullOrWhiteSpace(TxtPassword2.Text)))//modificacion que no cambia la contraseña
            {
                return true;
            }
            if (_currentUsuario != null && (string.IsNullOrWhiteSpace(TxtPassword.Text) || string.IsNullOrWhiteSpace(TxtPassword2.Text)))
            {
                MessageBox.Show("Para modificar la contraseña debe completar la contraseña anterior y nueva.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if ((TxtPassword.Text.Length < 6) || (TxtPassword2.Text.Length < 6))
            {
                MessageBox.Show("Las contraseñas deben tener al menos 6 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;

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
                

                LabelPassword.Text = "Contraseña anterior";
                LabelPassword2.Text = "Nueva contraseña";
                TxtPassword.PlaceholderText = "Dejar en blanco para no modificar";
                TxtPassword2.PlaceholderText = "Dejar en blanco para no modificar";
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

        public async Task SendEmailVerificationAsync(string idToken)
        {
            var FirebaseApiKey = Service.Properties.Resources.ApiKeyFireBase;
            var RequestUri = "https://identitytoolkit.googleapis.com/v1/accounts:sendOobCode?key=" + FirebaseApiKey;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent("{\"requestType\":\"VERIFY_EMAIL\",\"idToken\":\"" + idToken + "\"}");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PostAsync(RequestUri, content);
                response.EnsureSuccessStatusCode();
            }
        }     
    }
}
