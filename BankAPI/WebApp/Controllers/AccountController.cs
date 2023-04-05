using AutoMapper;
using WebApp.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.Models.DTOS.AccountDTO;
using WebApp.Services;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountServiceApp _accountService;
        private readonly IMapper _mapper;

        public AccountController(AccountServiceApp accountService,IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }
        [HttpGet("Index")]
        public async Task<IActionResult> IndexAccount()
        {
            List<AccountDTO> list = new();
            var response = await _accountService.GetAllAsync<APIResponse>();

            if (response != null && response.IsSuccess)
                list = JsonConvert.DeserializeObject<List<AccountDTO>>(Convert.ToString(response.Result));

            return View(list);
        }
    }
}
