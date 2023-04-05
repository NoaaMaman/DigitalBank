using AutoMapper;
using BankAPI.Models.DTOS.AccountDTO;
using BankAPI.Models.DTOS.TransactionDTO;

namespace BankAPI.Profiles
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<RegisterNewAccountModel, Account>().ReverseMap();
            CreateMap<UpdateAccountModel, Account>().ReverseMap();
            CreateMap<Account, GetAccountModel>().ReverseMap();
            CreateMap<TransactionRequestDto, Transaction>().ReverseMap();


        }

    }
}
