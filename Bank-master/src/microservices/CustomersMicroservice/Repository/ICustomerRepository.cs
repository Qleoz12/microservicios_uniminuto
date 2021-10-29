using CustomersMicroservice.Model;
using System;
using System.Collections.Generic;

namespace CustomersMicroservice.Repository
{
    public interface ICustomerRepository
    {
        void DeleteCustomer(Guid customerId);
        Customer GetCustomer(Guid customerId);
        List<Customer> GetCustomers();
        void InsertCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
    }
}
