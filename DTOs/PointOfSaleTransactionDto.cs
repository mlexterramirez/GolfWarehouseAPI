namespace GolfWarehouseAPI.DTOs
{
    public class PointOfSaleTransactionDto
    {
        public long DocId { get; set; }
        public string? ItemNo { get; set; } // Nullable string
        public decimal Price { get; set; }
        // Add more properties as needed
    }
}
