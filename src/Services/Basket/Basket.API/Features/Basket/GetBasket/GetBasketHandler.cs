﻿namespace Basket.API.Features.Basket.GetBasket
{
	public record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;

	public record GetBasketResult(ShoppingCart Cart);

	public class GetBasketQueryHandler : IQueryHandler<GetBasketQuery, GetBasketResult>
	{
		public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
		{
			//TODO: get from db
			return new GetBasketResult(new ShoppingCart { UserName = "new"});
		}
	}
}
