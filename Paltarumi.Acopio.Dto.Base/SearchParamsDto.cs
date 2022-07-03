﻿namespace Paltarumi.Acopio.Dto.Base
{
    public class SearchParamsDto
    {
        public PageParamsDto? Page { get; set; }
        public IEnumerable<SortParamsDto>? Sort { get; set; }

        public SearchParamsDto()
        {
            Page = new PageParamsDto();
            Sort = new List<SortParamsDto>();
        }
    }

    public class SearchParamsDto<TFilter> : SearchParamsDto
    {
        public TFilter? Filter { get; set; }
    }
}
