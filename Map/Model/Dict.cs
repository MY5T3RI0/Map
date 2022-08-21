using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map.Model
{
    class Dict<TKey, TValue>
    {
        private int Size = 100;
        private Item<TKey, TValue>[] Items;

        private List<TKey> keys = new List<TKey>();

        public Dict()
        {
            Items = new Item<TKey, TValue>[Size];
        }

        public void Add(TKey key, TValue value)
        {
            if (keys.Contains(key))
            {
                throw new ArgumentException("Элемент с таким ключом уже существует", nameof(key));
            }
            var item = new Item<TKey, TValue>(key, value);
            for (int i = GetHash(key); i < Items.Length; i++)
            {
                if (Items[i] == null)
                {
                    Items[i] = item;
                    keys.Add(key);
                    return;
                }
            }
            for (int i = 0; i < GetHash(key); i++)
            {
                if (Items[i] == null)
                {
                    Items[i] = item;
                    keys.Add(key);
                    return;
                }
            }
            Array.Resize(ref Items, Size*2);
            Items[Size+1] = item;
            keys.Add(key);
            Size = Size * 2;
            return;
        }

        public void Delete(TKey key)
        {
            if (!keys.Contains(key))
            {
                return;
            }

            for (int i = GetHash(key); i < Items.Length; i++)
            {
                if (Items[i] == null)
                {
                    continue;
                }
                if (Items[i].Key.Equals(key))
                {
                    Items[i] = null;
                    keys.Remove(key);
                    return;
                }
            }
            for (int i = 0; i < GetHash(key); i++)
            {
                if (Items[i] == null)
                {
                    continue;
                }
                if (Items[i].Key.Equals(key))
                {
                    Items[i] = null;
                    keys.Remove(key);
                    return;
                }
            }
        }

        public Item<TKey, TValue> Search(TKey key)
        {
            if (!keys.Contains(key))
            {
                return default;
            }

            for (int i = GetHash(key); i < Items.Length; i++)
            {
                if (Items[i] == null)
                {
                    continue;
                }
                if (Items[i].Key.Equals(key))
                {
                    return Items[i];
                }
            }
            for (int i = 0; i < GetHash(key); i++)
            {
                if (Items[i] == null)
                {
                    continue;
                }
                if (Items[i].Key.Equals(key))
                {
                    return Items[i];
                }
            }
            throw new Exception("Ключ найден, но элемента с таким ключом нет");
        }

        public int GetHash(TKey key)
        {
            return key.GetHashCode() % Items.Length;
        }
    }
}
