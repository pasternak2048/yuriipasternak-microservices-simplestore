﻿namespace Basket.API.Data.Repositories
{
	public interface IBasketRepository
	{
		Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default);

		Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default);

		Task<bool> DeeteBasket(string userName, CancellationToken cancellationToken = default);
	}
}
