using MediatR;
using Meditor.Models;

namespace Meditor.Commands
{
    public class ValidateOrderCommand : IRequest<bool>
    {
        public Order Order { get; set; }

        public ValidateOrderCommand(Order order)
        {
            Order = order;
        }
    }

}
