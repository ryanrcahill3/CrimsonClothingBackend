using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.database;
using api.interfaces;
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
            IReadOffers readObject = new ReadOffers();
            List<Offer> allOffer = readObject.GetOffers();
            List<Offer> modifiedOffer = new List<Offer>();

            foreach (Offer offer in allOffer)
            {
                modifiedOffer.Add(offer);
            }

            return modifiedOffer;
        }

        // GET: api/Offers/5
        [HttpGet("{id}", Name = "GetOfferByID")]
        public IActionResult Get(int id)
        {
            IReadOffers readObject = new ReadOffers();
            List<Offer> allOffer = readObject.GetOffers();

            Offer offer = allOffer.FirstOrDefault(s => s.ID == id);

            if (offer == null)
            {
                return NotFound();
            }

            return Ok(offer);
        }

        // POST: api/Offers
        [HttpPost]
        public void Post(Offer value)
        {
            value.Save.CreateOffer(value);
        }


        // PUT: api/Offers/5
        [HttpPut("{id}")]
        public void Put(Offer value)
        {
            value.Update.EditOffer(value);
        }

        // DELETE: api/Offers/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
