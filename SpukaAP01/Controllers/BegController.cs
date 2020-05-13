using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpukaAp.Models;
using SpukaAp.Models.DTO;
using SpukaAp.Models.Repository;

namespace SpukaAp.Controllers
{
    [Route("api/Beg")]
    [ApiController]
    public class BegController : ControllerBase
    {

        private readonly IDataRepository3<TBeguenstigte, BeguenstigteDTO> _dataRepository;

        public BegController(IDataRepository3<TBeguenstigte, BeguenstigteDTO> dataRepository)
        {
            _dataRepository = dataRepository;
            
        }


        // GET: api/Beg
        [HttpGet]
        public IActionResult Get()
        {
            var beg = _dataRepository.GetAll();
            if (beg == null)  //String.IsNullOrEmpty(texto)
            {
                return NotFound("Adressen sind null");

            }


            return Ok(beg);

        }

        // GET: api/Beg/5
        [HttpGet("{id}", Name = "GetBeg")]
        public IActionResult Get(string id)
        {
            var beg = _dataRepository.GetDto(id);
            if (beg == null)  //String.IsNullOrEmpty(texto)
            {
                return NotFound("Adresse not found.");

            }
            return Ok(beg);

        }





        // POST: api/Beg
        [HttpPost]
        public IActionResult Post([FromBody] TBeguenstigte beg)
        {

            if (beg is null)
            {
                return BadRequest("Beguenstigte is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _dataRepository.Add(beg);

            return CreatedAtRoute("GetBeg", new { Id = beg.BegBeguenstigter }, null);
        }
        

       // PUT: api/Beg/5
       [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {

            try
            {
                var adress = _dataRepository.Get(id);


                if (adress == null)
                {
                    return NotFound("Adresse not found.");
                }


                _dataRepository.Delete(adress);


                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
