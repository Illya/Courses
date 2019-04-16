using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5.Practice5
{
    class Point
    {
        private int X { get; set; }
        private int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return string.Format("({0},{1}) ", this.X, this.Y);
        }
    }

    class PointsCollection // клас-обгортка для класу Point
    {
        public List<Point> points;

        public PointsCollection(List<Point> p)
        {
            points = p;
        }

        public static PointsCollection operator +(PointsCollection list1, PointsCollection list2) // перевантаження оператора +
        {
            list1.points.AddRange(list2.points);
            return new PointsCollection(list1.points);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(10, 20);
            Point p2 = new Point(8, 9);
            Point p3 = new Point(5, 15);

            List<Point> points1 = new List<Point>();
            points1.Add(p1);
            points1.Add(p2);
            points1.Add(p3);

            Point p4 = new Point(6, 20);
            Point p5 = new Point(11, 9);
            Point p6 = new Point(20, 15);

            List<Point> points2 = new List<Point>();
            points2.Add(p4);
            points2.Add(p5);
            points2.Add(p6);

            PointsCollection pointsCollection1 = new PointsCollection(points1);
            Console.Write("First collection : ");
            for (int i = 0; i < pointsCollection1.points.Count; i++)
            {
                Console.Write(pointsCollection1.points[i].ToString());
            }
            Console.WriteLine();
            PointsCollection pointsCollection2 = new PointsCollection(points2);
            Console.Write("Second collection : ");
            for (int i = 0; i < pointsCollection2.points.Count; i++)
            {
                Console.Write(pointsCollection2.points[i].ToString());
            }
            Console.WriteLine();
            PointsCollection pointsCollection3 = pointsCollection1 + pointsCollection2; // додавання двох колекцій

            Console.Write("Result collection : ");
            for (int i = 0; i < pointsCollection3.points.Count; i++)
            {
                Console.Write(pointsCollection3.points[i].ToString()); //вивід результату в консоль
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
