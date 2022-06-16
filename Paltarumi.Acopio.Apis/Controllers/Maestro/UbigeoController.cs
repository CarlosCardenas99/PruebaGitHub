using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Paltarumi.Acopio.Application.Abstractions.Maestro;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Ubigeo;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Apis.Controllers.Maestro
{
    [ApiController]
    [Route("api/ubigeo")]
    public class UbigeoController
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IUbigeoApplication _ubigeoApplication;
        private readonly IRepository<Entity.Ubigeo> _ubigeoRepositoryBase;

        public UbigeoController(
            IUbigeoApplication ubigeoApplication,
            IRepository<Entity.Ubigeo> ubigeoRepositoryBase
        )
        {
            _memoryCache = new MemoryCache(new MemoryCacheOptions());
            _ubigeoApplication = ubigeoApplication;
            _ubigeoRepositoryBase = ubigeoRepositoryBase;
        }

        [HttpGet("{id}")]
        public async Task<ResponseDto<GetUbigeoDto>> Get(string id)
            => await _ubigeoApplication.Get(id);

        [HttpGet("ubigeos")]
        public async Task<ResponseDto<IEnumerable<DepartamentoDto>>> Departamentos()
        {
            return await _memoryCache.GetOrCreateAsync("Ubigeo", async (entry) =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

                var departamentos = await _ubigeoRepositoryBase
                    .FindAllAsNoTracking()
                    .Select(x =>
                        new DepartamentoDto
                        {
                            Codigo = x.CodigoUbigeo.Substring(0, 2),
                            Nombre = x.Departamento
                        })
                    .Distinct()
                    .ToListAsync();

                foreach (var departamento in departamentos)
                {
                    departamento.Provincias = await _ubigeoRepositoryBase
                        .FindAllAsNoTracking()
                        .Where(x => x.CodigoUbigeo.StartsWith(departamento.Codigo))
                        .Select(x =>
                        new ProvinciaDto
                        {
                            Codigo = x.CodigoUbigeo.Substring(0, 4),
                            Nombre = x.Provincia
                        })
                        .Distinct()
                        .ToListAsync();

                    foreach (var provincia in departamento.Provincias)
                    {
                        provincia.Distritos = await _ubigeoRepositoryBase
                        .FindAllAsNoTracking()
                        .Where(x => x.CodigoUbigeo.StartsWith(provincia.Codigo))
                        .Select(x =>
                        new DistritoDto
                        {
                            Codigo = x.CodigoUbigeo,
                            Nombre = x.Distrito
                        })
                        .Distinct()
                        .ToListAsync();
                    }
                }

                var response = new ResponseDto<IEnumerable<DepartamentoDto>>();

                response.UpdateData(departamentos);

                return response;
            });
        }

        [HttpPost("search")]
        public async Task<ResponseDto<SearchResultDto<SearchUbigeoDto>>> Search(SearchParamsDto<UbigeoFilterDto> searchParams)
            => await _ubigeoApplication.Search(searchParams);
    }

    public class DepartamentoDto
    {
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public IEnumerable<ProvinciaDto>? Provincias { get; set; }
    }

    public class ProvinciaDto
    {
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public IEnumerable<DistritoDto>? Distritos { get; set; }
    }

    public class DistritoDto
    {
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
    }
}
