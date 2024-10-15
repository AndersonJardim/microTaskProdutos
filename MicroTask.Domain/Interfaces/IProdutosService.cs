using MicroTask.Domain.Models;

namespace MicroTask.Domain.Interfaces
{
    public interface IProdutosService
    {
        Task<IEnumerable<Produtos>> GetAllAsync();
        Task<Produtos?> GetByIdAsync(int id);
        Task<int> AddAsync(Produtos produto);
        Task UpdateAsync(Produtos produto);
        Task<int> DeleteAsync(int id);
    }
}