using System;
using System.Collections.Generic;

namespace LabWork
{
    public class ZNO
    {
        public string Subject { get; set; }
        public int Points { get; set; }

        public ZNO()
        {
            Subject = "Unknown";
            Points = 0;
        }

        public ZNO(string subject, int points)
        {
            Subject = subject;
            Points = points;
        }

        public override string ToString()
        {
            return $"Subject: {Subject}, Points: {Points}";
        }
    }

    public class Entrant
    {
        public string FullName { get; set; }
        public string IdNum { get; set; }
        public double AvgPoints { get; set; }
        public bool IsAwarded { get; set; }
        public ZNO[] ZNOResults { get; set; }

        public double MonthlyFee { get; private set; }
        public double YearlyFee => MonthlyFee * 10;
        public double FullPeriodFee => MonthlyFee * 40;

        public Entrant()
        {
            FullName = "Unknown";
            IdNum = "000000";
            AvgPoints = 0.0;
            IsAwarded = false;
            ZNOResults = Array.Empty<ZNO>();
            MonthlyFee = 0.0;
        }

        public Entrant(string fullName, string idNum, double avgPoints, bool isAwarded, ZNO[] znoResults, double monthlyFee)
        {
            FullName = fullName;
            IdNum = idNum;
            AvgPoints = avgPoints;
            IsAwarded = isAwarded;
            ZNOResults = znoResults;
            MonthlyFee = monthlyFee;
        }

        public override string ToString()
        {
            return $"FullName: {FullName}, IdNum: {IdNum}, AvgPoints: {AvgPoints}, IsAwarded: {IsAwarded}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("=== Демонстрація роботи з List ===");

        
            List<string> stringList = new List<string> { "Apple", "Banana", "Cherry" };
            stringList.Add("Date");
            stringList.Remove("Banana");
            Console.WriteLine("Елементи List<string>: " + string.Join(", ", stringList));

            List<double> doubleList = new List<double> { 1.5, 2.3, 4.7 };
            doubleList.Add(3.8);
            doubleList.Remove(2.3);
            Console.WriteLine("Елементи List<double>: " + string.Join(", ", doubleList));

      
            List<int> intList = new List<int> { 10, 20, 30 };
            intList.Add(40);
            intList.Remove(20);
            Console.WriteLine("Елементи List<int>: " + string.Join(", ", intList));

            Console.WriteLine("Кількість елементів у List<int>: " + intList.Count);
            intList.Clear();
            Console.WriteLine("List<int> після очищення: " + intList.Count);

            Console.WriteLine("\n=== Демонстрація роботи з Dictionary ===");

            Dictionary<string, Entrant> entrants = new Dictionary<string, Entrant>();

            ZNO[] znoResults1 = new ZNO[]
            {
                new ZNO("Math", 180),
                new ZNO("English", 190)
            };
            Entrant entrant1 = new Entrant("Alice Brown", "12345", 4.8, true, znoResults1, 1000);

            ZNO[] znoResults2 = new ZNO[]
            {
                new ZNO("History", 170),
                new ZNO("Biology", 160)
            };
            Entrant entrant2 = new Entrant("Bob Smith", "67890", 4.2, false, znoResults2, 800);

            entrants.Add(entrant1.IdNum, entrant1);
            entrants.Add(entrant2.IdNum, entrant2);

            Console.WriteLine("Список абітурієнтів:");
            foreach (var entrant in entrants.Values)
            {
                Console.WriteLine(entrant);
            }

            Console.WriteLine("\nПошук абітурієнта за ID 12345:");
            if (entrants.TryGetValue("12345", out Entrant foundEntrant))
            {
                Console.WriteLine(foundEntrant);
            }
            else
            {
                Console.WriteLine("Абітурієнта не знайдено.");
            }

            Console.WriteLine("\nВидалення абітурієнта з ID 67890.");
            entrants.Remove("67890");

            Console.WriteLine("Кількість абітурієнтів у словнику: " + entrants.Count);

            
            entrants.Clear();
            Console.WriteLine("Словник після очищення: " + entrants.Count);

            Console.WriteLine("\nПрограма завершена.");
        }
    }
}
