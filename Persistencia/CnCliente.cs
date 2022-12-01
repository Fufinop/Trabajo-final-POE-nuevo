using Controladores;
using Modelos;
using System;
using System.Data;
using System.Windows.Forms;

namespace Negocio
{
    public class CnCliente
    {
        CdCliente cdCliente = new CdCliente();
        public bool validarDatos(CeCliente cliente)
        {
            bool Resultado = true;

            if (cliente.Nombre == String.Empty)
            {
                Resultado = false;
                MessageBox.Show("El nombre es obligatorio");
            } if (cliente.Apellidos == String.Empty)
            {
                Resultado = false;
                MessageBox.Show("Los apellidos son obligatorios");
            } if (cliente.Cedula == String.Empty)
            {
                Resultado = false;
                MessageBox.Show("La cedula es obligatoria");
            } if (cliente.Telefono == String.Empty)
            {
                Resultado = false;
                MessageBox.Show("El telefono es obligatorio");
            } if (cliente.Email == String.Empty)
            {
                Resultado = false;
                MessageBox.Show("El Email es obligatorio");
            } if (cliente.Estatus == String.Empty)
            {
                Resultado = false;
                MessageBox.Show("El estatus es obligatorio");
            } if (cliente.Imagen == null)
            {
                Resultado = false;
                MessageBox.Show("La foto es obligatoria");
            } if (cliente.Direccion == String.Empty)
            {
                Resultado = false;
                MessageBox.Show("La direccion es obligatoria");
            } 


            return Resultado;
        }

        public void prueaMysql()
        {
            cdCliente.pruebaConexion();
        }

        public void crearCliente(CeCliente cE)
        {
            cdCliente.crear(cE);
        }

        public void editarCliente(CeCliente cE)
        {
            cdCliente.editar(cE);
        }

        public void eliminarCliente(CeCliente cE)
        {
            cdCliente.eliminar(cE);
        }
        public void eliminarDatos(CeCliente cE)
        {
            cdCliente.eliminarDatos(cE);
        }

        public DataSet obtenerDatos()
        {
            return cdCliente.Listar();
        }
        public DataSet buscarDatos(CeCliente cE)
        {
            return cdCliente.buscarDatos(cE);
        }
    }
}