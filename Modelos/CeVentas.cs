using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class CeVentas
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string PrecioVenta { get; set;}
        public string Producto { get; set; }
        public string Estatus { get; set; }
    }
}
