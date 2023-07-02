using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helpers
{
    public class AutomapperHelper
    {
        public static IMapper GetMapper() 
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDto, User>().ReverseMap();                
                cfg.CreateMap<UserDeleteDto, User>().ReverseMap();                
            });

            var mapper = configuration.CreateMapper();

            return mapper;
        }
    }
}
