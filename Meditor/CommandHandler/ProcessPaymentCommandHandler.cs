using MediatR;
using Meditor.Commands;

namespace Meditor.CommandHandler
{
    public class ProcessPaymentCommandHandler : IRequestHandler<ProcessPaymentCommand, bool>
    {
        public Task<bool> Handle(ProcessPaymentCommand request, CancellationToken cancellationToken)
        {
            // Simulate payment processing (e.g., check payment)
            if (request.Order.TotalAmount <= 0)
            {
                return Task.FromResult(false); // Invalid amount
            }

            // Assume payment is successful for simplicity
            request.Order.Status = "Paid";
            return Task.FromResult(true);
        }
    }

}
