namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object value, int duration);
        bool IsAdd(string key);  //cache de var mı
        void Remove(string key);
        void RemoveByPattern(string pattern); //içinde get olanları sil gibi.

    }
}
