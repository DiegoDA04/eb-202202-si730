namespace si730ebu20201c334.API.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}