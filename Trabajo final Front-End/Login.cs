using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Trabajo_final_Front_End
{
    public partial class Login : Form
    {
        CnLogin cnLogin = new CnLogin();
        private object tipo;

        public Login()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            

            bool resultado;
            CeLogin ceLogin = new CeLogin();
            
            ceLogin.LoginName = txtUsuario.Text;
            ceLogin.Password = txtPassword.Text;

            resultado = cnLogin.validarDatos(ceLogin);

            if (resultado == false)
            {
                return;
            } 

            cnLogin.ConectarUsuario(ceLogin);
            Principal principal = new Principal(tipo);

            //this.Close();
            if (cbxTipo.Text == "Admin")
            {
                tipo = cbxTipo.Text;   
                
            }
            else if (cbxTipo.Text == "Empleado")
            {

            }
            else
            {
                MessageBox.Show("Tipo de usuario no valido");
            }

            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
