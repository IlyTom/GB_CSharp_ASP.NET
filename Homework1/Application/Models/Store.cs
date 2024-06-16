namespace Application.Models
{
    public partial class Store : BaseModel
    {
       
        public virtual Product? Product { get; set; }       
        public int Quantity { get; set; }

       
        
    }
}
