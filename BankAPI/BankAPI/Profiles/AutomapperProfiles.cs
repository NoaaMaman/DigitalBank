using AutoMapper;
using BankAPI.Models.DTOS.AccountDTO;
using BankAPI.Models.DTOS.TransactionDTO;

namespace BankAPI.Profiles
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<RegisterNewAccountModel, Account>();
            CreateMap<UpdateAccountModel, Account>();
            CreateMap<Account, GetAccountModel>();

            CreateMap<TransactionRequestDto, Transaction>();


        }

    }
}
