using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
