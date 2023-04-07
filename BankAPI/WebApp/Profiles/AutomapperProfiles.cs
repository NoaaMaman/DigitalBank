using AutoMapper;
using BankAPI.Models.DTOS.AccountDTO;
using BankAPI.Models.DTOS.TransactionDTO;
using WebApplication.Models.DTOS.AccountDTO;

namespace WebApplication.Profiles
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
