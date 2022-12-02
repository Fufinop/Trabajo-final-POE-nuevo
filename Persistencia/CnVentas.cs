using Controladores;
using Datos;
using Entidad;
using Modelos;
using System.Data;

namespace Negocio
{
    public class CnVentas
    {
        CdVentas cdVentas = new CdVentas();
        public bool validarDatos(CeVentas venta)
        {
            bool Resultado = true;

            if (venta.Cliente == String.Empty)
            {
                Resultado = false;
                MessageBox.Show("El nombre del cliente no puede estar vacio");
            }
            if (venta.PrecioVenta == String.Empty)
            {
                Resultado = false;
                MessageBox.Show("El precio de venta no puede estar vacio");
            }
            if (venta.Producto == String.Empty)
            {
                Resultado = false;
                MessageBox.Show("El espacio del producto no puede estar vacio");
            }

            return Resultado;
        }

        public void prueaMysql()
        {
            cdVentas.pruebaConexion();
        }

        public void crearEmpleado(CeVentas cE)
        {
            cdVentas.crear(cE);
        }

        public void editarEmpleado(CeVentas cE)
        {
            cdVentas.editar(cE);
        }

        public void eliminarEmpleado(CeVentas cE)
        {
            cdVentas.eliminar(cE);
        }
        public void eliminarDatos(CeVentas cE)
        {
            cdVentas.eliminarDatos(cE);
        }

        public DataSet obtenerDatos()
        {
            return cdVentas.Listar();
        }

        public DataSet buscarDatos(CeVentas cE)
        {
            return cdVentas.buscarDatos(cE);
        }
    }
}
