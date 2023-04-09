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
    public class UsersController : ControllerBase
    {
        // GET: api/users
        [HttpGet]
        public List<User> Get()
        {
            IReadUser readObject = new ReadUser();
            List<User> allUsers = readObject.GetAllUsers();
            List<User> modifiedUsers = new List<User>();

            foreach (User user in allUsers)
            {
                modifiedUsers.Add(user);
            }

            return modifiedUsers;
        }

        // GET: api/users/5
        [HttpGet("{id}", Name = "GetUserByID")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/users
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
