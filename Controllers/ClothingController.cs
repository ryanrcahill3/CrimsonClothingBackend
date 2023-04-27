using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.database;
using api.interfaces;
using api.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothingController : ControllerBase
    {
        // GET: api/Clothing
        [HttpGet]
        public List<Clothing> Get()
        {
            IReadClothing readObject = new ReadClothing();
            List<Clothing> allClothing = readObject.GetAllClothing();
            List<Clothing> modifiedClothing = new List<Clothing>();

            foreach (Clothing clothing in allClothing)
            {
                modifiedClothing.Add(clothing);
            }

            return modifiedClothing;
        }

        // GET: api/Clothing/5
        [HttpGet("{id}", Name = "GetClothingByID")]
        public IActionResult Get(int id)
        {
            IReadClothing readObject = new ReadClothing();
            List<Clothing> allClothing = readObject.GetAllClothing();

            Clothing clothing = allClothing.FirstOrDefault(s => s.ID == id);

            if (clothing == null)
            {
                return NotFound();
            }

            return Ok(clothing);
        }

        // POST: api/Clothing
        [HttpPost]
        public void Post(Clothing value)
        {
            value.Save.CreateClothing(value);
        }

        // PUT: api/Clothing/5
        [HttpPut("{id}")]
        public void Put(Clothing value)
        {
            System.Console.WriteLine("Put method called");
            System.Console.WriteLine(value.ToString());
            value.Update.EditClothing(value);
        }



        // DELETE: api/Clothing/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
