using System;

namespace Inheritance

{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to this program!");

            List<Employee> employees = new List<Employee>();

            string[] employeeFile = File.ReadAllLines("..\\..\\..\\res\\employees.txt");
            foreach (string line in employeeFile)
            {
                string[] employeeData = line.Split(':');

                // If employee has a 'Salaried' Id:
                if (new char[] { '0', '1', '2', '3', '4' }.Contains(employeeData[0][0]))
                {
                    double salary = double.Parse(employeeData[7]);
                    employees.Add(new Salaried(employeeData[0], employeeData[1], employeeData[2], employeeData[3], employeeData[4], employeeData[5], employeeData[6], salary));
                }

                // Else if is a Wage employee:
                else if (new char[] { '5', '6', '7'}.Contains(employeeData[0][0]))
                {
                    double rate = double.Parse(employeeData[7]);
                    double hours = double.Parse(employeeData[8]);
                    employees.Add(new Wages(employeeData[0], employeeData[1], employeeData[2], employeeData[3], employeeData[4], employeeData[5], employeeData[6], rate, hours));
                }

                else if (new char[] { '8', '9' }.Contains(employeeData[0][0]))
                {
                    double rate = double.Parse(employeeData[7]);
                    double hours = double.Parse(employeeData[8]);
                    employees.Add(new PartTime(employeeData[0], employeeData[1], employeeData[2], employeeData[3], employeeData[4], employeeData[5], employeeData[6], rate, hours));
                }
            }


            double average = 0;
            Tuple<Wages, double> highWage = null;
            Tuple<Salaried, double> lowSalary = null;
            double amountWages = 0;
            double amountSalaried = 0;
            double amountPartTime = 0;


            foreach (Employee employee in employees)
            {
                // Calculate weekly pay average:
                average += employee.GetSalary();

                if (employee is Wages)
                {
                    // Add to amount of Wage employees
                    amountWages++;
                    // Highest pay for 'Wages' employees
                    if (highWage == null || employee.GetSalary() > highWage.Item2)
                    {
                        highWage = new Tuple<Wages, double>((Wages)employee, employee.GetSalary());
                    }

                }

                else if (employee is Salaried)
                {
                    // Add to amount of Salaried employees
                    amountSalaried++;
                    // Lowest pay for 'Salaried' employees
                    if (lowSalary == null || employee.GetSalary() < lowSalary.Item2)
                    {
                        lowSalary = new Tuple<Salaried, double>((Salaried)employee, employee.GetSalary());
                    }
                }
                else amountPartTime++;
            }


            // Print results to Console:

            Console.WriteLine($"The average weekly pay for all employees is: {average / employees.Count:F2}CAD");
            Console.WriteLine($"The highest paid 'Wages' employee is: {highWage.Item1.name} -> {highWage.Item2}CAD");
            Console.WriteLine($"The lowest paid 'Salaried' employee is: {lowSalary.Item1.name} -> {lowSalary.Item2}CAD");
            Console.WriteLine($"The percentage of 'Salaried' employees is: {amountSalaried / 11 * 100:F2}%\n" +
                $"The percentage of 'Wages' employees is: {amountWages / employees.Count * 100:F2}%\n" +
                $"The percentage of 'PartTime' employees is: {amountPartTime / employees.Count * 100:F2}%\n");
            

            // Write data in 'employees.txt.' - IF CURRENT PATH DOES NOT WORK USE '..\\employees.txt'

            using (StreamWriter sw = new StreamWriter("..\\..\\..\\res\\output.txt"))
            {
                sw.WriteLine($"The average weekly pay for all employees is: {average / employees.Count:F2}CAD");
                sw.WriteLine($"The highest paid 'Wages' employee is: {highWage.Item1.name} -> {highWage.Item2}CAD");
                sw.WriteLine($"The lowest paid 'Salaried' employee is: {lowSalary.Item1.name} -> {lowSalary.Item2}CAD");
                sw.WriteLine($"The percentage of 'Salaried' employees is: {amountSalaried / 11 * 100:F2}%\n" +
                    $"The percentage of 'Wages' employees is: {amountWages / employees.Count * 100:F2}%\n" +
                    $"The percentage of 'PartTime' employees is: {amountPartTime / employees.Count * 100:F2}%\n");
            }

            
        }
    }
}
