namespace GroceryDelivery.Data.IRepositories;

public interface IRepository<TEntity>
{
    public Task<TEntity> InsertAsynch(TEntity entity);
    public Task<TEntity> UpdateAsynch(TEntity entity);
    public Task<bool> DeleteAsynch(long  id);
    public Task<TEntity> SelectById(long id);
    public Task<List<TEntity>> SelectAllAsynch();
}
