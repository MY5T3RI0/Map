using Map.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map
{
    class Program
    {
        static void Main(string[] args)
        {
            var map = new Dict<int, string>();

            map.Add(1, "Женя");
            map.Add(2, "Миша");
            map.Add(3, "Саша");
            map.Add(4, "Люся");
            map.Add(101, "Оля");

            map.Delete(4);

            Console.WriteLine(map.Search(2));

            Console.WriteLine(map.Search(4));

            Console.WriteLine(map.Search(1));

            Console.WriteLine(map.Search(101));

            Console.ReadLine();
        }
    }
}
