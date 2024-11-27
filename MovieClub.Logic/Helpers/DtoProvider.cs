using AutoMapper;
using Water.Entities;
using Water.Entities.Dtos.WaterLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Water.Logic.Helpers
{
    public class DtoProvider
    {
        public Mapper Mapper { get; }

        public DtoProvider()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<WaterLevel, WaterLevelShortViewDto>();
                cfg.CreateMap<WaterLevel, WaterLevelViewDto>();
                cfg.CreateMap<WaterLevelCreateUpdateDto, WaterLevel>();

            });

            Mapper = new Mapper(config);
        }
    }
}
