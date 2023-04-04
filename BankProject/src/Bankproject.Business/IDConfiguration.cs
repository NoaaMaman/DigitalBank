using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankproject.Business
{
    public class IDConfiguration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DtoEntityMapperProfile));
            services.AddScoped<IAddressService, AddressService>();
        }
    }
}
