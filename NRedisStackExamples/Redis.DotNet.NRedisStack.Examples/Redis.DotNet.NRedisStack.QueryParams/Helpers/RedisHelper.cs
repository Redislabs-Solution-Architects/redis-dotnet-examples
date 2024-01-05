using NRedisStack;
using NRedisStack.RedisStackCommands;
using Redis.DotNet.NRedisStack.QueryParams.Models.Domain;
using StackExchange.Redis;
using System.Text.Json;

namespace Redis.DotNet.NRedisStack.QueryParams.Helpers
{
    public class RedisHelper
	{
        public static async Task DeleteAllKeys(IConnectionMultiplexer redisConnection, IDatabase db)
        {            
            foreach (var endPoint in redisConnection.GetEndPoints())
            {
                var server = redisConnection.GetServer(endPoint);
                var keys = server.Keys();

                if (keys.Count() != 0)
                {
                    var keyArr = keys.ToArray();

                    try
                    {
                        var query = keyArr.GroupBy(x => x.GetHashCode());

                        foreach (IGrouping<int, RedisKey> keyGroup in query)
                        {
                            foreach (var key in keyGroup)
                            {
                                await db.KeyDeleteAsync(key);
                            }
                        }

                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }
        public static async Task SeedCustomers(IDatabase db)
        {
            ICollection<Customer> customers = new List<Customer>
            {
                new Customer()
                {
                    Id = Guid.NewGuid(),
                    Email = "Albert.Einstein\\@hotmail.com",
                    FullName = "Albert Einstein",
                    Publications = new[] { "Conclusions Drawn from the Phenomena of Capillarity", "Foundations of the General Theory of Relativity", "Investigations of Brownian Motion" },
                    Address = new Address("4891 Island Hwy", "Campbell River")
                },
                new Customer()
                {
                    Id = Guid.NewGuid(),
                    Email = "INewton\\@hotmail.com",
                    FullName = "Isaac Newton",
                    Publications = new[] { "Philosophiæ Naturalis Principia Mathematica", "Opticks", "De mundi systemate" },
                    Address = new Address("2019 90th Avenue", "Delia")
                },
                new Customer()
                {
                    Id = Guid.NewGuid(),
                    Email = "Galileo.Galilei\\@gmail.com",
                    FullName = "Galileo Galilei",
                    Publications = new[] { "Sidereus Nuncius", "The Assayer" }
                },
                new Customer()
                {
                    Id = Guid.NewGuid(),
                    Email = "MarieCurie\\@princeton.edu",
                    FullName = "Marie Curie",
                    Publications = new[] { "Recherches sur les substances radioactives", "Traité de Radioactivité", "L'isotopie et les éléments isotopes" },
                    Address = new Address("1704 rue Ontario Ouest", "Montréal")
                }
            };

            foreach (var customer in customers)
            {
                var key = $"customer:{customer.Id}";
                var value = JsonSerializer.Serialize(customer);
                await db.JSON().SetAsync(key, "$", value);
            }
        }
    }
}

