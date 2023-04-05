using AutoMapper;
using AutoMapper.Configuration.Conventions;
using BankAPI.Models;
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
    [Route("api/AccountAPI")]
    public class AccountController : ControllerBase
    {
        //Here We inject the Account service
        private readonly ILogger<AccountController> _logger; 
        private IAccountService _accountService;
        //Bring AutoMapper
        private readonly APIResponse _response;


        IMapper _mapper;

        public AccountController(IAccountService accountService, IMapper mapper,ILogger<AccountController> logger)
        {
            _logger = logger;
            _accountService = accountService;
            _mapper = mapper;
            this._response = new();
        }

        [HttpPost]
        [Route("create_new_account")]
        public async Task<ActionResult<APIResponse>> RegisterNewAccount([FromBody]RegisterNewAccountModel newAccount)
        {
            if (!ModelState.IsValid) return BadRequest(newAccount);

            //Map to account
            var account = _mapper.Map<Account>(newAccount);
            _response.Result = _accountService.CreateAsync(account, newAccount.Pin, newAccount.ConfirmPin);
            _response.StatusCode = System.Net.HttpStatusCode.OK; 

            return Ok();

        }
        [HttpGet]
        [Route("get_all_accounts")]
        public async Task<ActionResult<APIResponse>> GetAllAccounts()
        {
            _logger.LogInformation("Getting all Accounts");
            var accounts = await _accountService.GetAllAccountsAsync();
            _response.Result = _mapper.Map<IList<GetAccountModel>>(accounts);
            _response.StatusCode = System.Net.HttpStatusCode.OK;
            //_logger.LogInformation("Getting all Accounts");
            return Ok(_response);
        }

        [HttpPost]
        [Route("authentication")]
        public async Task<ActionResult<APIResponse>> Authenticate([FromBody] AuthenticateModel model)
        {
            if (!ModelState.IsValid) return BadRequest(model);

            var result = await _accountService.AuthenticateAsync(model.AccountNumber, model.Pin);
            _response.Result = result;
            _response.StatusCode = System.Net.HttpStatusCode.OK;

            return Ok(_response);
        }


        [HttpGet]
        [Route("get_by_account_number")]
        public IActionResult GetByAccountNumber(string AccountNumber)
        {
            if (!Regex.IsMatch(AccountNumber, @"^[0][1-9]\d{9}$|^[1-9]\d{9}$"))
                return BadRequest("Account number must be 10-digit");
            var account = _accountService.GetByNumberAsync(AccountNumber);
            var cleanedAccount = _mapper.Map<GetAccountModel>(account);
            return Ok(cleanedAccount);
        }

        [HttpGet]
        [Route("get_by_account_by_id")]
        public async Task<ActionResult<APIResponse>> GetByAccountId(int Id)
        {

            var account = await _accountService.GetByIdAsync(Id);
            _response.Result = _mapper.Map<GetAccountModel>(account);
            _response.StatusCode=System.Net.HttpStatusCode.OK;

            //_logger.LogInformation("Get Account with ID: "+Id);
            return Ok(_response);
        }
        [HttpPut]
        [Route("update_account")]
        public IActionResult UpdateAccount([FromBody]UpdateAccountModel model, string Pin)
        {
            if (!ModelState.IsValid) return BadRequest(model);

            if (model.Pin != Pin || model == null)
                return BadRequest();
            var account = _mapper.Map<Account>(model);
            string pin = model.Pin;
            _accountService.UpdateAsync(account, pin);
            return NoContent(); ;


        }
        [HttpDelete]
        public IActionResult DeleteAccount(int Id)
        {
            if (Id == 0) return BadRequest();
            // var account = _accountService.GetById(Id);
            var account = _accountService.GetByIdAsync(Id);
            if (account == null)
            {
                return NotFound();
            }


           
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
