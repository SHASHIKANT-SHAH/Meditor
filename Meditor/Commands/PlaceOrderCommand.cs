using MediatR;
using Meditor.Models;

namespace Meditor.Commands
{
    public class PlaceOrderCommand : IRequest<Order>
    {
        public string CustomerName { get; set; }
        public List<string> ProductIds { get; set; }
        public decimal TotalAmount { get; set; }
    }

}
