namespace e_Estoque.Domain.Interfaces.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();

        void Dispose();

        IRepositoryFactory RepositoryFactory { get; }
    }
}