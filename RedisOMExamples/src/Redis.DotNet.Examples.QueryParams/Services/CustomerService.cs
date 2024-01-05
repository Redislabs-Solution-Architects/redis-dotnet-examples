using Redis.DotNet.Examples.QueryParams.Models.Requests;
using Redis.DotNet.Examples.QueryParams.Models.Domain;
using Redis.OM.Contracts;
using Redis.OM.Searching;
using LinqKit;

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
            //var filteredPublications = _customerCollection.Where(x => x.Publications.Contains("Conclusions Drawn from the Phenomena of Capillarity")).ToList();
            var predicate = PredicateBuilder.New<Customer>(true); // Start with true to have an "AND" neutral element

            var query = _connectionProvider.RedisCollection<Customer>().AsQueryable();

            if (!string.IsNullOrEmpty(parameters.FullName))
            {
                predicate = predicate.And(c => c.FullName.Contains(parameters.FullName));
            }

            if (!string.IsNullOrEmpty(parameters.Email))
            {
                predicate = predicate.And(c => c.Email == parameters.Email);
            }


            query = query.Where(predicate);
            var result = query.ToList();

            //var query = _connectionProvider.RedisCollection<Customer>()
            //    .Where(x => x.FullName.Contains(parameters.FullName));

            //if (!string.IsNullOrEmpty(parameters.Email))
            //    query = _connectionProvider.RedisCollection<Customer>()
            //        .Where(x => x.FullName.Contains(parameters.FullName) || x.Email == parameters.Email);

            //if(!string.IsNullOrEmpty(parameters.Address.AddressLine1))
            //{
            //    query = _connectionProvider.RedisCollection<Customer>()
            //        .Where(x => x.FullName.Contains(parameters.FullName) || x.Address.AddressLine1 == parameters.Address.AddressLine1);
            //}

            return query;
        }
    }
}

