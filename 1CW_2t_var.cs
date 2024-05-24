using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    abstract class Goods
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
        public abstract void Print();
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
    class Product : Goods
    {
        private string _date_of_expiration;
        public string Date_of_expiration { get { return _date_of_expiration; } }
        public Product(string name, int price, int quantity, string date_of_expiration) : base(name, price, quantity)
        {
            _date_of_expiration = date_of_expiration;
        }
        public override void Print()
        {
            Console.WriteLine($"Артикул: {Artikul}, Название товара: {Name}, Цена: {Price}, Количество товаров: {Quantity}, Срок годности: {_date_of_expiration}");
        }
    }
    class Equipment : Goods
    {
        private string _date_of_warranty;
        public string Date_of_warranty { get { return _date_of_warranty; } }
        public Equipment(string name, int price, int quantity, string date_of_warranty) : base(name, price, quantity)
        {
            _date_of_warranty = date_of_warranty;
        }
        public override void Print()
        {
            Console.WriteLine($"Артикул: {Artikul}, Название товара: {Name}, Цена: {Price}, Количество товаров: {Quantity}, Срок годности: {_date_of_warranty}");
        }
    }
    class Tool : Goods
    {
        private int _quality_class;
        public int Quality_class { get { return _quality_class; } }
        public Tool(string name, int price, int quantity, int quality_class) : base(name, price, quantity)
        {
            _quality_class = quality_class;
        }
        public override void Print()
        {
            Console.WriteLine($"Артикул: {Artikul}, Название товара: {Name}, Цена: {Price}, Количество товаров: {Quantity}, Срок годности: {_quality_class}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product("Продукт1", 100, 140, "5 января");
            Product product2 = new Product("Продукт2", 150, 150, "31 декабря");
            Product product3 = new Product("Продукт3", 1000, 30, "10 марта");
            Product product4 = new Product("Продукт4", 5, 1000, "3 апреля");
            Product product5 = new Product("Продукт5", 50, 800, "10 июня");
            Product[] products = new Product[] { product1, product2, product3, product4, product5 };
            Equipment equipment1 = new Equipment("Оборудование1", 755, 140, "25 января");
            Equipment equipment2 = new Equipment("Оборудование2", 10, 15000, "1 июля");
            Equipment equipment3 = new Equipment("Оборудование3", 100, 3050, "14 февраля");
            Equipment equipment4 = new Equipment("Оборудование4", 3, 100000, "15 апреля");
            Equipment equipment5 = new Equipment("Оборудование5", 500, 300, "18 августа");
            Equipment[] equipments = new Equipment[] { equipment1, equipment2, equipment3, equipment4, equipment5 };
            Tool tool1 = new Tool("Вещь1", 1000, 14, 1);
            Tool tool2 = new Tool("Вещь2", 800, 30, 3);
            Tool tool3 = new Tool("Вещь3", 1000, 10, 2);
            Tool tool4 = new Tool("Вещь4", 500, 100, 1);
            Tool tool5 = new Tool("Вещь5", 100, 1000, 2);
            Tool[] tools = new Tool[] { tool1, tool2, tool3, tool4, tool5 };
            Product.SortByPrice(products);
            Equipment.SortByPrice(equipments);
            Tool.SortByPrice(tools);
            Console.WriteLine("Продукты:");
            for (int i = 0; i < products.Length; i++)
            {
                products[i].Print();
            }
            Console.WriteLine();
            Console.WriteLine("Оборудование:");
            for (int i = 0; i < equipments.Length; i++)
            {
                equipments[i].Print();
            }
            Console.WriteLine();
            Console.WriteLine("Вещи:");
            for (int i = 0; i < tools.Length; i++)
            {
                tools[i].Print();
            }
            Console.WriteLine();
            Console.WriteLine("Все товары:");
            Goods[] goods = new Goods[] { product1, product2, product3, product4, product5, equipment1, equipment2, equipment3, equipment4, equipment5, tool1, tool2, tool3, tool4, tool5 };
            Goods.SortByPrice(goods);
            for (int i = 0; i < goods.Length; i++)
            {
                goods[i].Print();
            }
            Console.ReadKey();
        }
    }
}
