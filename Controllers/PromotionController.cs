using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.interfaces;
using api.database;
using api.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrimsonClothingBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        // GET: api/Promotion
        [HttpGet]
        public List<Promotion> Get()
        {
            IReadPromotions readObject = new ReadPromotions();
            List<Promotion> allPromotion = readObject.GetPromotions();
            List<Promotion> modifiedPromotion = new List<Promotion>();

            foreach (Promotion promotion in allPromotion)
            {
                modifiedPromotion.Add(promotion);
            }

            return modifiedPromotion;
        }

        // GET: api/Promotion/5
        [HttpGet("{id}", Name = "GetPromotionByID")]
        public IActionResult Get(int id)
        {
            IReadPromotions readObject = new ReadPromotions();
            List<Promotion> allPromotion = readObject.GetPromotions();

            Promotion promotion = allPromotion.FirstOrDefault(s => s.ID == id);

            if (promotion == null)
            {
                return NotFound();
            }

            return Ok(promotion);
        }

        // POST: api/Promotion
        [HttpPost]
        public void Post(Promotion value)
        {
            value.promotionDate = DateTime.Now;
            value.Save.CreatePromotion(value);
        }


        // PUT: api/Promotion/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Promotion/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
