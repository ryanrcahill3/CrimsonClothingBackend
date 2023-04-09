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
    public class TransactionsController : ControllerBase
    {
        // GET: api/Transactions
        [HttpGet]
        public List<Transaction> Get()
        {
            IReadTransactions readObject = new ReadTransactions();
            List<Transaction> allTransactions = readObject.GetAllTransactions();
            List<Transaction> modifiedTransactions = new List<Transaction>();

            foreach (Transaction transaction in allTransactions)
            {
                modifiedTransactions.Add(transaction);
            }

            return modifiedTransactions;
        }

        // GET: api/Transactions/5
        [HttpGet("{id}", Name = "GetAllTransactions")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Transactions
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Transactions/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Transactions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
