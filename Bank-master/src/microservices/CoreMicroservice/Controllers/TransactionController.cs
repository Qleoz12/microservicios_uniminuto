using CoreMicroservice.Model;
using CoreMicroservice.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CoreMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ICoreRepository _coreRepository;
        public TransactionController(ICoreRepository coreRepository)
        {
            _coreRepository = coreRepository;
        }

        /// <summary>
        /// GetTransactions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Transaction>> Get()
        {
            var accounts = _coreRepository.GetTransactions();
            return Ok(accounts);
        }

        /// <summary>
        /// GetTransaction by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Transaction> Get(Guid id)
        {
            var account = _coreRepository.GetTransaction(id);
            return Ok(account);
        }

        /// <summary>
        /// InsertTransaction
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post([FromBody] Transaction transaction)
        {
            _coreRepository.InsertTransaction(transaction);
            return CreatedAtAction(nameof(Get), new { id = transaction.AccountId }, transaction);
        }

        /// <summary>
        /// UpdateTransaction
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult Put([FromBody] Transaction transaction)
        {
            if (transaction != null)
            {
                _coreRepository.UpdateTransaction(transaction);
                return new OkResult();
            }
            return new NoContentResult();
        }

        /// <summary>
        /// DeleteTransaction by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _coreRepository.DeleteTransaction(id);
            return new OkResult();
        }
    }
}
