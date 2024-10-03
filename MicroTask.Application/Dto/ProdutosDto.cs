using System.Text.Json.Serialization;

namespace MicroTask.Application.Dto
{
    public class ProdutosDto
    {
        [JsonPropertyName("IdProduto")]
        public int Id { get; set; }

        [JsonPropertyName("PrecoProduto")]
        public decimal Preco { get; set; }

        [JsonPropertyName("DescricaoProduto")]
        public string Descricao { get; set; }
    }
}