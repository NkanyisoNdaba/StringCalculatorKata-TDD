using System;
using System.Xml.Schema;

namespace StringCalclulatorTwo
{
    public class StringCalculator
    {
        private int _sum = 0;

        public int Add(string numbers)
        {
            if (numbers.StartsWith("//"))
            {
                numbers = numbers.Replace("//", "");
            }

            IfNumberIsNegative(numbers);

            var splitNumbers = numbers.Split(new[] { ",", "\n", ";" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var number in splitNumbers)
            {
                if (NumberIsGreaterThan1000(number))
                {
                    _sum += int.Parse(number);
                }
            }

            return _sum;
        }

        private static bool NumberIsGreaterThan1000(string number)
        {
            return int.Parse(number) <= 1000;
        }

        private static void IfNumberIsNegative(string numbers)
        {
            if (numbers.Contains("-"))
            {
                throw new Exception($"negatives not allowed {numbers}");
            }
        }
    }
}