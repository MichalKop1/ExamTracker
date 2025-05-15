using DataAcessLayer.Contracts;
using DomainModel.Models;
using Microsoft.Extensions.Caching.Memory;

namespace DataAcessLayer.Repositories;
public class CacheService : ICacheService
{
    private readonly IMemoryCache _memoryCache;

    public CacheService(IMemoryCache memoryCache)
    {

        _memoryCache = memoryCache;
    }

	public void Clear()
	{
        (_memoryCache as MemoryCache)?.Clear();
	}

	public T Get<T>(string key)
    {
        _memoryCache.TryGetValue(key, out T? value);
        
        if (value != null)
            return value;
        return default!;
    }

    public void Set<T>(string key, T item, TimeSpan expiration)
    {
        var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(expiration);

        _memoryCache.Set(key,item, cacheEntryOptions);
    }
}

public static class CacheExtensions
{
	public static void SetRange<T>(this ICacheService cache, List<T> items,
	Func<T, string> keySelector, TimeSpan expiration)
	{
		foreach (var item in items)
		{
			var key = keySelector(item);
			cache.Set(key, item, expiration);
		}
	}

	public static void SetAddToList<T>(this ICacheService cache, T item, string key, TimeSpan expiration)
	{
		var currentList = cache.Get<HashSet<T>>(key) ?? new HashSet<T>();
		currentList.Add(item);

		cache.Set<HashSet<T>>(key, currentList, expiration);
	}

    public static void SetRemoveFromList<T>(this ICacheService cache, T item, string key, TimeSpan expiration)
    {
		var currentList = cache.Get<HashSet<T>>(key) ?? new HashSet<T>();
        currentList.Remove(item);

		cache.Set<HashSet<T>>(key, currentList, expiration);
	}

	public static void SetList<T>(this ICacheService cache, HashSet<T> dataRange, string key, TimeSpan expiration)
    {
        var currentList = cache.Get<HashSet<T>>(key) ?? new HashSet<T>();
        currentList.UnionWith(dataRange);

        cache.Set<HashSet<T>>(key, currentList, expiration);
    }
}

