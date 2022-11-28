using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CnLogin
    {
        CdLogin cdLogin = new CdLogin();
        public bool validarDatos(CeLogin Login)
        {
            bool Resultado = true;

            if (Login.LoginName == String.Empty)
            {
                Resultado = false;
                MessageBox.Show("El nombre se usuario no puede estar vacio");
            }
            if (Login.Password == String.Empty)
            {
                Resultado = false;
                MessageBox.Show("La contraseña no puede estar vacia");
            }

            return Resultado;
        }

        public void ConectarUsuario(CeLogin cE)
        {
            cdLogin.ComprobarUsuario(cE);

            

        }
    }
}
