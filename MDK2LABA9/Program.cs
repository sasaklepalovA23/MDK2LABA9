using System;

namespace MDK2LABA9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ИНТЕГРАЦИОННОЕ ТЕСТИРОВАНИЕ СИСТЕМЫ ФУНКЦИЙ ===\n");

           
            double[] testValues = { -1.0, -0.5, 0.0, 1.0, 5.0, 10.0 };

            Console.WriteLine("X\t\t| Результат F(x)");
            Console.WriteLine("------------------------------------------");

            foreach (double x in testValues)
            {
                try
                {
                    double result = CalculateSystem(x);
                    Console.WriteLine($"{x}\t\t| {Math.Round(result, 6)}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{x}\t\t| Ошибка: {ex.Message}");
                }
            }

            Console.ReadKey();
        }

        

        public static double Tan(double x) => Math.Tan(x);
        public static double Cos(double x) => Math.Cos(x);
        public static double Sin(double x) => Math.Sin(x);

        
        public static double Csc(double x)
        {
            double s = Sin(x);
            if (s == 0) throw new Exception("csc(x): деление на ноль (sin=0)");
            return 1.0 / s;
        }

     
        public static double Cot(double x)
        {
            double t = Tan(x);
            if (t == 0) throw new Exception("cot(x): деление на ноль (tan=0)");
            return 1.0 / t;
        }

       
        public static double LogN(double x, double n)
        {
            if (x <= 0) throw new Exception($"log{n}(x): x должен быть > 0");
            return Math.Log(x) / Math.Log(n);
        }


        public static double FunctionForNegative(double x)
        {
            double part1 = Tan(x) * Cos(x);
            double part2 = Math.Pow(Csc(x) - Cos(x), 2);

            double numerator = Math.Pow(part1 - part2, 2);
            double denominator = Cot(x);

            if (denominator == 0) throw new Exception("Деление на ноль в основной формуле");

            return Math.Pow(numerator / denominator, 2);
        }

        public static double FunctionForPositive(double x)
        {
        
            double logSum = LogN(x, 3) + LogN(x, 2);
            double log5Cubed = Math.Pow(LogN(x, 5), 3);
            double mainPart = logSum / log5Cubed;

            double numerator = mainPart + LogN(x, 10) + LogN(x, 10);

            double denominator = LogN(x, 5) - LogN(x, 8);

            if (denominator == 0) throw new Exception("Деление на ноль в логарифмах");

            return numerator / denominator;
        }

        public static double CalculateSystem(double x)
        {
            if (x <= 0)
                return FunctionForNegative(x);
            else
                return FunctionForPositive(x);
        }
    }
}