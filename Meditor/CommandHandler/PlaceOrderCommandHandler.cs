using MediatR;
using Meditor.Commands;
using Meditor.Models;

namespace Meditor.CommandHandler
{
    public class PlaceOrderCommandHandler : IRequestHandler<PlaceOrderCommand, Order>
    {
        public Task<Order> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
        {
            // Simulate creating an order
            var order = new Order
            {
                Id = Guid.NewGuid(),
                CustomerName = request.CustomerName,
                ProductIds = request.ProductIds,
                TotalAmount = request.TotalAmount,
                Status = "Pending"
            };
            return Task.FromResult(order);

            //throw new InvalidOperationException("Simulated error during order creation.");
        }
    }

}
