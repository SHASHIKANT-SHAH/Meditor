using MediatR;
using Meditor.Models;

namespace Meditor.Commands
{
    public class SendEmailConfirmationCommand : IRequest<Unit>
    {
        public Order Order { get; set; }

        public SendEmailConfirmationCommand(Order order)
        {
            Order = order;
        }
    }

}
