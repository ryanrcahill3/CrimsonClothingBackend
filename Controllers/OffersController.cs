using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrimsonClothingBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        // GET: api/Offers
        [HttpGet]
        public List<Offer> Get()
        {
            return new List<Offer>();
        }

        // GET: api/Offers/5
        [HttpGet("{id}", Name = "GetOfferByID")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Offers
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Offers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Offers/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
