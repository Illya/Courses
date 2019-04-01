using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    public /* static*/  class A
    {
        private int age;                       // Після оголошення класу А як статичний помилки при компіляції були такі : 
        protected string Name { get; set; }    // статичний клас не може мати protected членів, статичний клас не може мати 
                                               // екземплярів, статтичний клас не можна наслідувати, статичний клас може мати
        protected string SayHello()              // лише статичні поля, властивості та методи.
        {
            return ("Hello!");
        }

        //private A() { }                      // Після оголошення конструктор класу А як private, наслідування стало недоступним
    }                                          // через те, що конструктор недоступний у дочірньому класі.
                                               // Створення екземпляра класу також неможливе через рівень захищеності (private).
    public class B : A
    {
        public void ShowInfo()
        {
            Name = "Jack";
            SayHello();
            //age = 5; немає доступу тому, що поле оголошено як private, яке доступне лише в межах класу А
            Console.WriteLine("My name is "+ Name + " and I say: " + SayHello());
        }    
    }


    public class C
    {
        private readonly int val = 5;
        public C()
        {
            val = 1;
        }

        public int GetValue()
        {
            return val;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();

            //a.age = 10; 
            //a.name = "Ron";    Поля, методи та властивості недоступні через рівень захищеності, оскільки індентифікатор
            //a.SayHello();      protected дозволяє працювати в базовому класі, та у дочірніх класах

            B b = new B();
            b.ShowInfo();

            C c = new C();

            Cat cat = new Cat();
            cat.Move();
            cat.Eat();              // методи створені в різних "частинках" класу у файлах Cat1 та Сat2
            cat.SayMiaw();

            Console.WriteLine(c.GetValue()); // значення value буде рівне 1, оскільки readonly дозволяє задавати значення
            Console.ReadKey();               // при виконанні програми, а конструктор запускається тоді ж.
        }
    }
}
