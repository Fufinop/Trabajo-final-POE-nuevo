using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class CeProveedor
    {
        public int ID { get; set; }
        public string CodigoProveedor { get; set; }
        public string CodigoCiudad { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string EMail { get; set; }
        public string Producto { get; set; }
        public string Estatus { get; set; }
        public byte[] Foto { get; set; }
        public string Busqueda { get; set; }
    }
}
