namespace Utilities
{
    public interface IRepository<TKey, TEntity>
    {
        TEntity Get(TKey id);
        void Save(TEntity entity);
    }
}
