using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Day4
{
    class A
    {
        public int prop { private get; set; } // 1. Рівень захищеності аксесорів має бути вищий, ніж самої властивості, рівень доступу
        public static int value;              // може бути вказаний лише для одного з аксесорів.
        private readonly int x;
        public int X
        {
            get { return x; }

            set {/* x = value */} // 5. Полю з модифікатором readonly значення можна задавати лише в конструкторі або при оголошенні
        }
    }

    class MyArray
    {
        private int[] array;

        public MyArray(int size)
        {
            array = new int[size];
        }

        public int Size
        {
            get { return array.Length; }
        }

        //6. Створення індексатора
        public int this[int asize]
        {
            get { return array[asize]; }    
            set { array[asize] = value; }
        }

        //7. Створення методу зі змінною кількістю параметрів)
        public static void Params(params int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

    }



    class Program
    {
        static void Main(string[] args)
        {

            int i = 5;
            switch (i)
            {
                case 1:
                case 5:
                    i++;                  // 2. Результатом даної частини коду буде: і = 6, оскільки case 1 виконує те ж саме, що і case 5
                    break;
                default: break;
            }

            //int о = 5;
            //switch (i)
            //{
            //    case 1: Console.WriteLine("Case 1"); // break statement is missing    //ця частина коду не скомпілюється, тому, що    
            //    case 5:                              // пропущений "break".
            //        о++;
            //        break;
            //    default: break;
            //}
            A a = new A();
           
            Funcion(ref A.value);  //3. Статичне поле можна передавати за посиланням як параметр у метод, оскільки модифікатор доступа - public
            //Funcion(ref a.x);      //4. private readonly поле не можемо передати в метод, оскільки модифікатор доступа - private                  
            a.X = 10; // не спрацює

            //Робота з індексатором
            MyArray arr = new MyArray(10);
            for (i = 0; i < arr.Size; i++)
            {
                arr[i] = i + 1;
            }
            Console.WriteLine("Workink with indexers :");
            for (i = 0; i < arr.Size; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
            ////////////////////////////////////
            Console.WriteLine("Working with property for readonly field : ");
            Console.WriteLine(a.X); // виведе 0, оскільки значення не задане

            //Демонстрація роботи метода з різною кількістю параметрів
            Console.WriteLine("Using method with variable amount of parameters :");
            MyArray.Params(1,3,7,8,10,13);
            int[] list = new int[] {23, 11, 4, 99};  
            MyArray.Params(list);
            ////////////////////////////////////////////////
            
            // Перевірка на швидкість конструкцій if else, switch, ?:
            Stopwatch stopwatch = new Stopwatch();
            string text = null;

            stopwatch.Start();
            if (i != 5)
            {
               text = "False!";
            }
            else
            {
                text = "True!";
            }
            stopwatch.Stop();
            TimeSpan ts1 = stopwatch.Elapsed;

            stopwatch = new Stopwatch();
            
            stopwatch.Start();
            switch (i)
            {
                case 1: text = "False!"; break;
                case 5: text = "True!"; break;
                default: break;
            }
            stopwatch.Stop();
            TimeSpan ts2 = stopwatch.Elapsed;

            stopwatch = new Stopwatch();
            
            stopwatch.Start();
            text = (i != 5) ? "False!" : "True!";
            stopwatch.Stop();
            TimeSpan ts3 = stopwatch.Elapsed;

            Console.WriteLine("if else : {0}, switch : {1}, (?:) : {2}",ts1.Ticks,ts2.Ticks,ts3.Ticks); //8. Після перевірки, виявилося,
                                   // що if else виконується найдовше, а тернарний оператор ?: виконується найшвидше (хоча і приблизно
            /////////////////////     однаково зі swith) 
            Console.WriteLine();
            Console.ReadKey();   
        }

        static void Funcion(ref int x) // функція з параметром за посиланням
        {
            x++;
        }
    }
}
