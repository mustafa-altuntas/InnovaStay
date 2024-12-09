using AutoMapper;
using InnovaStay.Business.Mappings.MappProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaStay.Business.Mappings
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DtoMapper>();
            });
            return configuration.CreateMapper();
        });

        public static IMapper Mapper => lazy.Value; 

    }
}
