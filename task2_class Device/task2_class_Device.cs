using System.Security.Cryptography.X509Certificates;

namespace task2_class_Device;

// Задание 2
// Создать базовый класс «Устройство» и производные классы «Чайник»,
// «Микроволновка», «Автомобиль», «Пароход». С помощью конструктора
// установить имя каждого устройства и его характеристики.
// Реализуйте для каждого из классов методы:
// ■ Sound — издает звук устройства (пишем текстом вконсоль);
// ■ Show — отображает название устройства;
// ■ Desc — отображает описание устройства.

internal class task2_class_Device
{
    static void Main(string[] args)
    {
        Device[] devices =  // создание указателя на массив объектов класса Устройство
        {
            new Kettle("Swag", 200),         // инициализация объекта Чайник
            new Microwave("Samsung", 3000),  // инициализация объекта Микроволновка
            new Automobile("Audi", 380000),  // инициализация объекта Автомобиль
            new Ship("Titanic", 200000000)   // инициализация объекта Теплоход
        };

        foreach (Device item in devices)  // цикл по устройствам
        {
            Console.WriteLine(item);      // вывод в консоль метода ToString
            item.Description();           // вызов соответствующего переопредеоенного метода Описание
            item.Sound();                 // вызов соответствующего переопредеоенного метода Звук
            Console.WriteLine("-------------------");
        }
    }

    class Device  // базовый класс Устройство
    {
        protected string name { set; get; }  // название устройства
        protected double price { set; get; }  // цена устройства

        public Device (string name, double price)  // конструктор
        {
            this.name=name;
            this.price=price;
        }

        public virtual void Sound() { }  // виртуальный метод Звук
        public virtual void Description() { }  // виртуальный метод Описание
        public override string ToString()  // вирутуальный переопределенный метод ToString
        {
            return ($"\nУстройство {name}");
        }
    }

    class Kettle : Device  // класс Чайник, наследник Устройства
    {
        public Kettle(string name, double price)  // конструктор
            : base(name, price) { }

        public override void Sound()  // переопределенный метод Звук
        {
            Console.WriteLine("Чайник свистит.");
        }
        public override void Description()  // переопределенный метод Описание
        {
            Console.WriteLine($"Цена: {price}");
        }
        public override string ToString()  //  переопределенный метод ToString
        {
            return ($"\nЧайник {name}");
        }
    }

    class Microwave : Device  // класс Микроволновка, наследник Устройства
    {
        public Microwave(string name, double price)  // конструктор
            : base(name, price) { }
        public override void Sound()  // переопределенный метод Звук
        {
            Console.WriteLine("Микроволновка гудит");
        }
        public override void Description()  // переопределенный метод Описание
        {
            Console.WriteLine($"Цена: {price}");
        }
        public override string ToString()  //  переопределенный метод ToString
        {
            return ($"\nМикроволновка {name}");
        }
    }

    class Automobile : Device  // класс Автомобиль, наследник Устройства
    {
        public Automobile(string name, double price)  // конструктор
            : base(name, price) { }
        public override void Sound()  // переопределенный метод Звук
        {
            Console.WriteLine("Автомобиль заводится.");
        }
        public override void Description()  // переопределенный метод Описание
        {
            Console.WriteLine($"Цена: {price}");
        }
        public override string ToString()  //  переопределенный метод ToString
        {
            return ($"\nАвтомобиль {name}");
        }
    }

    class Ship : Device  // класс Теплоход, наследник Устройства
    {
        public Ship(string name, double price)  // конструктор
            : base(name, price) { }

        public override void Sound()  // переопределенный метод Звук
        {
            Console.WriteLine("Теплоход шуршит.");
        }
        public override void Description()  // переопределенный метод Описание
        {
            Console.WriteLine($"Цена: {price}");
        }
        public override string ToString()  //  переопределенный метод ToString
        {
            return ($"\nПароход {name}");
        }
    }
}