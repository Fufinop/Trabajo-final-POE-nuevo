using Entidad;
using MySql.Data.MySqlClient;

namespace Datos
{
    public class CdLogin
    {
        string cadenaConexion = "Server=localhost;User=root;Password=root;database=Empresa";

        public void ComprobarUsuario(CeLogin cE)
        {

            MySqlConnection conectar = new MySqlConnection("server=localhost;user=root;database=empresa; port=3306;password=root;");
            conectar.Open();
            MySqlCommand codigo = new MySqlCommand();
            MySqlConnection conectanos = new MySqlConnection();
            codigo.Connection = conectar;
            codigo.CommandText = ("SELECT * FROM users WHERE LoginName ='" + cE.LoginName + "' and PASSWORD='" + cE.Password + "'");
            MySqlDataReader leer = codigo.ExecuteReader();
            if (leer.Read())
            {
                MessageBox.Show("Bienvenido");

                cE.tipoUsuario = leer.GetString(1);

                MessageBox.Show("" + cE.tipoUsuario);
                //Principal principal = new Principal();

                if (cE.tipoUsuario == "Admin")
                {
                    //principal.ibtnEmpleados.enabled = true;
                }
                else if (cE.tipoUsuario == "EMPLEADO")
                {

                }
            }
            else
            {
                MessageBox.Show("Usuario y contraseña incorrectos");
                
            }
            conectar.Close();
            /**/

        }


    }
}
