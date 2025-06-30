using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace laba_9
{
    public class Triangle
    {
        public double SideA { get; private set; }
        public double SideB { get; private set; }
        public double SideC { get; private set; }

        public Triangle(double a, double b, double c)
        {
            SideA = a;
            SideB = b;
            SideC = c;
        }

        // Проверка существования треугольника
        public static bool Exist(double a, double b, double c)
        {
            return a + b > c && a + c > b && b + c > a;
        }

        // Явное преобразование в bool
        public static explicit operator bool(Triangle t)
        {
            return Exist(t.SideA, t.SideB, t.SideC);
        }

        // Неявное преобразование в double (периметр)
        public static implicit operator double(Triangle t)
        {
            return t.SideA + t.SideB + t.SideC;
        }

        // Унарный оператор ! (площадь)
        public static double operator !(Triangle t)
        {
            double p = (t.SideA + t.SideB + t.SideC) / 2;
            return Math.Sqrt(p * (p - t.SideA) * (p - t.SideB) * (p - t.SideC));
        }

        // Унарный оператор ++ (увеличивает стороны в 2 раза)
        public static Triangle operator ++(Triangle t)
        {
            return new Triangle(t.SideA * 2, t.SideB * 2, t.SideC * 2);
        }

        // Унарный оператор -- (уменьшает стороны в 2 раза)
        public static Triangle operator --(Triangle t)
        {
            return new Triangle(t.SideA / 2, t.SideB / 2, t.SideC / 2);
        }
        public static string CompareAreas(Triangle t1, Triangle t2)
        {
            if (!(bool)t1 || !(bool)t2)
                return "Один из треугольников не существует";

            double area1 = !t1;
            double area2 = !t2;

            if (Math.Abs(area1 - area2) < 0.001)
                return $"Площади равны ({area1:F2})";

            return area1 > area2
                ? $"Первый треугольник больше ({area1:F2} > {area2:F2})"
                : $"Второй треугольник больше ({area2:F2} > {area1:F2})";
        }
    }
}
