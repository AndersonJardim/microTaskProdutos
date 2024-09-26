using MicroTask.Domain.Models;

namespace MicroTask.Domain.Interfaces
{
    public interface IProdutosService
    {
        Task<Produtos> ProdutosGetAllAsync();
    }
}