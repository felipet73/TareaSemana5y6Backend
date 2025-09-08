namespace AngularApp.Server.Model
{
    public class ProductosModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
        public int Minimo { get; set; }
    }
}
