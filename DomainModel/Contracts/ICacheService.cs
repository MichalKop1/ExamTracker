namespace DataAcessLayer.Contracts;

public interface ICacheService
{
    T Get<T>(string key);
    void Set<T>(string key, T item, TimeSpan expiration);

    void Clear();
}
