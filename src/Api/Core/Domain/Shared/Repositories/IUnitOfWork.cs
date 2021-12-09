namespace Av2.Api.Core.Domain.Shared.Repositories
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}