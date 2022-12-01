namespace Modelos
{
    public class CeCliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Estatus { get; set; }
        public byte [] Imagen { get; set; }
        public string Direccion { get; set; }
        public string Busqueda { get; set; }
    }
}