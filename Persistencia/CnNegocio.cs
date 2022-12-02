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
    public class CnNegocio
    {
        CdNegocio cdNegocio = new CdNegocio();
        public bool validarDatos(CeNegocio Negocio)
        {
            bool Resultado = true;

            
            if (Negocio.Ciudad == String.Empty)
            {
                Resultado = false;
                MessageBox.Show("La ciudad es obligatoria");
            }
            if (Negocio.Direccion == String.Empty)
            {
                Resultado = false;
                MessageBox.Show("La direccion es obligatoria");
            }
            if (Negocio.Sucursal == String.Empty)
            {
                Resultado = false;
                MessageBox.Show("La sucursal es obligatoria");
            }



            return Resultado;
        }

        public void prueaMysql()
        {
            cdNegocio.pruebaConexion();
        }

        public void crearNegocio(CeNegocio cE)
        {
            cdNegocio.crear(cE);
        }

        public void editarNegocio(CeNegocio cE)
        {
            cdNegocio.editar(cE);
        }

        public void eliminarNegocio(CeNegocio cE)
        {
            cdNegocio.eliminar(cE);
        }
        public void eliminarDatos(CeNegocio cE)
        {
            cdNegocio.eliminarDatos(cE);
        }
        public DataSet obtenerDatos()
        {
            return cdNegocio.Listar();
        }
        public DataSet buscarDatos(CeNegocio cE)
        {
            return cdNegocio.buscarDatos(cE);
        }
    }
}
