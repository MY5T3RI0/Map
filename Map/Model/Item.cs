using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map.Model
{
    class Item<TKey, TValue>
    {
        public TKey Key { get; set; }

        public TValue Value { get; set; }

        public Item(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Key} - {Value}";
        }
    }
}
