using MicroTask.Domain.Interfaces;
using MicroTask.Domain.Models;

namespace MicroTask.Application.Service
{
    public class ProdutosService : IProdutosService
    {
        public async Task<Produtos> ProdutosGetAllAsync()
        {
            await Task.CompletedTask;
            return new Produtos();
        }
    }
}