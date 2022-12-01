using Entidad;
using Negocio;

namespace Trabajo_final_Front_End
{
    public partial class Login : Form
    {
        
        public object tipo;

        public Login()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            CnLogin cnLogin = new CnLogin();
            bool resultado;
            CeLogin ceLogin = new CeLogin();
            
            ceLogin.LoginName = txtUsuario.Text;
            ceLogin.Password = txtPassword.Text;
            ceLogin.tipoUsuario = cbxTipo.Text;

            resultado = cnLogin.validarDatos(ceLogin);

            if (resultado == false)
            {
                return;
            } 

            cnLogin.ConectarUsuario(ceLogin);
            Principal principal = new Principal();

            //this.Close();
            if (cbxTipo.Text == "Admin")
            {
                principal.Show();
                this.Hide();

            }
            else if (cbxTipo.Text == "Empleado")
            {
                principal.Show();
                this.Hide();
            }

            
            
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void lbprueba_Click(object sender, EventArgs e)
        {

        }
    }
}
