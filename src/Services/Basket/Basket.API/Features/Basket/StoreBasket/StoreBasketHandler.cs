﻿namespace Basket.API.Features.Basket.StoreBasket
{
	public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;

	public record StoreBasketResult(string UserName);

	public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
	{
		public StoreBasketCommandValidator()
		{
			RuleFor(command => command.Cart)
				.NotNull().WithMessage("Cart can not be null.");

			RuleFor(command => command.Cart.UserName)
				.NotEmpty().WithMessage("UserName is required.");
		}
	}

	public class StoreBasketCommandHandler : ICommandHandler<StoreBasketCommand, StoreBasketResult>
	{
		public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
		{
			//TODO: db implement

			ShoppingCart cart = command.Cart;

			return new StoreBasketResult("Yurii"); 
		}
	}
}
