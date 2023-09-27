using GroceryDelivery.Data.IRepositories;
using GroceryDelivery.Domain.Commons;
using GroceryDelivery.Domain.Configurations;
using GroceryDelivery.Domain.Entities;
using Newtonsoft.Json;

namespace GroceryDelivery.Data.Repositoris;
public class Repository<TEntity> : IRepository<TEntity> where TEntity :Auditable
{
    private readonly string Path;

    public Repository()
    {
        if (typeof(TEntity) ==  typeof(Customer))
            Path = DataPath.CustomerDb;

        if (typeof(TEntity) == typeof(Category))
            Path = DataPath.CategoryDb;

        if (typeof(TEntity) == typeof(Driver))
            Path = DataPath.DriverDb;

        if (typeof(TEntity) == typeof(Order))
            Path = DataPath.OrderDb;

        if (typeof(TEntity) == typeof(Product))
            Path = DataPath.ProductDb;

        var str = File.ReadAllText(Path);
        if  (string.IsNullOrEmpty(str))
             File.WriteAllText(Path, "[]");
    }
    public async Task<bool> DeleteAsynch(long id)
    {
        var entities = await SelectAllAsync();
        var requiredEntity = entities.FirstOrDefault(e => e.Id == id);
        entities.Remove(requiredEntity);
        var str = JsonConvert.SerializeObject(entities, Formatting.Indented);
        await File.AppendAllTextAsync(Path, str);
        return true;
    }

    public async Task<List<TEntity>> SelectAllAsync()
    {
        var str =await File.ReadAllTextAsync(Path);
        var entities = JsonConvert.DeserializeObject<List<TEntity>>(str);
        return entities;
    }

    public async Task<TEntity> SelectByIdAsync(long id)
        => (await SelectAllAsync()).FirstOrDefault(e => e.Id == id);

    public async Task<TEntity> InsertAsync(TEntity entity)
    {
        var entities = await SelectAllAsync();
        entities.Add(entity);
        var str = JsonConvert.SerializeObject(entities, Formatting.Indented);
        await File.WriteAllTextAsync(Path, str);
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var entities = await SelectAllAsync();
        await File.WriteAllTextAsync(Path, "[]");

        foreach (var item in entities)
        {
            if (item.Id == entity.Id)
            {
                await InsertAsync(entity);
                continue;
            }
            await InsertAsync(item);
        }
        return entity;
    }
}
