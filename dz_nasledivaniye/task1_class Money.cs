using System.Linq.Expressions;

namespace dz_nasledivaniye;

// Задание 1
// Запрограммируйте класс Money(объект класса оперирует одной валютой)
// для работы с деньгами.
// В классе должны быть предусмотрены поле для хранения целой части денег
// и поле для хранения копеек.
// Реализовать методы для вывода суммы на экран, задания значений для
// частей.
// На базе класса Money создать класс Product для работы с продуктом или
// товаром.
// Реализовать метод, позволяющий уменьшить цену на заданное число.
// Для каждого из классов реализовать необходимые методы и поля.

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Сколько продуктов ввести?");
        short n = Convert.ToInt16(Console.ReadLine());  // ввод кол-ва продуктов для создания массива
        Product[] products = new Product[n];            // создаем ссылку на массив продуктов
        for (int i = 0; i < n; i++)                     // цикл по кол-ву продуктов
        {
            Console.WriteLine($"Продукт №{(i+1)}");
            products[i] = new Product();                // инициализруем каждый продукт
        }
        Console.WriteLine("\nВсе продукты:");

        int count = 1;                                  // переменная для номера п/п
        foreach (Product item in products)
        {           
            Console.WriteLine($"Продукт №{count++}");   // вывод номера п/п
            Console.WriteLine(item);                    // вывод всех продуктов и цены (ToString() класса Priduct)
        }

        Console.WriteLine("\nУменьшить цену. Выберите, для какого продукта?" +
            "(ввести номер продукта)");
        short n1 = 0;                                   // переменная для номера продукта

        try                                             // генерация исключения
        {
            n1 = Convert.ToInt16(Console.ReadLine());   // считываем ввод пользователя
            if (n1 > n)                                 // если произошел выход за пределы кол-ва продуктов - исключение
            {
                throw new Exception($"Ошибка! Введите число не больше {n}!");
            }
        }
        catch ( Exception ex)                           // обработка исключения
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message );
            Console.ForegroundColor = ConsoleColor.White;
        }
      
        for (int i = 0; i < n; i++)                     // цикл по продуктам
        {          
            if (n1 == i+1)                              // если номер продукта - это введенный номер
            {
                products[i]--;                          // уменьшаем цену выбранного продукта
            }
        }
        Console.WriteLine("\nВсе продукты:");
        count = 1;                                      // переменная для номера п/п
        foreach (Product item in products)
        {           
            Console.WriteLine($"Продукт №{count++}");
            Console.WriteLine(item);                    // вывод продуктов и цен в консоль
        }
    }

    class Money  // базовый класс Money
    {
        protected int grn;  // поле Гривна (целая часть)
        public int Grn      // свойство, обсдуживающее поле гривна
        {
            get { return grn; }
            set { grn = value;}
        }

        protected int kop;  // поле Копейка 
        public int Kop      // свойство, обслуживающее поле копейка
        {
            get { return kop; }
            set { kop = value; }
        }

        public Money (int g, int k)  // конструктор
        {
            grn = g;
            kop = k;
        }

        public Money()  // конструктор для ввода с клавиатуры
        {
            Console.WriteLine("Введите часть цены в гривнах:");
            grn = Convert.ToInt32(Console.ReadLine());  // вводит пользователь
            Console.WriteLine("Введите часть цены в копейках:");
            try  // генерация исключения для ввода копеек
            {
                kop = Convert.ToInt32(Console.ReadLine());  // вводит пользователь
                if (kop >= 100)  // если значение kop больше 99
                {
                    kop = 0;  // то инициализируем значение поля 0 и выбрасываем исключение
                    throw new Exception("Ошибка. Чась в копейках не больше 99!");
                }
            }
            catch(Exception e)  // обработка исключения
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }           
        }

        public double Price()  // метод для установки цены
        {
            double price = 0;  // переменная для цены
            try  // генерация исключения
            {
                price = (double)grn + (double)kop/100;  // цена равна формату 00.00
                if (price < 0)  // если цена меньше 0 - выбрасфваем исключение
                {
                    throw new Exception("Внимание! Цена меньше 0!");
                }
            }
            catch (Exception e)  // обработка исключения
            {
                Console.ForegroundColor = ConsoleColor.Red; 
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            return price;
        }

        public override string ToString()  // переоперделение стандартного метода для строкового представления 
        {
            return ($"Цена = {Price()}");
        }
    }

    class Product : Money  // класс Product - наследник класса Money
    {
        private string prod;  // поле Название товара
        public string Prod    // свойство, обслуживающее название
        {
            get { return prod; }
            set { prod = value; }
        }

        public Product() : base()  // конструктор для ввода цены и названия
        {
            Console.WriteLine("Введите название продукта:");
            prod = Console.ReadLine();
        }

        public Product(int g, int k) : base(g,k)  // конструктор для ввода только названия
        {
            Console.WriteLine("Введите название продукта:");
            prod = Console.ReadLine();
        }

        public Product(string product) : base()  // конструктор для ввода только цены
        {
            prod = product;
        }

        public Product(int g, int k, string product) : base(g,k)  // конструктор
        {
            prod = product;
        }

        public override string ToString()  // переоперделение стандартного метода для строкового представления 
        {
            return ($"Цена продукта {prod} = {Price()}");
        }

        public static Product operator --(Product obj)  // перегрузка оператора -- для уменьшения цены
        {
            Console.WriteLine("\nВведите цену, на которую хотите уменьшить " +
                "цену товара (сначала гривны)");
            int n = Convert.ToInt32(Console.ReadLine());  // ввод значения грн
            obj.grn -= n;                                 // уменьшаем значение грн
            Console.WriteLine("\nВведите цену, на которую хотите уменьшить " +
                "цену товара (теперь копейки)");
            int n1 = Convert.ToInt32(Console.ReadLine());  // ввод значения коп
            obj.kop -= n1;                                 // уменьшаем значение коп
            return obj;
        }
    }
}