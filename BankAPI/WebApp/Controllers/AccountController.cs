using AutoMapper;
using WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Models.DTOS.AccountDTO;
using WebApp.Services;
using WebApp.Services.IServices;

namespace WebApp.Controllers
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

        [HttpGet("Index")]
        public async Task<IActionResult> IndexAccount()
        {
            List<AccountDTO> list = new List<AccountDTO>();
            var response = await _accountService.GetAllAsync<APIResponse>();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<AccountDTO>>(Convert.ToString(response.Result));
            }

            return View(list);
        }
    }
}
