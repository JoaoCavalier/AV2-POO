using System.Linq;
using Av2.Api.Controllers.Contracts;
using Av2.Api.Core.Application.ProductAgg.Contracts;
using Av2.Api.Core.Application.ProductAgg.Parsers;
using Av2.Api.Core.Domain.EstoqueAgg.Repositories;
using Av2.Api.Core.Domain.ProductAgg.Entities;

namespace Av2.Api.Controllers.Parsers
{
    public class ProdutoParser : IParser<Produto, IProdutoView>
    {
        public IProdutoView Parse(Produto produto)
        {
            return new ProdutoDto
            {
                Id = produto.ExternalId,
                Nome = produto.Nome,
                Preco = produto.Preco.ToString(),
                Status = produto.Status
            };
        }
    }

    public class ProdutoReportParser : IParser<Produto, IProdutoView>
    {
        private readonly IEstoqueRepository _estoqueRepository;

        public ProdutoReportParser(IEstoqueRepository estoqueRepository)
        {
            _estoqueRepository = estoqueRepository;
        }
        
        public IProdutoView Parse(Produto produto)
        {
            var estoque = _estoqueRepository.Carregar();
            var item = estoque.Itens.First(x => x.ProdutoId == produto.Id);
            return new ProdutoDto
            {
                Id = produto.ExternalId,
                Nome = produto.Nome.ToUpper(),
                Preco = (produto.Preco / 100M).ToString("C"),
                QuantidadeDisponivel = item.QuantidadeDisponivel,
                Status = produto.Status
            };
        }
    }
}