using CoreMicroservice.Model;
using CoreMicroservice.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CoreMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICoreRepository _coreRepository;
        public CardController(ICoreRepository coreRepository)
        {
            _coreRepository = coreRepository;
        }

        /// <summary>
        /// GetCards
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Card>> Get()
        {
            var accounts = _coreRepository.GetCards();
            return Ok(accounts);
        }

        /// <summary>
        /// GetTransaction by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Card> Get(Guid id)
        {
            var account = _coreRepository.GetCard(id);
            return Ok(account);
        }

        /// <summary>
        /// InsertCard
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post([FromBody] Card card)
        {
            _coreRepository.InsertCard(card);
            return CreatedAtAction(nameof(Get), new { id = card.CardId }, card);
        }

        /// <summary>
        /// UpdateCard
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult Put([FromBody] Card card)
        {
            if (card != null)
            {
                _coreRepository.UpdateCard(card);
                return new OkResult();
            }
            return new NoContentResult();
        }

        /// <summary>
        /// DeleteCard by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _coreRepository.DeleteCard(id);
            return new OkResult();
        }
    }
}
