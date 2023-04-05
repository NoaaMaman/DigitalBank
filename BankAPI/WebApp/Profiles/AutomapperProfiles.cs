using AutoMapper;
using BankAPI.Models.DTOS.AccountDTO;
using BankAPI.Models.DTOS.TransactionDTO;
using WebApp.Models.DTOS.AccountDTO;

namespace WebApp.Profiles
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<AccountDTO, RegisterNewAccountModel>().ReverseMap();
            CreateMap<AccountDTO, UpdateAccountModel>().ReverseMap();
            
            CreateMap<UpdateAccountModel, AccountDTO>().ReverseMap();
            CreateMap<AccountDTO,UpdateAccountModel>().ReverseMap();



        }

    }
}
