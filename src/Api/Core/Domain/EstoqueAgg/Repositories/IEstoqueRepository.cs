using Av2.Api.Core.Domain.EstoqueAgg.Entities;

namespace Av2.Api.Core.Domain.EstoqueAgg.Repositories
{
    public interface IEstoqueRepository
    {
        void Adicionar(EstoqueItem estoqueItem);
        Estoque Carregar();
    }
}