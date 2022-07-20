﻿using AutoMapper;
using Paltarumi.Acopio.Maestro.Dto.Vehiculo;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Maestro
{
    public class VehiculoProfile : Profile
    {
        public VehiculoProfile()
        {
            /*CreateMap<Entity.Vehiculo, Entity.Vehiculo>()
                .ReverseMap();*/

            CreateMap<Entity.Vehiculo, VehiculoDto>()
                .ReverseMap();

            CreateMap<Entity.Vehiculo, CreateVehiculoDto>()
                .ReverseMap();

            CreateMap<Entity.Vehiculo, UpdateVehiculoDto>()
                .ReverseMap();

            CreateMap<Entity.Vehiculo, GetVehiculoDto>()
                //.ForMember(x => x.Marca, opt => opt.MapFrom(x => x.IdVehiculoMarcaNavigation != null ? x.IdVehiculoMarcaNavigation.Descripcion: string.Empty))
                //.ForMember(x => x.TipoVehiculo, opt => opt.MapFrom(x => x.IdTipoVehiculoNavigation != null ? x.IdTipoVehiculoNavigation.Descripcion : string.Empty))
                .ReverseMap();

            CreateMap<Entity.Vehiculo, SearchVehiculoDto>()
                .ReverseMap();
        }
    }
}
