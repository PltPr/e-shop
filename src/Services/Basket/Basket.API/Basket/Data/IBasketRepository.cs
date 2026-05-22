namespace Basket.API.Basket.Data
{
	public interface IBasketRepository
	{
		Task<ShoppingCart> GetShoppingCartAsync(string UserName);
	}
}
