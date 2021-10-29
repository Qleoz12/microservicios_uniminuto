using CustomersMicroservice.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CustomersMicroservice.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IMongoCollection<Customer> _col;
        public CustomerRepository(IMongoDatabase db)
        {
            _col = db.GetCollection<Customer>(Customer.DocumentName);
        }

        public List<Customer> GetCustomers() =>
            _col.Find(FilterDefinition<Customer>.Empty).ToList();

        public Customer GetCustomer(Guid customerId) =>
            _col.Find(c => c.Id == customerId).FirstOrDefault();

        public void InsertCustomer(Customer customer) =>
            _col.InsertOne(customer);

        public void UpdateCustomer(Customer customer) =>
            _col.UpdateOne(c => c.Id == customer.Id, Builders<Customer>.Update
                .Set(c => c.IdNumber, customer.IdNumber)
                .Set(c => c.FirsName, customer.FirsName)
                .Set(c => c.MiddleName, customer.MiddleName)
                .Set(c => c.LastName, customer.LastName)
                .Set(c => c.City, customer.City)
                .Set(c => c.Country, customer.Country)
                .Set(c => c.BirthDate, customer.BirthDate)
                .Set(c => c.Email, customer.Email)
                .Set(c => c.Address, customer.Address)
                .Set(c => c.Phone, customer.Phone)
                .Set(c => c.Movil, customer.Movil));

        public void DeleteCustomer(Guid customerId) =>
            _col.DeleteOne(c => c.Id == customerId);
    }
}
