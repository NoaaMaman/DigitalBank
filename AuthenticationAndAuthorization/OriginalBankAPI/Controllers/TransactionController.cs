using BankApI.Models;
using Microsoft.AspNetCore.Mvc;
using OriginalBankAPI.Services;

namespace OriginalBankAPI.Controllers
{
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository repository;
        public TransactionController(ITransactionRepository repository)
        {
            
            this.repository = repository;
        }
        [HttpGet]
        public List<Transaction> Get()
        {
            return repository.GatAllTransactions();
        }
        //public Transaction Get(int id)
        //{
        //    var transaction = repository.GetTransactionById(id);
        //    if(transaction == null)
        //    {
        //        //return NotFound();

        //    }
        //    return transaction;
        //}
        //[HttpPost]
        //public void Post()
        //{

        //}
        //[HttpPut]
        //public void Put(Transaction transaction) 
        //{
        //}

        //[HttpDelete]
        //public void Delete(Transaction transaction) 
        //{
        //}

        
    }
}
