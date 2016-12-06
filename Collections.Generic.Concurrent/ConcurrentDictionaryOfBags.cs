using System.Collections.Concurrent;

namespace Gongchengshi.Collections.Generic.Concurrent
{
    public class ConcurrentDictionaryOfBags<TKey, TValue>
    {
       private readonly ConcurrentDictionary<TKey, ConcurrentBag<TValue>> _bags = 
          new ConcurrentDictionary<TKey, ConcurrentBag<TValue>>();

       public void Add(TKey key, TValue value)
       {
          this[key].Add(value);
       }

       public ConcurrentBag<TValue> this[TKey key]
       {
          get
          {
             return _bags.GetOrAdd(key, arg => new ConcurrentBag<TValue>());
          }
       }
    }
}
