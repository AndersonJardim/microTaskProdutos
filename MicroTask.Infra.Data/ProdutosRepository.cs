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
        public async Task<Produtos> GetByIdAsync(int id)
        {
            dbConnection.Open();
            string query = $@"
                            SELECT * 
                            FROM Produtos 
                            where Id = @Id";
            return await dbConnection.QueryFirstOrDefaultAsync<Produtos>(query, new { Id = id });
        }
    }
}