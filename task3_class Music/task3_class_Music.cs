namespace task3_class_Music;

// Задание 3
// Создать базовый класс «Музыкальный инструмент» 
// и производные классы «Скрипка», «Тромбон», «Укулеле», 
// «Виолончель». С помощью конструктора установить имя
// каждого музыкального инструмента и его характеристики.
// Реализуйте для каждого из классов методы:
// ■ Sound — издает звук музыкального инструмента
// (пишем текстом в консоль);
// ■ Show — отображает название музыкального инструмента;
// ■ Desc — отображает описание музыкального инструмента;
// ■ History — отображает историю создания музыкального инструмента.

internal class task3_class_Music
{
    static void Main(string[] args)
    {
        // инициализация массива инструментов объектами классов-наслеников
        Music[] instruments =
        {
            new Violin("Скрипка","Strunal/Cremona 160 4/4"),
            new Trombone("Тромбон","Conn 36H тромбон-альт 'Eb'"),
            new Ukulele("Укулеле","Kala MK-B Makala Baritone Ukulele"),
            new Cello("Виолончель","YAMAHA SVC210 SILENT Cello")
        };
        foreach (var item in instruments)
        {
            item.Show();  // вызов соотетсвующего перелпределенного метода Вывод в консоль
        }
    }

    class Music  // базовый класс Музыкальный инструмент
    {
        protected string name;  // поле имя иснтурмента
        public string Name  
        {
            get { return name; }
            set { if (name != "") name = value;}
        }
        protected string title;  // поле название инструмента
        public string Title
        {
            get { return title; }
            set { if (title != "") title = value; }
        }

        public Music(string name, string title)  // конструктор
        {
            Name=name;
            Title=title;
        }

        public virtual void Show()  // виртуальный метод для вывода в консоль
        {
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine($"Музыкальный инструмент: {name}, название: {title}");
            Console.ForegroundColor = ConsoleColor.Green;
            Desc();  // вызов метода Описание
            Console.ForegroundColor = ConsoleColor.White;          
            Console.ForegroundColor = ConsoleColor.Blue;
            History();  // вызов метода История
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Sound();  // вызов метода Звук
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-------------------------------------------------------");
        }

        public virtual void Sound()  // виртуальный метод Звук
        {
            Console.WriteLine("Звук инструмента:");
        }
        public virtual void Desc()  // виртуальный метод Описание
        {
            Console.WriteLine("Описание инструмента:");
        }
        public virtual void History()  // виртуальный метод История
        {
            Console.WriteLine("История:");
        }
    }

    class Violin : Music  // класс Скрипка, наследник
    {
        public Violin(string name, string title) : base(name, title) { }  // конструктор
        public override void Desc()  // переопределение метода Описание
        {
            base.Desc();
            Console.WriteLine("Cмычковый музыкальный инструмент с четырьмя струнами.");
        }
        public override void History()  // переопределение метода История
        {
            base.History();
            Console.WriteLine("Скрипка стала результатом дальнейшего развития " +
                "\nтаких инструментов как фидель (виела), лира да браччо и ребек." +
                "\nИсследования 1970-х годов показали историческую связь скрипки с " +
                "\nнародными струнно-смычковыми музыкальными инструментами славян");
        }
        public override void Sound()  // переопределение метода Звук
        {
            base.Sound();
            Console.WriteLine("Звук скрипки");
        }
        public override void Show()  // переопределение метода Вывод в консоль
        {
            base.Show();
        }       
    }

    class Trombone : Music  // класс Тромбон, наследник
    {
        public Trombone(string name, string title) : base(name, title) { }
        public override void Desc()  // переопределение метода Описание
        {
            base.Desc();
            Console.WriteLine("Европейский духовой амбушюрный инструмент.");
        }
        public override void History()  // переопределение метода История
        {
            base.History();
            Console.WriteLine("Появление тромбона относится к XV веку. " +
                "\nПринято считать, что непосредственными предшественниками этого " +
                "\nинструмента были кулисные трубы, при игре на которых у музыканта " +
                "\nбыла возможность передвигать трубку инструмента, таким образом " +
                "\nполучая хроматический звукоряд.");
        }
        public override void Sound()  // переопределение метода Звук
        {
            base.Sound();
            Console.WriteLine("Звук тромбона");
        }
        public override void Show()  // переопределение метода Вывод в консоль
        {
            base.Show();
        }
    }

    class Ukulele : Music  // класс Укулеле, наследник
    {
        public Ukulele(string name, string title) : base(name, title) { }
        public override void Desc()  // переопределение метода Описание
        {
            base.Desc();
            Console.WriteLine("Гавайская четырёхструнная разновидность гитары.");
        }
        public override void History()  // переопределение метода История
        {
            base.History();
            Console.WriteLine("Укулеле появилась на Гавайских островах во второй " +
                "\nполовине XIX века, куда её, под названием машети да браса " +
                "\n(порт. machete da braça), завезли португальцы с острова Мадейра.");
        }
        public override void Sound()  // переопределение метода Звук
        {
            base.Sound();
            Console.WriteLine("Звук укулеле");
        }
        public override void Show()  // переопределение метода Вывод в консоль
        {
            base.Show();
        }
    }

    class Cello : Music  // класс Виолончель, наследник
    {
        public Cello(string name, string title) : base(name, title) { }      
        public override void Desc()  // переопределение метода Описание
        {
            base.Desc();
            Console.WriteLine("Смычковый музыкальный инструмент с 4-мя струнами.");
        }
        public override void History()  // переопределение метода История
        {
            base.History();
            Console.WriteLine("Появление виолончели относится к началу XVI века. " +
                "\nПервоначально она применялась как басовый инструмент для " +
                "\nсопровождения пения или исполнения на инструменте более высокого " +
                "\nрегистра.");
        }
        public override void Sound()  // переопределение метода Звук
        {
            base.Sound();
            Console.WriteLine("Звук виолончели");
        }
        public override void Show()  // переопределение метода Вывод в консоль
        {
            base.Show();
        }
    }
}