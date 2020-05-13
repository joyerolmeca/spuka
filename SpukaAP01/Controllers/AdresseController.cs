using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpukaAp.Models;
using SpukaAp.Models.DTO;
using SpukaAp.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpukaAp.Controllers
{
    [Route("api/adresse")]
    [ApiController]

    public class AdresseController: ControllerBase
    {

        private readonly IDataRepository3<TAdressen, AdresseDTO> _dataRepository;
        private readonly IMapper _mapper;

        public AdresseController(IDataRepository3<TAdressen, AdresseDTO> dataRepository, IMapper mapper)
        {
            _dataRepository = dataRepository;
            _mapper = mapper;
        }



        // GET: api/adresse


        [HttpGet]


       

       
        public IActionResult Get()
        {
            var adressen = _dataRepository.GetAll();
            if (adressen == null)  //String.IsNullOrEmpty(texto)
            {
                return NotFound("Adressen sind null");

            }


            return Ok(adressen);
        }

   

        // GET: api/adresse/5

        [HttpGet("{id}", Name = "GetAdresse")]

        public IActionResult Get(string id)
        {

            var adresse = _dataRepository.GetDto(id);
         if (adresse==null)  //String.IsNullOrEmpty(texto)
            {
                return NotFound("Adresse not found.");

            }
            return Ok(adresse);
        }


        // POST: api/adresse

        [HttpPost]
        public IActionResult Post([FromBody] TAdressen adressen)
        {

            if (adressen is null)
            {
                return BadRequest("Adresse is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _dataRepository.Add(adressen);

            return CreatedAtRoute("GetAdresse", new { Id = adressen.AdrAdresse }, null);
        }

        // DELETE: api/ApiWithActions/5

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var adress = _dataRepository.Get(id);    

              
                if (adress==null)
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
