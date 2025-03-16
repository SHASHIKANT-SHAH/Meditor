using MediatR;
using Meditor.Commands;

namespace Meditor.CommandHandler
{
    public class CheckProductAvailabilityCommandHandler : IRequestHandler<CheckProductAvailabilityCommand, bool>
    {
        public Task<bool> Handle(CheckProductAvailabilityCommand request, CancellationToken cancellationToken)
        {
            // Simulate stock check (e.g., check product availability)
            bool isAvailable = request.ProductIds.All(id => id != "OutOfStock"); // Assume "OutOfStock" products are unavailable
            return Task.FromResult(isAvailable);
        }
    }

}
