namespace Meditor.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public List<string> ProductIds { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
    }

}
