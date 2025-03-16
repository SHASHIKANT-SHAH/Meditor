using MediatR;
using Meditor.Commands;

namespace Meditor.CommandHandler
{
    public class ValidateOrderCommandHandler : IRequestHandler<ValidateOrderCommand, bool>
    {
        public Task<bool> Handle(ValidateOrderCommand request, CancellationToken cancellationToken)
        {
            // Simulate validation (e.g., check if all fields are filled)
            if (string.IsNullOrEmpty(request.Order.CustomerName) || request.Order.ProductIds.Count == 0)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }
    }

}
