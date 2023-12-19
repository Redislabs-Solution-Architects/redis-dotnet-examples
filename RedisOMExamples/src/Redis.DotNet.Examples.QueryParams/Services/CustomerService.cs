using Redis.DotNet.Examples.QueryParams.Models.Requests;
using Redis.DotNet.Examples.QueryParams.Models.Domain;
using Redis.OM.Contracts;
using System.Reflection;
using Redis.OM.Searching;

namespace Redis.DotNet.Examples.QueryParams.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRedisConnectionProvider _connectionProvider;
        private readonly IRedisCollection<Customer> _customerCollection;
        public CustomerService(IRedisConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider ?? throw new ArgumentNullException();
            _customerCollection = _connectionProvider.RedisCollection<Customer>();
        }

        public IQueryable<Customer> Search(GetCustomerQuery parameters)
        {
            // **** Basic **** //

            // match by string
            // Find all customers with FirstName is {parameters.FullName}
            //var customerWithFirstNameCustomer = _customerCollection.Where(x => x.FullName == parameters.FullName).ToList();

            // match by numeric
            // Find all customers with Age is 20
            //var customerWithAge20 = _customerCollection.Where(x => x.Age == 20).ToList();

            // Find all customers with Age is more than 20
            // var customerWithAgeMoreThan20 = _customerCollection.Where(x => x.Age > 20).ToList();

            // multiple matches

            // Find all customers with FirstName is {parameters.FullName} and Age is 20
            //var customerWithFirstNameCustomerAndAge20 = _customerCollection.Where(x => x.FullName == parameters.FullName && x.Age == 20).ToList();

            // match by string within embedded documents
            // Find all customers with City is {parameters.Address.City}
            //var customerInCity = _customerCollection.Where(x => x.Address.City == parameters.Address.City).ToList();

            // match by Publications
            var filteredPublications = _customerCollection.Where(x => x.Publications.Contains("Conclusions Drawn from the Phenomena of Capillarity")).ToList();

            // Find customer that contains {parameters.FullName}
            return _connectionProvider.RedisCollection<Customer>()
                    .Where(x => x.FullName.Contains(parameters.FullName));
        }
    }
}

