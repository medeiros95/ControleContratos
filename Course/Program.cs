using System;
using System.Globalization;
using Course.Entities;
using Course.Entities.Enums;

namespace Course
{
    internal class Program
    {
        static void Main(string[] args)
        {

            
            Console.Write("Enter departament's name: ");
            string deptName = Console.ReadLine();

            Console.WriteLine("Enter worker data: ");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Level (Junior / MidLevel / Senior): ");
            WorkerLevel level = (WorkerLevel)Enum.Parse(typeof(WorkerLevel), Console.ReadLine());

            Console.Write("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            //Criacao do objeto Department
            Department dept = new Department(deptName);

            //Criacao do objeto Worker
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.Write("How many contracts to this worker?: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine();

            //Logica para leitura dos contratos
            for(int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} contract data:");
                Console.Write("Date (DD/MM/YYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Duraction (Hours): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, hours);

                worker.AddContract(contract);
            }
            Console.WriteLine();
            Console.WriteLine("Enter month and year to calculate income (MM/YY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine("Name: "+ worker.Name);
            Console.WriteLine("Department: "+ worker.Department.Name);
            Console.WriteLine("Income for "+ monthAndYear + ": "+ worker.Income(year,month).ToString("F2",CultureInfo.InvariantCulture));
        }
    }
}
