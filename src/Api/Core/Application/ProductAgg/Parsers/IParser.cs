using Av2.Api.Core.Application.ProductAgg.Contracts;
using Av2.Api.Core.Domain.ProductAgg.Entities;

namespace Av2.Api.Core.Application.ProductAgg.Parsers
{
    public interface IParser<TFrom, TTo>
    {
        TTo Parse(TFrom from);
    }

    public interface IProdutoParseFactory
    {
        IParser<Produto, IProdutoView> GetProdutoParse();
        IParser<Produto, IProdutoView> GetProdutoReportParse();
    }
}