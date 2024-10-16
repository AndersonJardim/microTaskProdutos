using System.Data;
using Dapper;
using MicroTask.Domain.Interfaces;
using MicroTask.Domain.Models;

namespace MicroTask.Infra.Data
{
    public class ProdutosRepository(IDbConnection dbConnection) : IProdutosRepository
    {
        private readonly IDbConnection dbConnection = dbConnection;

        public async Task<IEnumerable<Produtos>> GetAllAsync()
        {
            dbConnection.Open();
            string query = $@"SELECT * FROM Produtos";
            return await dbConnection.QueryAsync<Produtos>(query);
        }
        public async Task<Produtos?> GetByIdAsync(int id)
        {
            dbConnection.Open();
            string query = $@"
                            SELECT TOP 1 * 
                              FROM Produtos 
                             WHERE Id = @Id";
            return await dbConnection.QueryFirstOrDefaultAsync<Produtos>(query, new { Id = id });
        }
        public async Task<Produtos> AddAsync(Produtos produto)
        {
            var query = "INSERT INTO Produtos (Preco, Descricao) VALUES (@Preco, @Descricao); ";
            await dbConnection.ExecuteAsync(query, new { produto.Preco, produto.Descricao });
            return produto;
        }
        public async Task UpdateAsync(Produtos produto)
        {
            var query = "UPDATE Produtos SET Preco = @Preco, Descricao = @Descricao WHERE Id = @Id";
            await dbConnection.ExecuteAsync(query, new { produto.Preco, produto.Descricao, produto.Id });
        }
        public async Task<int> DeleteAsync(int id)
        {
            var query = "DELETE FROM Produtos WHERE Id = @Id";
            return await dbConnection.ExecuteAsync(query, new { Id = id });
        }
    }
}