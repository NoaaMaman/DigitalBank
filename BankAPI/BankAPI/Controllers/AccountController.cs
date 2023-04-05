using AutoMapper;
using AutoMapper.Configuration.Conventions;
using BankAPI.Models.DTOS.AccountDTO;
using BankAPI.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace BankAPI.Controllers
{
    [ApiController]
    [Route("api/v3/[controller]")]
    public class AccountController : ControllerBase
    {
        //Here We inject the Account service
        private readonly ILogger<AccountController> _logger; 
        private IAccountService _accountService;
        //Bring AutoMapper

        IMapper _mapper;

        public AccountController(IAccountService accountService, IMapper mapper,ILogger<AccountController> logger)
        {
            _logger = logger;
            _accountService = accountService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("create_new_account")]
        public IActionResult RegisterNewAccount([FromBody] RegisterNewAccountModel newAccount)
        {
            if (!ModelState.IsValid) return BadRequest(newAccount);

            //Map to account
            var account = _mapper.Map<Account>(newAccount);
            return Ok(_accountService.Create(account, newAccount.Pin, newAccount.ConfirmPin));

        }
        [HttpGet]
        [Route("get_all_accounts")]
        public IActionResult GetAllAccounts()
        {
            _logger.LogInformation("Getting all Accounts");
            var accounts = _accountService.GetAllAccounts();
            var CleanedAccounts = _mapper.Map<IList<GetAccountModel>>(accounts);
            _logger.LogInformation("Getting all Accounts");
            return Ok(CleanedAccounts);
        }

        [HttpPost]
        [Route("authentication")]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            if (!ModelState.IsValid) return BadRequest(model);

            //Now lets map

            return Ok(_accountService.Authenticate(model.AccountNumber, model.Pin));
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
            _logger.LogInformation("Get Account with ID: "+Id);
            return Ok(cleanedAccount);
        }
        [HttpPut]
        [Route("update_account")]
        public IActionResult UpdateAccount([FromBody] UpdateAccountModel model, string Pin)
        {
            if (!ModelState.IsValid) return BadRequest(model);

            if (model.Pin != Pin || model == null)
                return BadRequest();
            var account = _mapper.Map<Account>(model);
            string pin = model.Pin;
            _accountService.Update(account, pin);
            return NoContent(); ;


        }
        [HttpDelete]
        public IActionResult DeleteAccount(int Id)
        {
            if (Id == 0) return BadRequest();
            // var account = _accountService.GetById(Id);
            var account = _accountService.GetAllAccounts().FirstOrDefault(u => u.AccountId == Id);

            if (account == null)
                return NotFound();
            _accountService.Delete(Id);
            return Ok();


        }
        //[HttpPatch("{id}")]
        //public IActionResult UpdatePartialAccount(int id, JsonPatchDocument<GetAccountModel> patchDTO)
        //{
        //    if (patchDTO == null || id == 0)
        //    {
        //        return BadRequest();
        //    }

        //    var account = _accountService.GetById(id);
        //    if (account == null)
        //    {
        //        return NotFound();
        //    }

        //    patchDTO.ApplyTo(account, ModelState);

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _accountService.Update(account);

        //    return NoContent();
        //}


    }
}
