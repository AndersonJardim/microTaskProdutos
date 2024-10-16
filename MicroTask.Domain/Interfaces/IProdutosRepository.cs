using MicroTask.Domain.Models;

namespace MicroTask.Domain.Interfaces
{
    public interface IProdutosRepository
    {
        Task<IEnumerable<Produtos>> GetAllAsync();
        Task<Produtos?> GetByIdAsync(int id);
        Task<Produtos> AddAsync(Produtos produto);
        Task UpdateAsync(Produtos produto);
        Task<int> DeleteAsync(int id);
    }
}