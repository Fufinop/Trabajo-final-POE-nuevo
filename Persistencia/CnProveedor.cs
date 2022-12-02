using Datos;
using Entidad;
using System.Data;

namespace Negocio
{
    public class CnProveedor
    {
        CdProveedor cdProveedor = new CdProveedor();
        public bool validarDatos(CeProveedor proveedor)
        {
            bool Resultado = true;

            if (proveedor.CodigoProveedor == String.Empty)
            {
                Resultado = false;
                MessageBox.Show("El codigo de proveedor es obligatorio");
            }
            if (proveedor.CodigoCiudad == String.Empty)
            {
                Resultado = false;
                MessageBox.Show("La ciudad es obligatoria");
            }
            if (proveedor.Nombre == String.Empty)
            {
                Resultado = false;
                MessageBox.Show("El nombre es obligatorio");
            }
            if (proveedor.Direccion == String.Empty)
            {
                Resultado = false;
                MessageBox.Show("La direccion es obigatoria");
            }
            if (proveedor.Telefono == String.Empty)
            {
                Resultado = false;
                MessageBox.Show("El telefono es obligatorio");
            }
            if (proveedor.EMail == String.Empty)
            {
                Resultado = false;
                MessageBox.Show("El Email es obligatorio");
            }
            if (proveedor.Producto == String.Empty)
            {
                Resultado = false;
                MessageBox.Show("El producto es obligatorio");
            }
            if (proveedor.Foto == null)
            {
                Resultado = false;
                MessageBox.Show("La foto es obligatoria");
            }

            return Resultado;
        }

        public void prueaMysql()
        {
            cdProveedor.pruebaConexion();
        }

        public void crearEmpleado(CeProveedor cE)
        {
            cdProveedor.crear(cE);
        }

        public void editarEmpleado(CeProveedor cE)
        {
            cdProveedor.editar(cE);
        }

        public void eliminarEmpleado(CeProveedor cE)
        {
            cdProveedor.eliminar(cE);
        }
        public void eliminarDatos(CeProveedor cE)
        {
            cdProveedor.eliminarDatos(cE);
        }

        public DataSet obtenerDatos()
        {
            return cdProveedor.Listar();
        }

        public DataSet buscarDatos(CeProveedor cE)
        {
            return cdProveedor.buscarDatos(cE);
        }
    }
}
