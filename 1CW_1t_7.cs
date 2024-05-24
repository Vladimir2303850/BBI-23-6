using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    struct Goods
    {
        private string _name;
        private int _artikul;
        private int _price;
        private int _quantity;
        public string Name { get { return _name; } }
        public int Artikul { get { return _artikul; } }
        public int Price { get { return _price; } }
        public int Quantity { get { return _quantity; } }
        public Goods(string name, int price, int quantity)
        {
            _name = name;
            _artikul = GenerateArtikul();
            _price = price;
            _quantity = quantity;
        }
        private static int artikul = 0;
        private int GenerateArtikul()
        {
            return artikul++;
        }
        public void Print()
        {
            Console.WriteLine($"Артикул: {_artikul}, Название товара:{_name}, Цена: {_price}, Количество товаров: {_quantity}");
        }
        public static void SortByPrice(Goods[] goods)
        {
            for (int i = 0; i < goods.Length - 1; i++)
            {
                for (int j = 0; j < goods.Length - i - 1; j++)
                {
                    if (goods[j].Price > goods[j + 1].Price)
                    {
                        Goods temp = goods[j];
                        goods[j] = goods[j + 1];
                        goods[j + 1] = temp;
                    }
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Goods good1 = new Goods("Ложка", 100, 140);
            Goods good2 = new Goods("Вилка", 150, 150);
            Goods good3 = new Goods("Мышка", 1000, 30);
            Goods good4 = new Goods("Листик", 5, 1000);
            Goods good5 = new Goods("Кнопка", 50, 800);
            Goods[] goods = new Goods[] {good1, good2, good3, good4, good5};
            Goods.SortByPrice(goods);
            for (int i = 0; i < goods.Length; i++)
            {
                goods[i].Print();
            }
            Console.ReadKey();
        }
    }
}
