using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpukaAp.Models;
using SpukaAp.Models.DTO;
using SpukaAp.Models.Repository;


namespace SpukaAP01.Controllers
{
    [Route("api/ZusagenDetails")]
    [ApiController]
    public class ZusagenDetailsController : ControllerBase
    {

        private readonly IDataRepository3<TZusagenDetails, ZusagenDetailsDTO> _dataRepository;
        private readonly IMapper _mapper;

        public ZusagenDetailsController(IDataRepository3<TZusagenDetails, ZusagenDetailsDTO> dataRepository, IMapper mapper)
        {
            _dataRepository = dataRepository;
            _mapper = mapper;
        }




        // GET: api/ZusagenDetails
        [HttpGet]
        public IActionResult Get()
        {
            var zusage = _dataRepository.GetAll();
            if (zusage == null)  //String.IsNullOrEmpty(texto)
            {
                return NotFound("Zusagen sind null");

            }


            return Ok(zusage);
        }



        // GET: api/ZusagenDetails/5
        [HttpGet("{id}", Name = "GetZusagenDetails")]
        public IActionResult Get(string id)
        {
            var zusage = _dataRepository.GetDto(id);
            if (zusage == null)  //String.IsNullOrEmpty(texto)
            {
                return NotFound("Zusage not found.");

            }
            return Ok(zusage);

        }

        // POST: api/ZusagenDetails
        [HttpPost]
        public IActionResult Post([FromBody] TZusagenDetails zusagen)
        {

            if (zusagen is null)
            {
                return BadRequest("Zusagen is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _dataRepository.Add(zusagen);

            return CreatedAtRoute("GetZusagenDetails", new { Id = zusagen.ZudId }, null);
        }

        // PUT: api/ZusagenDetails/5
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