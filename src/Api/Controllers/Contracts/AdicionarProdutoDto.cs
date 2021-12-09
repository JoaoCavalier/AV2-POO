using Av2.Api.Core.Application.ProductAgg.Contracts;

namespace Av2.Api.Controllers.Contracts
{
    public class AdicionarProdutoDto : IAdicionarProduto
    {
        public string Nome { get; set; }
        public long Preco { get; set; }
    }
}