using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice6
{
    class Fraction
    {
        private double ch;
        private double zn;

        public Fraction(double ch, double zn)
        {
            this.ch = ch;
            this.zn = zn;
        }

        public static bool operator > (Fraction f1, Fraction f2) // перевантаження оператора >
        {
             double d1 = f1.ch / f1.zn;
             double d2 = f2.ch / f2.zn;
             return (d1 > d2);
        }

        public static bool operator < (Fraction f1, Fraction f2) // перевантаження оператора <
        {
            double d1 = f1.ch / f1.zn;
            double d2 = f2.ch / f2.zn;
            return (d1 < d2);
        }

        public static bool operator == (Fraction f1, Fraction f2) // перевантаження оператора ==
        {
            double d1 = f1.ch / f1.zn;
            double d2 = f2.ch / f2.zn;
            return (d1 == d2);
        }

        public static bool operator != (Fraction f1, Fraction f2) // перевантаження оператора !=
        {
            double d1 = f1.ch / f1.zn;
            double d2 = f2.ch / f2.zn;
            return (d1 != d2);
        }

        public override string ToString()
        {
            return string.Format("{0}/{1}", this.ch, this.zn);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Fraction f1 = new Fraction(1,2);
            Fraction f2 = new Fraction(1,3);

            Console.WriteLine("Is {0} > {1} ? {2}",f1,f2, f1 > f2);
            Console.WriteLine("Is {0} < {1} ? {2}", f1, f2, f1 < f2);
            Console.WriteLine("Is {0} == {1} ? {2}", f1, f2, f1 == f2);
            Console.WriteLine("Is {0} != {1} ? {2}", f1, f2, f1 != f2);
            Console.ReadKey();
        }
    }
}
