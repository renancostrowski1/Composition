using System;
using System.Globalization;
using Composition.Entities;
using Composition.Entities.Enums;
namespace Composition
{
    class Program
    {
        static void Main(string[] args)
        {
            // User interaction
            Console.Write("Enter department's name: ");
            string dptName = Console.ReadLine();
            Console.WriteLine("Enter worker data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = (WorkerLevel)Enum.Parse(typeof(WorkerLevel), Console.ReadLine());
            Console.Write("Base salary: ");
            double basesalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine();

            // Instantiating Department and Worker
            Department dpt = new Department(dptName);
            Worker worker = new Worker(name, level, basesalary, dpt);

            //Number of contracts
            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            // reading contracts
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Enter #" + i + " contract data: ");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuehour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuehour, hours);
                worker.AddContract(contract);
            }
            Console.WriteLine();

            // Month and year to be calculated income
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            Console.WriteLine();
            DateTime dateincome = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);

            string datein = dateincome.ToShortDateString();
            Console.WriteLine($"Income for {datein}: " + worker.Income(dateincome.Year, dateincome.Month).ToString("F2",CultureInfo.InvariantCulture));

        }
    }
}
