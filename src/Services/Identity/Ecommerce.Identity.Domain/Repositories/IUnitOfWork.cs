namespace Ecommerce.Identity.Domain.Repositories;

public interface IUnitOfWork
{
    Task CommitAsync();
}
