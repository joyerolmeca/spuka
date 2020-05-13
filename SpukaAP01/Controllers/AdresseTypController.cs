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

    [Route("api/adressetyp")]
    [ApiController]

    public class AdresseTypController: ControllerBase
    {
        private readonly IDataRepository<TAdressenTyp, AdresseTypDTO> _dataRepository;

        public AdresseTypController (IDataRepository<TAdressenTyp, AdresseTypDTO> dataRepository)
        {
            _dataRepository = dataRepository;

        }

        // GET: api/adressetyp


        [HttpGet]
        public IActionResult Get()
        {
            var adressenTyps = _dataRepository.GetAll();

            return Ok(adressenTyps);
        }


        // GET: api/Authors/5

        [HttpGet("{id}", Name = "GetAdresseTyp")]

        public IActionResult Get(int id)
        {

            var adresseTyp = _dataRepository.GetDto(id);
            if (adresseTyp == null)
            {
                return NotFound("Author not found.");

            }
            return Ok(adresseTyp);
        
    }
    }
}
