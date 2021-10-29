using CustomersMicroservice.Model;
using CustomersMicroservice.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CustomersMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _repository = customerRepository;
        }

        /// <summary>
        /// GetCustomers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            var customers = _repository.GetCustomers();
            return Ok(customers);
        }

        /// <summary>
        /// GetCustomer by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(Guid id)
        {
            var customer = _repository.GetCustomer(id);
            return Ok(customer);
        }

        /// <summary>
        /// InsertCustomer
        /// </summary>
        /// <param name="customerItem"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post([FromBody] Customer customerItem)
        {
            _repository.InsertCustomer(customerItem);
            return CreatedAtAction(nameof(Get), new { id = customerItem.Id }, customerItem);
        }

        /// <summary>
        /// UpdateCustomer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult Put([FromBody] Customer customer)
        {
            if (customer != null)
            {
                _repository.UpdateCustomer(customer);
                return new OkResult();
            }
            return new NoContentResult();
        }

        /// <summary>
        /// DeleteCustomer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _repository.DeleteCustomer(id);
            return new OkResult();
        }
    }
}
