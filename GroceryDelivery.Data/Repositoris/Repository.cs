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
        var entities = await SelectAllAsynch();
        var requiredEntity = entities.FirstOrDefault(e => e.Id == id);
        entities.Remove(requiredEntity);
        var str = JsonConvert.SerializeObject(entities, Formatting.Indented);
        await File.AppendAllTextAsync(Path, str);
        return true;
    }

    public async Task<List<TEntity>> SelectAllAsynch()
    {
        var str =await File.ReadAllTextAsync(Path);
        var entities = JsonConvert.DeserializeObject<List<TEntity>>(str);
        return entities;
    }

    public async Task<TEntity> SelectById(long id)
        => (await SelectAllAsynch()).FirstOrDefault(e => e.Id == id);

    public async Task<TEntity> InsertAsynch(TEntity entity)
    {
        var entities = await SelectAllAsynch();
        entities.Add(entity);
        var str = JsonConvert.SerializeObject(entities);
        await File.WriteAllTextAsync(Path, str);
        return entity;
    }

    public async Task<TEntity> UpdateAsynch(TEntity entity)
    {
        var entities = await SelectAllAsynch();
        await File.WriteAllTextAsync(Path, "[]");

        foreach (var item in entities)
        {
            if (item.Id == entity.Id)
            {
                await InsertAsynch(entity);
                continue;
            }
            await InsertAsynch(item);
        }
        return entity;
    }
}
