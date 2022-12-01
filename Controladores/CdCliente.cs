using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Modelos;
using System.Data;
using Microsoft.VisualBasic;
using MySqlX.XDevAPI;

namespace Controladores
{
    public class CdCliente
    {
        string cadenaConexion = "Server=localhost;User=root;Password=root;database=empresa";

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

        public void crear(CeCliente cE)
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
                mySqlConnection.Open();
                string Query = "INSERT INTO `empresa`.`cliente` (`Nombre`, `Apellido`, `Direccion`, `Cedula`, `Telefono`, `E-mail`, `Foto`, `Estatus`) VALUES ('" + cE.Nombre + "', '" + cE.Apellidos + "', '" + cE.Direccion + "', '" + cE.Cedula + "', '" + cE.Telefono + "', '" + cE.Email + "', @Imagen, 'Activo');";
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

        public void editar(CeCliente cE)
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
                mySqlConnection.Open();
                string Query = "UPDATE `empresa`.`cliente` SET `idCliente`='" + cE.Id + "', `Nombre`='" + cE.Nombre + "', `Apellido`='" + cE.Apellidos + "', `direccion`='" + cE.Direccion + "', `cedula`='" + cE.Cedula + "', `telefono`='" + cE.Telefono + "', `E-mail`='" + cE.Email + "', `estatus`='" + cE.Estatus + "', `foto`=@Imagen WHERE  `idCliente`=" + cE.Id + ";";
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

        public void eliminar(CeCliente cE)
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
                mySqlConnection.Open();
                string Query = "UPDATE `empresa`.`cliente` SET `Estatus`='Inactivo' WHERE  `idCliente`=" + cE.Id + ";";
                MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();

                MessageBox.Show("Registro Eliminado");
            }
            catch (Exception ex )
            {
                MessageBox.Show("" + ex);
                MessageBox.Show("Hubo un error o repetiste el id");

            }

        }

        public void eliminarDatos(CeCliente cE)
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
                mySqlConnection.Open();
                string Query = "DEUPDATE `empresa`.`cliente` SET `Estatus`='Inactivo';";
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
            string Querry = "SELECT * FROM cliente WHERE Estatus = 'Activo' LIMIT 1000;";
            MySqlDataAdapter adaptador;
            DataSet dataset = new DataSet();

            adaptador = new MySqlDataAdapter(Querry, mySqlConnection);
            adaptador.Fill(dataset, "tb1");


            return dataset;
        }

        public DataSet buscarDatos(CeCliente cE)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
            mySqlConnection.Open();
            string Querry = "SELECT * FROM cliente WHERE nombre LIKE '%" + cE.Busqueda + "%' OR apellido LIKE '%" + cE.Busqueda + "%';";
            MySqlDataAdapter adaptador;
            DataSet dataset = new DataSet();

            adaptador = new MySqlDataAdapter(Querry, mySqlConnection);
            adaptador.Fill(dataset, "tb1");


            return dataset;
        }
    }
}