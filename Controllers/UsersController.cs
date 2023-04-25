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
        public IActionResult Get(int id)
        {
            IReadUser readObject = new ReadUser();
            List<User> allUser = readObject.GetAllUsers();

            User user = allUser.FirstOrDefault(s => s.ID == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("byemail/{email}", Name = "GetUserByEmail")]
        public IActionResult GetByEmail(string email)
        {
            IReadUser readObject = new ReadUser();
            List<User> allUsers = readObject.GetAllUsers();

            User user = allUsers.FirstOrDefault(s => s.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }



        // POST: api/users
        [HttpPost]
        public void Post(User value)
        {
            value.Save.CreateUser(value);
        }


        // PUT: api/users/5
        [HttpPut("{id}")]
        public void Put(User value)
        {
            value.Update.EditUser(value);
        }


        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
