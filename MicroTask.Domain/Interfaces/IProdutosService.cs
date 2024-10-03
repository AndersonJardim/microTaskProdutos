using MicroTask.Domain.Models;

namespace MicroTask.Domain.Interfaces
{
    public interface IProdutosService
    {
        Task<IEnumerable<Produtos>> GetAllAsync();
        Task<Produtos> GetByIdAsync(int id);
    }
}