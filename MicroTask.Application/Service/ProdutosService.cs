using MicroTask.Domain.Interfaces;
using MicroTask.Domain.Models;

namespace MicroTask.Application.Service
{
    public class ProdutosService(
        IProdutosRepository produtosRepository) : IProdutosService
    {
        private readonly IProdutosRepository produtosRepository = produtosRepository;
        public async Task<IEnumerable<Produtos>> GetAllAsync() =>
            await produtosRepository.GetAllAsync();
        public async Task<Produtos?> GetByIdAsync(int id) =>
            await produtosRepository.GetByIdAsync(id);
        public async Task<Produtos> AddAsync(Produtos produto) =>
            await produtosRepository.AddAsync(produto);
        public async Task UpdateAsync(Produtos produto) =>
            await produtosRepository.UpdateAsync(produto);
        public async Task<int> DeleteAsync(int id) =>
            await produtosRepository.DeleteAsync(id);
    }
}