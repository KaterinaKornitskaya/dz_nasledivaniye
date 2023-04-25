namespace task4_class_Worker;

// Задание 4
// Создать абстрактный базовый класс Worker(работника) с методом 
// Print(). Создайте четыре производных класса: 
// President, Security, Manager, Engineer. Переопределите метод
// Print() для вывода информации, соответствующей
// каждому типу работника.

internal class task4_class_Worker
{
    static void Main(string[] args)
    {
        // создание и инициализация объектов классов-наследников
        President work1 = new President("John", "Preston", new DateTime(1985,12,25), 5000.0);
        Security work2 = new Security("Dave", "Wind", new DateTime(1975, 3, 12), 1500.0);
        Manager work3 = new Manager("Kris", "Laynord", new DateTime(1994, 9, 1), 2000.0);
        Engineer work4 = new Engineer("Devid", "Norton", new DateTime(1990, 12, 5), 3000.0);

        // создание указателя на массив и инициализация ее объектами
        Worker[] workers = { work1, work2, work3, work4 };
        foreach (Worker item in workers)
        {
            item.Print();  // вызов соответствующего переопределенного метода Print()
        }
    }

    abstract class Worker  // абстрактный класс Работник
    {
        protected string first_name;    // поле имя
        protected string second_name;   // поле фамилия
        protected DateTime birth_date;  // поле дата рождения
        protected double salary;        // поле зарплата

        public Worker(string first_name, string second_name, DateTime birth_date, double salary)  // конструктор
        {
            this.first_name=first_name;
            this.second_name=second_name;
            this.birth_date=birth_date;
            this.salary=salary;
        }

        public virtual void Print()  // виртуальный метод для вывода в консоль
        {
            Console.WriteLine($"Имя: \t\t{first_name}" +
                $"\nФамилия: \t{second_name}" +
                $"\nДата рождения: \t{birth_date.ToLongDateString()}" +
                $"\nЗарплата: \t{salary}" +
                $"\n-------------------------------");
        }
    }

    class President : Worker  // класс Президент, наследник 
    {
        public President(string first_name, string second_name, DateTime birth_date, double salary) 
            : base(first_name, second_name, birth_date, salary) { }  // конструктор

        public override void Print()  // переопределенный метод для вывода в консоль
        {
            Console.WriteLine("Президент");
            base.Print();
        }
    }

    class Security : Worker  // класс Охрана, наследник 
    {
        public Security(string first_name, string second_name, DateTime birth_date, double salary)
            : base(first_name, second_name, birth_date, salary) { }  // конструктор

        public override void Print()  // переопределенный метод для вывода в консоль
        {
            Console.WriteLine("Охрана");
            base.Print();
        }
    }

    class Manager : Worker  // класс Менеджер, наследник
    {
        public Manager(string first_name, string second_name, DateTime birth_date, double salary)
            : base(first_name, second_name, birth_date, salary) { }  // конструктор

        public override void Print()  // переопределенный метод для вывода в консоль
        {
            Console.WriteLine("Менеджер");
            base.Print();
        }
    }

    class Engineer : Worker  // класс Инженер, наследник
    {
        public Engineer(string first_name, string second_name, DateTime birth_date, double salary)
            : base(first_name, second_name, birth_date, salary) { }  // конструктор

        public override void Print()  // переопределенный метод для вывода в консоль
        {
            Console.WriteLine("Инженер");
            base.Print();
        }
    }
}