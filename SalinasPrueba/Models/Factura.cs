namespace SalinasPrueba.Models
{
    public class Factura
    {
        public int Id { get; set; }
        public string NumeroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public List<ProductoFactura> productos { get; set; }
    }
}
