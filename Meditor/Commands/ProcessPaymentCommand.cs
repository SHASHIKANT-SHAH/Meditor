using MediatR;
using Meditor.Models;

namespace Meditor.Commands
{
    public class ProcessPaymentCommand : IRequest<bool>
    {
        public Order Order { get; set; }

        public ProcessPaymentCommand(Order order)
        {
            Order = order;
        }
    }

}
