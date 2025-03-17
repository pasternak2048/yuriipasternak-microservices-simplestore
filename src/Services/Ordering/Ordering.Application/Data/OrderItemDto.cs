namespace Ordering.Application.Data
{
	public record OrderItemDto(Guid OrderId, Guid ProductId, int Quantity, decimal Price);
}
