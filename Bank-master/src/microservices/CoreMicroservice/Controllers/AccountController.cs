using CoreMicroservice.Model;
using CoreMicroservice.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CoreMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ICoreRepository _coreRepository;
        public AccountController(ICoreRepository coreRepository)
        {
            _coreRepository = coreRepository;
        }

        /// <summary>
        /// GetAccounts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Account>> Get()
        {
            var accounts = _coreRepository.GetAccounts();
            return Ok(accounts);
        }

        /// <summary>
        /// GetAccount by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Account> Get(Guid id)
        {
            var account = _coreRepository.GetAccount(id);
            return Ok(account);
        }

        /// <summary>
        /// InsertAccount
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post([FromBody] Account account)
        {
            _coreRepository.InsertAccount(account);
            return CreatedAtAction(nameof(Get), new { id = account.AccountId }, account);
        }

        /// <summary>
        /// UpdateAccount
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult Put([FromBody] Account account)
        {
            if (account != null)
            {
                _coreRepository.UpdateAccount(account);
                return new OkResult();
            }
            return new NoContentResult();
        }

        /// <summary>
        /// DeleteAccount by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _coreRepository.DeleteAccount(id);
            return new OkResult();
        }
    }
}
