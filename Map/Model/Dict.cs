using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map.Model
{
    /// <summary>
    /// Словарь.
    /// </summary>
    /// <typeparam name="TKey">Тип ключа.</typeparam>
    /// <typeparam name="TValue">Тип элемента.</typeparam>
    class Dict<TKey, TValue>
    {
        /// <summary>
        /// Начальный размер массива элементов.
        /// </summary>
        private int Size = 100;

        /// <summary>
        /// Массив элементов.
        /// </summary>
        private Item<TKey, TValue>[] Items;

        /// <summary>
        /// Список ключей.
        /// </summary>
        private List<TKey> keys = new List<TKey>();

        /// <summary>
        /// Создать новый словарь.
        /// </summary>
        public Dict()
        {
            Items = new Item<TKey, TValue>[Size];
        }

        /// <summary>
        /// Добавить элемент в словарь.
        /// </summary>
        /// <param name="key">Ключ.</param>
        /// <param name="value">Значение.</param>
        public void Add(TKey key, TValue value)
        {
            if (key.Equals(default(TKey)))
            {
                throw new ArgumentNullException(nameof(key), "Ключ не может быть нулевым");
            }

            if (value.Equals(default(TValue)))
            {
                throw new ArgumentNullException(nameof(value), "Значение не может быть нулевым");
            }

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

        /// <summary>
        /// Удалить элемент.
        /// </summary>
        /// <param name="key">Ключ.</param>
        public void Delete(TKey key)
        {
            if (key.Equals(default(TKey)))
            {
                throw new ArgumentNullException(nameof(key), "Ключ не может быть нулевым");
            }

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

        /// <summary>
        /// Поиск элемента в словаре.
        /// </summary>
        /// <param name="key">Ключ.</param>
        /// <returns>Искомый элемент.</returns>
        public Item<TKey, TValue> Search(TKey key)
        {
            if (key.Equals(default(TKey)))
            {
                throw new ArgumentNullException(nameof(key), "Ключ не может быть нулевым");
            }

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

        /// <summary>
        /// Хеширование ключа.
        /// </summary>
        /// <param name="key">Ключ.</param>
        /// <returns>Хеш ключа.</returns>
        public int GetHash(TKey key)
        {
            if (key.Equals(default(TKey)))
            {
                throw new ArgumentNullException(nameof(key), "Ключ не может быть нулевым");
            }

            return key.GetHashCode() % Items.Length;
        }
    }
}
