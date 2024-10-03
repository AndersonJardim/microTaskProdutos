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
    }
}