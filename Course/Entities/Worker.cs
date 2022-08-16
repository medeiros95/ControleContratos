using System;
using System.Collections.Generic;
using Course.Entities.Enums;

namespace Course.Entities
{
    internal class Worker
    {

        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public List<HourContract> Contratcs { get; set; } = new List<HourContract>();


        public Worker()
        {
        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddContract(HourContract contract)
        {
            Contratcs.Add(contract);
        }
        public void RemoveContract(HourContract contract)
        {
            Contratcs.Remove(contract);
        }

        public double Income (int year, int month)
        {
            double sum = BaseSalary;

            foreach (HourContract contract in Contratcs)
            {
                if (contract.Date.Year == year && contract.Date.Month == month)
                {
                    sum += contract.TotalValue();
                }
            }

            return sum;
        }


    }
}
