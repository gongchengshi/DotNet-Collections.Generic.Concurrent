using System.Collections.Concurrent;

namespace Gongchengshi.Collections.Generic.Concurrent
{
   public class ConcurrentDictionaryOfDictionaries<TKey, TSubKey, TValue>
   {
      private readonly ConcurrentDictionary<TKey, ConcurrentDictionary<TSubKey, TValue>> _dictionaries =
         new ConcurrentDictionary<TKey, ConcurrentDictionary<TSubKey, TValue>>();

      public void Add(TKey key, TSubKey subKey, TValue value)
      {
         this[key].GetOrAdd(subKey, arg => value);
      }

      public ConcurrentDictionary<TSubKey, TValue> this[TKey key]
      {
         get { return _dictionaries.GetOrAdd(key, arg => new ConcurrentDictionary<TSubKey, TValue>()); }
      }
   }
}
