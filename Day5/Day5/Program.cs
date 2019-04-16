using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    delegate void ShowMessage(string message);
    delegate bool Check();

    class Program
    {
        
        public enum Days
        {
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday
        }

        [Flags]
        public enum Months 
        {  
            January = 1,
            February = 2,
            March = 4,
            April = 8,
            May = 16,
            June = 32,
            July = 64,
            August = 128,
            September = 256,
            October = 512,
            November = 1024,
            December = 2048
        }

        public static void DisplayDays(Days day) //Функція, яка приймає параметром перечислення і виводить значення на консоль
        {
            Console.WriteLine(day);
        }

        public static void DisplayMonth(Months month) // Функція, яка приймає параметром бітовий прапорець і виводить значення на консоль
        {
            Console.WriteLine(month);
        }

        public static bool Check(Enum all_identifiers, Enum identifier) // Функція для перевірки входження бітового прапорця у послідовності бітових прапорців
        {
            return all_identifiers.HasFlag(identifier);
        }

        public static void Display(string message)
        {
            Console.WriteLine(message);
        }

        public static bool CheckDel()
        {
            Random rand = new Random();
            bool b = false;
            int tmp = rand.Next(0, 2);
            if (tmp == 0)
            {
                b = false;
            }
            else if (tmp == 1)
            {
                b = true;
            }

            return b;
        }

        public static void DelegateFun(ShowMessage _delMessage, Check _delCheck) // Функція для роботи з делегатами
        {
            if (_delCheck() == true)
            {
                _delMessage("It's true!");
            }
            else
            {
                _delMessage("It's false(");
            }
        }

        static void Main(string[] args)
        {
            Days day = Days.Friday;
            DisplayDays(day);
            Months months = Months.December | Months.February | Months.January;
            DisplayMonth(months);
            Console.WriteLine("Is {2} include {1} ? {0}",Check(months, Months.December), Months.December, months);

            DelegateFun(Display,CheckDel);
            
            Console.ReadKey();
           
        }
    }
}
