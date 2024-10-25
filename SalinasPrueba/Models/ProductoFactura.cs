namespace SalinasPrueba.Models
{
    public class ProductoFactura
    {
        public int ProductoId { get; set; }
        public  Producto Producto { get; set; }
        public int FacturaId { get; set; }
        public Factura Factura { get; set; }
        public int Cantidad { get; set; }
    }
}
