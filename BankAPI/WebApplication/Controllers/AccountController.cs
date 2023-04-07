using AutoMapper;
using WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

using WebApplication.Models.DTOS;

using WebApp.Services;
using WebApplication.Models.DTOS;
using WebApplication.Models.DTOS.AccountDTO;
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
    }
}
