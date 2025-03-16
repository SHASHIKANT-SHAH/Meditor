namespace Meditor.Models
{
    public class OrderViewModel
    {
        public string CustomerName { get; set; }
        public List<string> ProductIds { get; set; }
        public decimal TotalAmount { get; set; }
    }

}
