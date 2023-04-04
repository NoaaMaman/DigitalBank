using AutoMapper;
using BankAPI.Models.DTOS.TransactionDTO;
using BankAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankAPI.Controllers
{
    [ApiController]
    [Route("api/v3/[controller]")]

    public class TransactionController : ControllerBase
    {
        private ITransactionService _transactionService;
        IMapper _mapper;

        public TransactionController(ITransactionService transactionService,IMapper mapper)
        {
            _transactionService = transactionService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Creat_new_Transaction")]
        public IActionResult CreateNewTransaction([FromBody] TransactionRequestDto transactionRequest)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var transaction = _mapper.Map<Transaction>(transactionRequest);
            return Ok(_transactionService.CreateNewTransaction(transaction));

        }


        [HttpPost]
        [Route("make_deposite")]
        public IActionResult MakeDeposite(string AccountNumber, decimal Amount, string TransactionPin)
        {
            if (!Regex.IsMatch(AccountNumber, @"^[0][1-9]\d{9}$|^[1-9]\d{9}$"))
                return BadRequest("Account number must be 10-digit");
            return Ok(_transactionService.MakeDeposite(AccountNumber, Amount, TransactionPin));

        }

        [HttpPost]
        [Route("Make Withdrawl")]
        public IActionResult MakeWithdrawl(string AccountNumber, decimal Amount, string TransactionPin)
        {
            if (!Regex.IsMatch(AccountNumber, @"^[0][1-9]\d{9}$|^[1-9]\d{9}$"))
                return BadRequest("Account number must be 10-digit");
            return Ok(_transactionService.MakeWithdrawl(AccountNumber, Amount, TransactionPin));
        }

        [HttpPost]
        [Route("make_funds_transafer")]
        public IActionResult MakeFundsTransfer(string FromAccount, string ToAccount, decimal Amount, string TransactionPin)
        {
            if ((!Regex.IsMatch(FromAccount, @"^[0][1-9]\d{9}$|^[1-9]\d{9}$"))||(!Regex.IsMatch(ToAccount, @"^[0][1-9]\d{9}$|^[1-9]\d{9}$")))
                return BadRequest("Account number must be 10-digit");

            return Ok(_transactionService.MakeFundsTransfer(FromAccount,ToAccount,Amount, TransactionPin));
        }

    }
}
