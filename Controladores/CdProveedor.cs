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
    public class CdProveedor
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

        public void crear(CeProveedor cE)
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
                mySqlConnection.Open();
                string Query = "INSERT INTO `empresa`.`proveedor` (`CodigoProvedor`, `CodigoCiudad`, `Nombre`, `Direccion`, `Telefono`, `E-mail`, `Producto`, `Foto`, `Estatus`) VALUES ('" + cE.CodigoProveedor + "', '" + cE.CodigoCiudad + "', '" + cE.Nombre + "', '" + cE.Direccion + "', '" + cE.Telefono + "', '" + cE.EMail + "', '" + cE.Producto + "', @Imagen, 'Activo');";
                MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
                mySqlCommand.Parameters.AddWithValue("@Imagen", cE.Foto);
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();

                MessageBox.Show("Registro creado");
            }
            catch (Exception)
            { 
                MessageBox.Show("Hubo un error o repetiste el id");

            }

        }

        public void editar(CeProveedor cE)
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
                mySqlConnection.Open();
                string Query = "UPDATE `empresa`.`proveedor` SET `CodigoProvedor`='" + cE.CodigoProveedor + "', `CodigoCiudad`='" + cE.CodigoCiudad + "', `Nombre`='" + cE.Nombre + "', `Direccion`='" + cE.Direccion + "', `Telefono`='" + cE.Telefono + "', `E-mail`='" + cE.EMail + "', `Producto`='" + cE.Producto + "', `Foto`=@Imagen, `Estatus`='" + cE.Estatus + "' WHERE  `idProveedor`=" + cE.ID + ";";
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

        public void eliminar(CeProveedor cE)
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
                mySqlConnection.Open();
                string Query = "UPDATE `empresa`.`proveedor` SET `Estatus`='Inactivo' WHERE  `idProveedor`=" + cE.ID + ";";
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

        public void eliminarDatos(CeProveedor cE)
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
                mySqlConnection.Open();
                string Query = "UPDATE `empresa`.`proveedor` SET `Estatus`='Inactivo';";
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
            string Querry = "SELECT * FROM proveedor WHERE Estatus = 'Activo' LIMIT 1000;";
            MySqlDataAdapter adaptador;
            DataSet dataset = new DataSet();

            adaptador = new MySqlDataAdapter(Querry, mySqlConnection);
            adaptador.Fill(dataset, "tb1");


            return dataset;
        }
    }
}
