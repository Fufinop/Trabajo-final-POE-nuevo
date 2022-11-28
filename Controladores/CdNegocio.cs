using Entidad;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CdNegocio
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

        public void crear(CeNegocio cE)
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
                mySqlConnection.Open();
                string Query = "INSERT INTO `empresa`.`negocio` (`Ciudad`, `Direccion`, `Sucursal`, `Estatus`) VALUES ('" + cE.Ciudad + "', '" + cE.Direccion + "', '" + cE.Sucursal + "', '" + cE.Estatus + "');";
                MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();

                MessageBox.Show("Registro creado");
            }
            catch (Exception)
            {
                MessageBox.Show("Hubo un error o repetiste el id");

            }

        }

        public void editar(CeNegocio cE)
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
                mySqlConnection.Open();
                string Query = "UPDATE `empresa`.`negocio` SET `Ciudad`='" + cE.Ciudad + "', `Direccion`='" + cE.Direccion + "', `Sucursal`='" + cE.Sucursal + "', `Estatus`='" + cE.Estatus + "' WHERE  `idNegocio`=" + cE.Id + ";";
                MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();

                MessageBox.Show("Registro actualizado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Hubo un error o repetiste el id");

            }

        }

        public void eliminar(CeNegocio cE)
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
                mySqlConnection.Open();
                string Query = "UUPDATE `empresa`.`negocio` SET `Estatus`='Inactivo' WHERE  `idNegocio`=" + cE.Id + ";";
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

        public void eliminarDatos(CeNegocio cE)
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
                mySqlConnection.Open();
                string Query = "UPDATE `empresa`.`negocio` SET `Estatus`='Inactivo';";
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

        public void buscarDatos(CeNegocio cE)
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
                mySqlConnection.Open();
                string Query = "select * from negocio where ciudad like '" + cE.Busqueda + "'";
                MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();

                //MessageBox.Show("Todos los datos han sido eliminados");
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
                MessageBox.Show("Hubo un error");

            }

        }

        public DataSet Listar()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
            mySqlConnection.Open();
            string Querry = "SELECT * FROM negocio WHERE Estatus = 'Activo' LIMIT 1000;";
            MySqlDataAdapter adaptador;
            DataSet dataset = new DataSet();

            adaptador = new MySqlDataAdapter(Querry, mySqlConnection);
            adaptador.Fill(dataset, "tb1");


            return dataset;
        }
    }
}
