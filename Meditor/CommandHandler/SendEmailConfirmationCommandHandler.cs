using MediatR;
using Meditor.Commands;

namespace Meditor.CommandHandler
{
    public class SendEmailConfirmationCommandHandler : IRequestHandler<SendEmailConfirmationCommand,Unit>
    {
        public Task<Unit> Handle(SendEmailConfirmationCommand request, CancellationToken cancellationToken)
        {
            // Simulate sending email (just output to console for simplicity)
            Console.WriteLine($"Sending email confirmation to {request.Order.CustomerName} for Order ID {request.Order.Id}");
            return Task.FromResult(Unit.Value);
        }
    }

}
