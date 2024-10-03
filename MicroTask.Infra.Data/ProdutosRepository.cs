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

            return await dbConnection.QueryAsync<Produtos>("SELECT * FROM Produtos");
        }
    }
}