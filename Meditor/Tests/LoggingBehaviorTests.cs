using Moq;
using Xunit;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Meditor.Behavior;
using Meditor.Commands;
using Meditor.Models;

namespace Meditor.Tests
{
    public class LoggingBehaviorTests
    {
        [Fact]
        public async Task Should_Log_Error_When_Exception_Is_Thrown()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<LoggingBehavior<PlaceOrderCommand, Order>>>();
            var behavior = new LoggingBehavior<PlaceOrderCommand, Order>(loggerMock.Object);

            var request = new PlaceOrderCommand { /* set up request data */ };
            var next = new RequestHandlerDelegate<Order>(() => throw new InvalidOperationException("Test error"));

            // Act
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => behavior.Handle(request, default, next));

            // Assert
            loggerMock.Verify(
                log => log.LogError(It.IsAny<Exception>(), "An error occurred while handling PlaceOrderCommand"),
                Times.Once); // Verifies that LogError was called once
        }
    }

}
