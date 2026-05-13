using System;
using System.Collections.Generic;

namespace BehPatterns.Visitor
{
    // === Элементы (Employee - сотрудники) ===

    public interface IEmployee
    {
        string Name { get; }
        decimal BaseSalary { get; }
        void Accept(ISalaryVisitor visitor);
    }

    public class FullTimeEmployee : IEmployee
    {
        public string Name { get; }
        public decimal BaseSalary { get; }
        public int ExperienceYears { get; }

        public FullTimeEmployee(string name, decimal baseSalary, int experienceYears)
        {
            Name = name;
            BaseSalary = baseSalary;
            ExperienceYears = experienceYears;
        }

        public void Accept(ISalaryVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class ContractorEmployee : IEmployee
    {
        public string Name { get; }
        public decimal BaseSalary { get; } // Почасовая ставка
        public int HoursWorked { get; }

        public ContractorEmployee(string name, decimal hourlyRate, int hoursWorked)
        {
            Name = name;
            BaseSalary = hourlyRate;
            HoursWorked = hoursWorked;
        }

        public void Accept(ISalaryVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class InternEmployee : IEmployee
    {
        public string Name { get; }
        public decimal BaseSalary { get; }
        public string University { get; }

        public InternEmployee(string name, decimal stipend, string university)
        {
            Name = name;
            BaseSalary = stipend;
            University = university;
        }

        public void Accept(ISalaryVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    // === Посетители (ISalaryVisitor - интерфейс для расчетов) ===

    public interface ISalaryVisitor
    {
        void Visit(FullTimeEmployee employee);
        void Visit(ContractorEmployee employee);
        void Visit(InternEmployee employee);
    }

    // Расчет зарплаты к выплате
    public class NetSalaryVisitor : ISalaryVisitor
    {
        public decimal TotalNetSalary { get; private set; }

        public void Visit(FullTimeEmployee employee)
        {
            // Штатный: базовая ставка + надбавка за стаж - налоги
            decimal bonus = employee.BaseSalary * 0.1m * employee.ExperienceYears;
            decimal gross = employee.BaseSalary + bonus;
            decimal tax = gross * 0.13m; // НДФЛ 13%
            decimal net = gross - tax;
            TotalNetSalary += net;
            Console.WriteLine($"{employee.Name}: Gross={gross:C}, Tax={tax:C}, Net={net:C}");
        }

        public void Visit(ContractorEmployee employee)
        {
            // Подрядчик: почасовая оплата без бонусов, но с налогами как самозанятый
            decimal gross = employee.BaseSalary * employee.HoursWorked;
            decimal tax = gross * 0.06m; // НПД 6%
            decimal net = gross - tax;
            TotalNetSalary += net;
            Console.WriteLine($"{employee.Name}: Hours={employee.HoursWorked}, Gross={gross:C}, Tax={tax:C}, Net={net:C}");
        }

        public void Visit(InternEmployee employee)
        {
            // Стажер: стипендия без налогов (или с минимальным)
            decimal tax = employee.BaseSalary * 0m;
            decimal net = employee.BaseSalary - tax;
            TotalNetSalary += net;
            Console.WriteLine($"{employee.Name} ({employee.University}): Net={net:C} (без налога)");
        }
    }

    // Расчет налогов для бухгалтерии
    public class TaxVisitor : ISalaryVisitor
    {
        public decimal TotalTax { get; private set; }

        public void Visit(FullTimeEmployee employee)
        {
            decimal bonus = employee.BaseSalary * 0.1m * employee.ExperienceYears;
            decimal gross = employee.BaseSalary + bonus;
            decimal ndfl = gross * 0.13m;
            decimal social = gross * 0.30m; // Социальные взносы
            TotalTax += ndfl + social;
            Console.WriteLine($"{employee.Name}: НДФЛ={ndfl:C}, Соцвзносы={social:C}");
        }

        public void Visit(ContractorEmployee employee)
        {
            decimal gross = employee.BaseSalary * employee.HoursWorked;
            decimal npd = gross * 0.06m; // Самозанятый
            TotalTax += npd;
            Console.WriteLine($"{employee.Name}: НПД={npd:C}");
        }

        public void Visit(InternEmployee employee)
        {
            // Стажеры обычно не облагаются или облагаются минимально
            Console.WriteLine($"{employee.Name}: Налог=0 (стипендия)");
        }
    }

    // Генерация отчета для HR
    public class HrReportVisitor : ISalaryVisitor
    {
        public void Visit(FullTimeEmployee employee)
        {
            decimal bonus = employee.BaseSalary * 0.1m * employee.ExperienceYears;
            Console.WriteLine($"[HR] {employee.Name}: Штатный сотрудник, стаж {employee.ExperienceYears} лет, бонус {bonus:C}");
        }

        public void Visit(ContractorEmployee employee)
        {
            Console.WriteLine($"[HR] {employee.Name}: Подрядчик, отработано {employee.HoursWorked} часов");
        }

        public void Visit(InternEmployee employee)
        {
            Console.WriteLine($"[HR] {employee.Name}: Стажер, {employee.University}");
        }
    }

    // === Клиентский код ===

    public class SalaryCalculator
    {
        public void CalculateAll(IEnumerable<IEmployee> employees)
        {
            var netVisitor = new NetSalaryVisitor();
            var taxVisitor = new TaxVisitor();
            var hrVisitor = new HrReportVisitor();

            Console.WriteLine("=== Расчет зарплаты ===");
            foreach (var employee in employees)
            {
                employee.Accept(netVisitor);
            }
            Console.WriteLine($"Итого к выплате: {netVisitor.TotalNetSalary:C}");

            Console.WriteLine("\n=== Расчет налогов ===");
            foreach (var employee in employees)
            {
                employee.Accept(taxVisitor);
            }
            Console.WriteLine($"Итого налогов: {taxVisitor.TotalTax:C}");

            Console.WriteLine("\n=== HR отчет ===");
            foreach (var employee in employees)
            {
                employee.Accept(hrVisitor);
            }
        }
    }
}