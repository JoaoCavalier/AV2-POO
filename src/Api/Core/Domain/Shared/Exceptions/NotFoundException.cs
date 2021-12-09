using System;

namespace Av2.Api.Core.Domain.Shared.Exceptions
{
    public sealed class NotFoundException : Exception
    {
        public NotFoundException(string entityName, string id) : base($"O {entityName} não foi encontrado.")
        {
            Data.Add(nameof(id), id);
        }
    }
}