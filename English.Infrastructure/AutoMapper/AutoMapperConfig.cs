using AutoMapper;
using English.Core.Domain;
using English.Core.Dto;
using English.Core.Entities;
using English.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Infrastructure.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Word, WordDto>();
                cfg.CreateMap<Collection, CollectionDto>();
                cfg.CreateMap<Word, LoginDto>();
            })
            .CreateMapper();
    }
}