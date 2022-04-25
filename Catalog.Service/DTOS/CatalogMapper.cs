using AutoMapper;
using Catalog.Service.Models;

namespace Catalog.Service.DTOS;

public static class CatalogMapper
{
    public static MapperConfiguration ProductMap()
    {
        var mapper = new MapperConfiguration(config =>
        {
            config.CreateMap<CatalogDTO, Product>().ReverseMap();
            config.CreateMap<NewCatalogDTO, Product>().ReverseMap();
        });

        return mapper;
    }
}