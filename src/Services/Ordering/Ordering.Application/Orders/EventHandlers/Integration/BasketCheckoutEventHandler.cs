using BuildingBlocks.Messaging.Events;
using MassTransit;
using Ordering.Application.Orders.Commands.CreateOrder;

namespace Ordering.Application.Orders.EventHandlers.Integration
{
	public class BasketCheckoutEventHandler
	(ISender sender, ILogger<BasketCheckoutEventHandler> logger)
	: IConsumer<BasketCheckoutEvent>
	{
		public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
		{
			logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

			var command = MapToCreateOrderCommand(context.Message);
			await sender.Send(command);
		}

		private CreateOrderCommand MapToCreateOrderCommand(BasketCheckoutEvent message)
		{
			var addressDto = new AddressDto(message.FirstName, message.LastName, message.EmailAddress, message.AddressLine, message.Country, message.State, message.ZipCode);
			var paymentDto = new PaymentDto(message.CardName, message.CardNumber, message.Expiration, message.CVV, message.PaymentMethod);
			var orderId = Guid.NewGuid();

			var orderDto = new OrderDto(
				Id: orderId,
				CustomerId: message.CustomerId,
				OrderName: message.UserName,
				ShippingAddress: addressDto,
				BillingAddress: addressDto,
				Payment: paymentDto,
				Status: Ordering.Domain.Enums.OrderStatus.Pending,
				OrderItems:
				[
					new OrderItemDto(orderId, new Guid("1d8de016-e4a7-4fb2-940e-fbc97ea9bdd1"), 2, 39.99m),
					new OrderItemDto(orderId, new Guid("20f38790-6294-4ccb-a448-eed6b6ee06cc"), 1, 2499.99m)
				]);

			return new CreateOrderCommand(orderDto);
		}
	}
}
