using MediatR;
using Av2.Api.Core.Domain.ProductAgg.Entities;

namespace Av2.Api.Core.Domain.ProductAgg.Events
{
    public class ProdutoCriado : INotification
    {
        public ProdutoCriado(Produto produto)
        {
            Produto = produto;
        }

        public Produto Produto { get; }
    }
}