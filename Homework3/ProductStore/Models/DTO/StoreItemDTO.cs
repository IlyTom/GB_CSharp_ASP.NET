namespace ProductStore.Models.DTO
{
    public class StoreItemDTO
    {
        public Guid ItemId { get; set; }
        public Guid ProductId { get; set; }
        public Guid StoreId { get; set; }

        public decimal Quantity { get; set; }
    }
}
