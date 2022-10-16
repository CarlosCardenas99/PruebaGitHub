﻿using AutoMapper;
using Paltarumi.Acopio.Maestro.Dto.Maestro;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Maestro
{
    public class MaestroProfile : Profile
    {
        public MaestroProfile()
        {
            CreateMap<Entity.Maestro, MaestroDto>()
                .ReverseMap();

            CreateMap<Entity.Maestro, GetMaestroDto>()
                .ReverseMap();

            CreateMap<Entity.Maestro, ListMaestroDto>()
                .ReverseMap();
        }
    }
}
