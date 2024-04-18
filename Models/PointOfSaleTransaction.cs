namespace GolfWarehouse.Models
{
    public class PointOfSaleTransaction
    {
        public long DocId { get; set; }
        public string? ItemNo { get; set; }
        public decimal Price { get; internal set; }
        // Add more properties as needed
    }
}
