using Redis.DotNet.Examples.QueryParams.Models.Domain;
using Redis.OM;
using Redis.OM.Searching;

namespace Redis.DotNet.Examples.QueryParams.Helpers
{
	public class RedisHelper
	{
		public static async Task SeedCustomers(IRedisCollection<Customer> collection)
		{
			await collection.InsertAsync(new Customer()
			{
				Id = Guid.NewGuid(),
				Email = "Albert.Einstein@hotmail.com",
				FullName = "Albert Einstein",
				Publications = new[] { "Conclusions Drawn from the Phenomena of Capillarity", "Foundations of the General Theory of Relativity", "Investigations of Brownian Motion" },
				Address = new Address("4891 Island Hwy", "Campbell River"),
				Age = 75
			});
			await collection.InsertAsync(new Customer()
			{
				Id = Guid.NewGuid(),
				Email = "INewton@hotmail.com",
				FullName = "Isaac Newton",
				Publications = new[] { "Philosophiæ Naturalis Principia Mathematica", "Opticks", "De mundi systemate" },
				Address = new Address("2019 90th Avenue", "Delia"),
				Age = 25
			});
			await collection.InsertAsync(new Customer()
			{
				Id = Guid.NewGuid(),
				Email = "Galileo.Galilei@gmail.com",
				FullName = "Galileo Galilei",
				Publications = new[] { "Sidereus Nuncius", "The Assayer" },
				Age = 60
			});
			await collection.InsertAsync(new Customer()
			{
				Id = Guid.NewGuid(),
				Email = "MarieCurie@princeton.edu",
				FullName = "Marie Curie",
				Publications = new[] { "Recherches sur les substances radioactives", "Traité de Radioactivité", "L'isotopie et les éléments isotopes" },
				Address = new Address("1704 rue Ontario Ouest", "Montréal"),
				Age = 20
			});
		}
	}
}

