﻿namespace Basket.API.Models
{
	public class ShoppingCartItem
	{
		public int Quantity { get; set; }
		public required string Color { get; set; }
		public decimal Price { get; set; }
		public required Guid ProductId { get; set; }
		public required string ProductName { get; set; }
	}
}
