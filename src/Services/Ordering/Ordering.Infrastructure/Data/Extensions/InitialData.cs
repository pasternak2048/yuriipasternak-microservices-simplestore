using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Extensions
{
	internal class InitialData
	{
		public static IEnumerable<Customer> Customers =>
		new List<Customer>
		{
		Customer.Create(CustomerId.Of(new Guid("58c49479-ec65-4de2-86e7-033c546291aa")), "yurii", "yurii@gmail.com"),
		Customer.Create(CustomerId.Of(new Guid("189dc8dc-990f-48e0-a37b-e6f2b60b9d7d")), "olga", "olga@gmail.com")
		};

		public static IEnumerable<Product> Products =>
			new List<Product>
			{
				Product.Create(ProductId.Of(new Guid("1d8de016-e4a7-4fb2-940e-fbc97ea9bdd1")), "Wireless Keyboard & Mouse Combo", 39.99m),
				Product.Create(ProductId.Of(new Guid("20f38790-6294-4ccb-a448-eed6b6ee06cc")), "Gaming PC - RTX 4080", 2499.99m),
				Product.Create(ProductId.Of(new Guid("7c22b2b3-5d72-431e-8a60-9b2e0409ef10")), "Wireless Gaming Mouse", 79.99m),
				Product.Create(ProductId.Of(new Guid("1d15e1ab-085a-48e7-9210-17a7882e1bd9")), "Mechanical Keyboard - RGB", 129.99m)
			};

		public static IEnumerable<Order> OrdersWithItems
		{
			get
			{
				var address1 = Address.Of("yurii", "pasternak", "yurii@gmail.com", "Teatralna No:1", "Ukraine", "Lviv", "79000");
				var address2 = Address.Of("olga", "aleksandrovych", "olga@gmail.com", "Teatralna No:1", "Ukraine", "Lviv", "79000");

				var payment1 = Payment.Of("yurii", "5555555555554444", "12/28", "355", 1);
				var payment2 = Payment.Of("olga", "8885555555554444", "06/30", "222", 2);

				var order1 = Order.Create(
								OrderId.Of(Guid.NewGuid()),
								CustomerId.Of(new Guid("58c49479-ec65-4de2-86e7-033c546291aa")),
								OrderName.Of("ORD_1"),
								shippingAddress: address1,
								billingAddress: address1,
								payment1);
				order1.Add(ProductId.Of(new Guid("1d8de016-e4a7-4fb2-940e-fbc97ea9bdd1")), 2, 39.99m);
				order1.Add(ProductId.Of(new Guid("20f38790-6294-4ccb-a448-eed6b6ee06cc")), 1, 2499.99m);

				var order2 = Order.Create(
								OrderId.Of(Guid.NewGuid()),
								CustomerId.Of(new Guid("189dc8dc-990f-48e0-a37b-e6f2b60b9d7d")),
								OrderName.Of("ORD_2"),
								shippingAddress: address2,
								billingAddress: address2,
								payment2);
				order2.Add(ProductId.Of(new Guid("7c22b2b3-5d72-431e-8a60-9b2e0409ef10")), 1, 79.99m);
				order2.Add(ProductId.Of(new Guid("1d15e1ab-085a-48e7-9210-17a7882e1bd9")), 2, 129.99m);

				return new List<Order> { order1, order2 };
			}
		}
	}
}
