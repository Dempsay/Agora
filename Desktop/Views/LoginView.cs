using Firebase.Auth;
using Firebase.Auth.Providers;
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
    public partial class LoginView : Form
    {
        FirebaseAuthClient _firebaseAuthClient;
        int LoginFailCount = 0;
        public LoginView()
        {
            InitializeComponent();
            SettingFirebase();
        }

        private void SettingFirebase()
        {
            var config = new FirebaseAuthConfig
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

        private async void BtnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                UserCredential userCredential = await _firebaseAuthClient.SignInWithEmailAndPasswordAsync(TxtEmail.Text, TxtContraseña.Text);
                if (userCredential != null && !string.IsNullOrEmpty(userCredential.User.Uid))
                {
                    this.Hide();
                    var MenuPrincipalView = new MenuPrincipalView();
                    MenuPrincipalView.ShowDialog();
                    this.Close();
                }
            }
            catch (FirebaseAuthException ex)
            {
                MessageBox.Show("Error al iniciar sesión");
                LoginFailCount++;
                if (LoginFailCount >= 3)
                {
                    MessageBox.Show("Ha superado el número máximo de intentos. La aplicación se cerrará.");
                    this.Close();
                }
            }
        }

        private void TxtContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CheckVerContraseña_CheckedChanged(object sender, EventArgs e)
        {
            TxtContraseña.PasswordChar = CheckVerContraseña.Checked ? '\0' : '*';
        }

        private void TxtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                BtnIniciarSesion.PerformClick();
                e.Handled = true;
            }
        }

        private void TxtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            //hacemos que al pulsar enter en el txtEmail se pase al txtContraseña
            if (e.KeyChar == (char)Keys.Enter)
            {
                TxtContraseña.Focus();
                e.Handled = true;
            }
        }
    }
}
