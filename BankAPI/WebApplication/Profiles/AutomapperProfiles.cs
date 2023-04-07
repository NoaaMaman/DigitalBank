using AutoMapper;
using BankAPI.Models.DTOS.AccountDTO;
using WebApplication.Models.DTOS.AccountDTO;

namespace WebApplication.Profiles
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<AccountDTO, CreateAccountDTO>().ReverseMap();
            CreateMap<AccountDTO, UpdateAccountModel>().ReverseMap();
            
            CreateMap<UpdateAccountModel, AccountDTO>().ReverseMap();
            CreateMap<AccountDTO,UpdateAccountModel>().ReverseMap();



        }

    }
}
