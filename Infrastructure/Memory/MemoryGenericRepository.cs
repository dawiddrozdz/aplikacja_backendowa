using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Interfaces;

namespace Infrastructure.Memory;

public class MemoryGenericRepository<T> : IGenericRepositoryAsync<T> where T : class
{
    private readonly Dictionary<Guid, T> _data = new();

    public Task<T?> FindByIdAsync(Guid id)
    {
        var result = _data.TryGetValue(id, out var value) ? value : null;
        return Task.FromResult(result);
    }

    public Task<IEnumerable<T>> FindAllAsync()
    {
        return Task.FromResult(_data.Values.AsEnumerable());
    }

    public Task<AppCore.Dto.PagedResult<T>> FindPagedAsync(int page, int pageSize)
    {
        var totalCount = _data.Count;
        var items = _data.Values
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        var result = new AppCore.Dto.PagedResult<T>(items, totalCount, page, pageSize);
        return Task.FromResult(result);
    }

    public Task<T> AddAsync(T entity)
    {
        var id = (Guid)entity.GetType().GetProperty("Id")?.GetValue(entity)!;
        _data[id] = entity;
        return Task.FromResult(entity);
    }

    public Task UpdateAsync(T entity)
    {
        var id = (Guid)entity.GetType().GetProperty("Id")?.GetValue(entity)!;
        _data[id] = entity;
        return Task.CompletedTask;
    }

    public Task RemoveByIdAsync(Guid id)
    {
        _data.Remove(id);
        return Task.CompletedTask;
    }
}

