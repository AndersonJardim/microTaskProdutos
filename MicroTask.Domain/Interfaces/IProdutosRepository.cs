using MicroTask.Domain.Models;

namespace MicroTask.Domain.Interfaces
{
    public interface IProdutosRepository
    {
        Task<IEnumerable<Produtos>> GetAllAsync();
    }
}