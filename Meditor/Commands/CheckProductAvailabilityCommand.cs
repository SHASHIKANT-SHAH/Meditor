using MediatR;

namespace Meditor.Commands
{
    public class CheckProductAvailabilityCommand : IRequest<bool>
    {
        public List<string> ProductIds { get; set; }

        public CheckProductAvailabilityCommand(List<string> productIds)
        {
            ProductIds = productIds;
        }
    }

}
