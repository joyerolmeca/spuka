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
    [Route("api/Zusagen")]
    [ApiController]
    public class ZusagenController : ControllerBase
    {

        private readonly IDataRepository3 <TZusagen, ZusageDTO> _dataRepository;
    private readonly IMapper _mapper;

    public ZusagenController(IDataRepository3<TZusagen, ZusageDTO> dataRepository, IMapper mapper)
    {
        _dataRepository = dataRepository;
        _mapper = mapper;
    }



    
        // GET: api/Zusagen
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


      
        // GET: api/Zusagen/5
        [HttpGet("{id}", Name = "GetZusagen")]
        public IActionResult Get(string id)
        {
            var zusage = _dataRepository.GetDto(id);
            if (zusage == null)  //String.IsNullOrEmpty(texto)
            {
                return NotFound("Zusage not found.");

            }
            return Ok(zusage);

        }

        // POST: api/Zusagen
        [HttpPost]
        public IActionResult Post([FromBody] TZusagen zusagen)
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

            return CreatedAtRoute("GetZusagen", new { Id = zusagen.ZusZusage }, null);
        }

        // PUT: api/Zusagen/5
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
