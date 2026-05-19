using Marten.Schema;

namespace Catalog.API.Data
{
	public class CatalogInitialData : IInitialData
	{
		public async Task Populate(IDocumentStore store, CancellationToken cancellation)
		{
			using var session = store.LightweightSession();

			if (await session.Query<Product>().AnyAsync())
				return;

			session.Store<Product>(GetPreconfiguredProducts());
			await session.SaveChangesAsync();
		}
		private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>
		{
			new Product()
			{
				Id = new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61"),
				Name = "IPhone X",
				Description = "This phone is the company's biggest change",
				ImageFile = "product-1.png",
				Price = 950.00M,
				Category = new List<string> { "Smart Phone" }
			},

			new Product()
			{
				Id = new Guid("c1a11111-1111-1111-1111-111111111111"),
				Name = "Samsung Galaxy S21",
				Description = "Flagship Android smartphone with high-end features",
				ImageFile = "product-2.png",
				Price = 850.00M,
				Category = new List<string> { "Smart Phone" }
			},

			new Product()
			{
				Id = new Guid("c2b22222-2222-2222-2222-222222222222"),
				Name = "Google Pixel 6",
				Description = "Google smartphone with excellent camera quality",
				ImageFile = "product-3.png",
				Price = 799.99M,
				Category = new List<string> { "Smart Phone" }
			},

			new Product()
			{
				Id = new Guid("c3c33333-3333-3333-3333-333333333333"),
				Name = "MacBook Pro",
				Description = "Powerful laptop for developers and creators",
				ImageFile = "product-4.png",
				Price = 1999.00M,
				Category = new List<string> { "Laptop" }
			},

			new Product()
			{
				Id = new Guid("c4d44444-4444-4444-4444-444444444444"),
				Name = "Dell XPS 15",
				Description = "Premium Windows laptop with InfinityEdge display",
				ImageFile = "product-5.png",
				Price = 1750.50M,
				Category = new List<string> { "Laptop" }
			},

			new Product()
			{
				Id = new Guid("c5e55555-5555-5555-5555-555555555555"),
				Name = "Apple Watch Series 8",
				Description = "Smartwatch with health and fitness tracking",
				ImageFile = "product-6.png",
				Price = 499.99M,
				Category = new List<string> { "Smart Watch" }
			},

			new Product()
			{
				Id = new Guid("c6f66666-6666-6666-6666-666666666666"),
				Name = "Sony WH-1000XM5",
				Description = "Wireless noise-cancelling headphones",
				ImageFile = "product-7.png",
				Price = 399.99M,
				Category = new List<string> { "Headphones" }
			},

			new Product()
			{
				Id = new Guid("c7c77777-7777-7777-7777-777777777777"),
				Name = "iPad Air",
				Description = "Lightweight tablet with powerful performance",
				ImageFile = "product-8.png",
				Price = 699.00M,
				Category = new List<string> { "Tablet" }
			}
		};
	}
}
