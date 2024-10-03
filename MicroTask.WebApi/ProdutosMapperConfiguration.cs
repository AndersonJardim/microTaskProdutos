using AutoMapper;
using MicroTask.Application.Dto;
using MicroTask.Domain.Models;

namespace MicroTask.WebApi
{
    public class ProdutosMapperConfiguration : Profile
    {
        public ProdutosMapperConfiguration()
        {
            CreateMap<Produtos, ProdutosDto>();
        }
    }
}