using AutoMapper;
using WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

using WebApplication.Models.DTOS;

using WebApplication.Services;
using WebApplication.Services;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountServicesApp _accountService;
        private readonly IMapper _mapper;

        public AccountController(IAccountServicesApp accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexAccount()
        {
            List<AccountDTO> list = new List<AccountDTO>();
            var response = await _accountService.GetAllAsync<APIResponse>();

            //if (response != null && response.IsSuccess)
            //{
                list = JsonConvert.DeserializeObject<List<AccountDTO>>(Convert.ToString(response.Result));
            //}

            return View(list);
        }

        public async Task<IActionResult> CreateAccount()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAccount(CreateAccountDTO model)
        {
            if(ModelState.IsValid) 
            {
                var response = await _accountService.CreateAsync<APIResponse>(model);
                //if (response != null && response.IsSuccess)
                //{
                    return RedirectToAction(nameof(IndexAccount));
                //}
            }
            return View(model);
        }

        public async Task<IActionResult> UpdateAccount(int accountID)
        {

            var response = await _accountService.GetAsync<APIResponse>(accountID);
            //if(response!= null && response.IsSuccess)
            //{
            AccountDTO model = JsonConvert.DeserializeObject<AccountDTO>(Convert.ToString(response.Result));
            return View(_mapper.Map<UpdateAccountDTO>(model));
            //}
            //return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAccount(UpdateAccountDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.UpdateAsync<APIResponse>(model);
                //if(response!= null && response.IsSuccess)
                //{
                return RedirectToAction(nameof(IndexAccount));
                //}
            }
            return View(model);
        }

        public async Task<IActionResult> DeleteAccount(int accountID)
        {
            var response = await _accountService.GetAsync<APIResponse>(accountID);
            //if(response != null && response.IsSuccess)
            //{
                AccountDTO model = JsonConvert.DeserializeObject<AccountDTO>(Convert.ToString(response.Result));
                return View(model);
            //}
            //return NotFound();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAccount(AccountDTO model)
        {
            var response = await _accountService.DeleteAsync<APIResponse>(model.AccountId);

            //if(response != null && response.IsSuccess)
            //{
                return RedirectToAction(nameof(IndexAccount));
            //}
            //return View(model);
        }
    }
}
