using MediatR;
using Meditor.Commands;
using Meditor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Meditor.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: Show the order form
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // POST: Process the order form
        [HttpPost]
        public async Task<IActionResult> PlaceOrder(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Step 1: Create PlaceOrderCommand
                var placeOrderCommand = new PlaceOrderCommand
                {
                    CustomerName = model.CustomerName,
                    ProductIds = model.ProductIds,
                    //ProductIds = model.ProductIds.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList(),
                    TotalAmount = model.TotalAmount
                };

                // Step 2: Handle PlaceOrderCommand
                var order = await _mediator.Send(placeOrderCommand);

                // Proceed with other steps like validation, stock checking, payment, etc.
                var isValid = await _mediator.Send(new ValidateOrderCommand(order));
                if (!isValid)
                {
                    return View("OrderFailed", order);
                }

                var isAvailable = await _mediator.Send(new CheckProductAvailabilityCommand(order.ProductIds));
                if (!isAvailable)
                {
                    return View("OutOfStock", order);
                }

                var isPaymentProcessed = await _mediator.Send(new ProcessPaymentCommand(order));
                if (!isPaymentProcessed)
                {
                    return View("PaymentFailed", order);
                }

                await _mediator.Send(new SendEmailConfirmationCommand(order));

                return View("OrderSuccess", order);
            }

            // If model is invalid, return the form with validation errors
            return View("Index", model);
        }
    }

}
