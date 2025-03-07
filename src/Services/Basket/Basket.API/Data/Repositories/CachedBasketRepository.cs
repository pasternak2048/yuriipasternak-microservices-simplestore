using System.Text.Json;

namespace Basket.API.Data.Repositories
{
	public class CachedBasketRepository(IBasketRepository repository, IDistributedCache cache) : IBasketRepository
	{
		public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default)
		{
			var cachedBasket = await cache.GetStringAsync(userName, cancellationToken);

			if (!string.IsNullOrEmpty(cachedBasket))
			{
				return JsonSerializer.Deserialize<ShoppingCart>(cachedBasket)!;
			}

			var basket = await repository.GetBasket(userName, cancellationToken);

			await cache.SetStringAsync(userName, JsonSerializer.Serialize(basket), cancellationToken);

			return basket;
		}

		public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
		{
			await repository.StoreBasket(basket, cancellationToken);

			await cache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket), cancellationToken);

			return basket;
		}

		public async Task<bool> DeeteBasket(string userName, CancellationToken cancellationToken = default)
		{
			await repository.DeeteBasket(userName, cancellationToken);

			await cache.RemoveAsync(userName, cancellationToken);

			return true;
		}
	}
}
