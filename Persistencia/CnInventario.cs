using Controladores;
using Datos;
using Entidad;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CnInventario
    {
        CdInventario cdInventario = new CdInventario();
        public bool validarDatos(CeInventario inventario)
        {
            bool Resultado = true;

            if (inventario.Codigo == String.Empty)
            {
                Resultado = false;
                MessageBox.Show("El codigo no puede estar vacio");
            }
            if (inventario.Nombre == String.Empty)
            {
                Resultado = false;
                MessageBox.Show("El apellido es obligatorio");
            }
            if (inventario.Descripcion == String.Empty)
            {
                Resultado = false;
                MessageBox.Show("La descripcion es obligatoria");
            }
            if (inventario.Stock == String.Empty)
            {
                Resultado = false;
                MessageBox.Show("El stock es obligatorio");
            }
            if (inventario.Imagen == null)
            {
                Resultado = false;
                MessageBox.Show("La imagen es obligatoria");
            }


            return Resultado;
        }

        public void prueaMysql()
        {
            cdInventario.pruebaConexion();
        }

        public void crearEmpleado(CeInventario cE)
        {
            cdInventario.crear(cE);
        }

        public void editarEmpleado(CeInventario cE)
        {
            cdInventario.editar(cE);
        }

        public void eliminarEmpleado(CeInventario cE)
        {
            cdInventario.eliminar(cE);
        }
        public void eliminarDatos(CeInventario cE)
        {
            cdInventario.eliminarDatos(cE);
        }

        public DataSet obtenerDatos()
        {
            return cdInventario.Listar();
        }

        public DataSet buscarDatos(CeInventario cE)
        {
            return cdInventario.buscarDatos(cE);
        }
    }
}
