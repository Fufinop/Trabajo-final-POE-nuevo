namespace Entidad
{
    public class CeInventario
    {
        public int ID { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Stock { get; set; }
        public byte[] Imagen { get; set; }
        public string Estatus { get; set; }
    }
}
