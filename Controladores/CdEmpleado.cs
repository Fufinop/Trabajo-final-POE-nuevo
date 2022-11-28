using Entidad;
using Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CdEmpleado
    {
        string cadenaConexion = "Server=localhost;User=root;Password=root;database=Empresa";

        public void pruebaConexion()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);

            try
            {
                mySqlConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectarse " + ex.Message);
                return;
            }
            mySqlConnection.Close();
            MessageBox.Show("Conectado!");
        }

        public void crear(CeEmpleado cE)
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
                mySqlConnection.Open();
                string Query = "INSERT INTO `empresa`.`empleado` (`Nombres`, `Apellidos`, `Salario`, `Tipo`, `Foto`, `Estatus`) VALUES ('" + cE.Nombre + "', '" + cE.Apellidos + "', '" + cE.Salario + "', '" + cE.Tipo + "', @Imagen, 'Activo');";
                MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
                mySqlCommand.Parameters.AddWithValue("@Imagen", cE.Imagen);
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();

                MessageBox.Show("Registro creado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
                MessageBox.Show("Hubo un error o repetiste el id");

            }

        }
        public void buscar(CeEmpleado cE)
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
                mySqlConnection.Open();
                string Query = "SELECT * FROM empleado WHERE Nombres LIKE '%" + cE.Busqueda +"%' OR Apellidos LIKE '%" + cE.Busqueda +"%' LIMIT 100;";
                MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();

                MessageBox.Show("Busqueda realizada");
                MessageBox.Show("" + cE.Busqueda);
                MessageBox.Show(Query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
                MessageBox.Show("Hubo un error o repetiste el id");

            }

        }

        public void editar(CeEmpleado cE)
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
                mySqlConnection.Open();
                string Query = "UPDATE `empresa`.`empleado` SET `Nombres`='" + cE.Nombre + "', `Apellidos`='" + cE.Apellidos + "', `Salario`='" + cE.Salario + "', `Tipo`='" + cE.Tipo + "', `Foto`=@Imagen, `Estatus`='" + cE.Estatus + "' WHERE  `idEmpleado`=" + cE.Id + ";";
                MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
                mySqlCommand.Parameters.AddWithValue("@Imagen", cE.Imagen);
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();

                MessageBox.Show("Registro actualizado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
                MessageBox.Show("Hubo un error o repetiste el id");

            }

        }

        public void eliminar(CeEmpleado cE)
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
                mySqlConnection.Open();
                string Query = "UPDATE `empresa`.`empleado` SET `Estatus`='Inactivo' WHERE  `idEmpleado`=" + cE.Id + ";";
                MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();

                MessageBox.Show("Registro Eliminado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Hubo un error o repetiste el id");

            }

        }

        public void eliminarDatos(CeEmpleado cE)
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
                mySqlConnection.Open();
                string Query = "UPDATE `empresa`.`empleado` SET `Estatus`='Inactivo';";
                MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();

                MessageBox.Show("Todos los datos han sido eliminados");
            }
            catch (Exception)
            {
                MessageBox.Show("Hubo un error");

            }

        }

        public DataSet Listar()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
            mySqlConnection.Open();
            string Querry = "SELECT * FROM empleado WHERE Estatus = 'Activo' LIMIT 1000;";
            MySqlDataAdapter adaptador;
            DataSet dataset = new DataSet();

            adaptador = new MySqlDataAdapter(Querry, mySqlConnection);
            adaptador.Fill(dataset, "tb1");


            return dataset;
        }
    }
}

