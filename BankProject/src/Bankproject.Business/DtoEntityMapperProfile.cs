using Bankproject.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bankproject.Business
{
    public class DtoEntityMapperProfile
    {
        public DtoEntityMapperProfile()
        {
            CreateMap<AccountCreate, Account>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<AccountUpdate, Account>();
            CreateMap<Account, AccountGet>();
        }
    }
}
