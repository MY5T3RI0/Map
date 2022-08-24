using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map.Model
{
    /// <summary>
    /// Элемент хеш таблицы.
    /// </summary>
    /// <typeparam name="TKey">Тип ключа.</typeparam>
    /// <typeparam name="TValue">Тип элемента.</typeparam>
    class Item<TKey, TValue>
    {
        /// <summary>
        /// Ключ.
        /// </summary>
        public TKey Key { get; set; }

        /// <summary>
        /// Значение.
        /// </summary>
        public TValue Value { get; set; }

        /// <summary>
        /// Создать новый ключ.
        /// </summary>
        /// <param name="key">Ключ.</param>
        /// <param name="value">Значение.</param>
        public Item(TKey key, TValue value)
        {
            if (key.Equals(default(TKey)))
            {
                throw new ArgumentNullException(nameof(key), "Ключ не может быть нулевым");
            }

            if (value.Equals(default(TValue)))
            {
                throw new ArgumentNullException(nameof(value), "Значение не может быть нулевым");
            }

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
