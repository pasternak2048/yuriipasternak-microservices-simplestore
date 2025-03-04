﻿
namespace Basket.API.Features.Basket.DeleteBasket
{
	public record DeleteBasketCommand(string UserName) : ICommand<DeleteBasketResult>;

	public record DeleteBasketResult(bool IsSuccess);

	public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
	{
		public DeleteBasketCommandValidator()
		{
			RuleFor(command => command.UserName)
				.NotEmpty().WithMessage("UserName is required.");
		}
	}

	public class DeleteBasketCommandHandler : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
	{
		public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
		{
			//TODO: db implementation

			return new DeleteBasketResult(true);
		}
	}
}
