using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Microsoft.FSharp.Collections;

namespace Gongchengshi.Collections.Generic.Concurrent
{
   public class ConcurrentDictionaryOfSets<TKey, TValue>
   {
      private readonly ConcurrentDictionary<TKey, FSharpSet<TValue>> _sets =
         new ConcurrentDictionary<TKey, FSharpSet<TValue>>();

      public void Add(TKey key, TValue value)
      {
         var set = this[key];
         // Todo: this is very expensive - find a better way than using FSharpSet
         //_sets[key] = set.Add(value);
         // Todo: this creates a copy of the set.  It doesn't actually add to the existing set.  Fix this!
         set.Add(value);
      }

      public ICollection<TValue> this[TKey key]
      {
         get
         {
            return _sets.GetOrAdd(key, arg => new FSharpSet<TValue>(Enumerable.Empty<TValue>()));
         }
      }
   }
}
