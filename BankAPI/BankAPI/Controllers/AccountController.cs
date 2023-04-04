using AutoMapper;
using BankAPI.Models;
using BankAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace BankAPI.Controllers
{
    [ApiController]
    [Route("api/v3/[controller]")]
    public class AccountController  : ControllerBase
    {
        //Here We inject the Account service

        private IAccountService _accountService;
        //Bring AutoMapper

        IMapper _mapper;

        public AccountController(IAccountService accountService,IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("create_new_account")]
        public IActionResult RegisterNewAccount([FromBody]RegisterNewAccountModel newAccount )
        {
            if(!ModelState.IsValid) return BadRequest(newAccount);

            //Map to account
            var account = _mapper.Map<Account>(newAccount);
            return Ok(_accountService.Create(account,newAccount.Pin, newAccount.ConfirmPin));

        }
        [HttpGet]
        [Route("get_all_accounts")]
        public IActionResult GetAllAccounts()
        {
            var accounts = _accountService.GetAllAccounts();
            var CleanedAccounts = _mapper.Map<IList<GetAccountModel>>(accounts);
            return Ok(CleanedAccounts);
        }

        [HttpPost]
        [Route("authentication")]
        public IActionResult Authenticate([FromBody]AuthenticateModel model)
        {
            if (!ModelState.IsValid) return BadRequest(model);

            //Now lets map

            return Ok(_accountService.Authenticate(model.AccountNumber,model.Pin));
        }

        [HttpGet]
        [Route("get_by_account_number")]
        public IActionResult GetByAccountNumber(string AccountNumber)
        {
            if (!Regex.IsMatch(AccountNumber, @"^[0][1-9]\d{9}$|^[1-9]\d{9}$"))
                return BadRequest("Account number must be 10-digit");
            var account = _accountService.GetByNumber(AccountNumber);
            var cleanedAccount = _mapper.Map<GetAccountModel>(account);
            return Ok(cleanedAccount);
        }

        [HttpGet]
        [Route("get_by_account_by_id")]
        public IActionResult GetByAccountId(int Id)
        {
            
            var account = _accountService.GetById(Id);
            var cleanedAccount = _mapper.Map<GetAccountModel>(account);
            return Ok(cleanedAccount);
        }
        [HttpPut]
        [Route("update_account")]
        public IActionResult UpdateAccount([FromBody]UpdateAccountModel model,string Pin)
        {
            if (!ModelState.IsValid) return BadRequest(model);
            var account = _mapper.Map<Account>(model);
            string pin = model.Pin;
            _accountService.Update(account, pin);
            return Ok();


        }
    }   
}
