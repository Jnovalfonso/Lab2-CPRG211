using System;

namespace Inheritance

{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to this program!");

            List<Employee> employees = new List<Employee>();

            // Creating instances for Salaried class
            employees.Add(new Salaried(680.70, "1-895", "Juan", "758 Sky Street", "789-456-123", "(555)-789-0123", "01/15/1980", "Software Development"));
            employees.Add(new Salaried(1060.80, "2-896", "Maria", "123 Main St", "123-456-789", "(555)-123-4567", "07/20/1985", "Management"));
            employees.Add(new Salaried(700.90, "3-897", "Carlos", "456 Oak Ave", "456-789-012", "(555)-234-5678", "12/05/1990", "Accounting"));
            employees.Add(new Salaried(910.90, "2-137", "Alex", "106 Palomino Ave", "416-719-113", "(555)-884-8672", "09/28/2000", "User Experience"));

            // Creating instances for Wages class
            employees.Add(new Wages(15.50, 42.5, "5-899", "Anna", "890 Pine Rd", "890-123-456", "(555)-345-6789", "03/10/1975", "Marketing"));
            employees.Add(new Wages(38.75, 38.0, "6-900", "Samuel", "567 Elm St", "567-890-123", "(555)-456-7890", "09/25/1988", "Research and Development"));
            employees.Add(new Wages(20.25, 45.5, "7-901", "Sophia", "234 Maple Dr", "234-567-890", "(555)-567-8901", "06/20/1995", "Human Resources"));
            employees.Add(new Wages(35.85, 42.0, "6-121", "Blanca", "884 Towne Dr", "774-967-893", "(555)-927-3451", "03/10/1981", "Accounting"));
            employees.Add(new Wages(14.75, 36.5, "9-904", "Olivia", "345 Pine Ave", "345-678-901", "(555)-890-1234", "02/25/1979", "Sales"));

            // Creating instances for PartTime class
            employees.Add(new PartTime(19.25, 25.5, "8-902", "Emily", "789 Birch Ln", "789-012-345", "(555)-678-9012", "11/30/1982", "Customer Support"));
            employees.Add(new PartTime(15.50, 30.0, "9-903", "Daniel", "901 Cedar Rd", "901-234-567", "(555)-789-0123", "04/12/1987", "Quality Assurance"));


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


            // Write data in 'employees.txt.'
            using (StreamWriter sw = new StreamWriter("..\\..\\..\\res\\employees.txt"))
            {
                sw.WriteLine($"The average weekly pay for all employees is: {average / employees.Count:F2}CAD");
                sw.WriteLine($"The highest paid 'Wages' employee is: {highWage.Item1.name} -> {highWage.Item2}CAD");
                sw.WriteLine($"The lowest paid 'Salaried' employee is: {lowSalary.Item1.name} -> {lowSalary.Item2}CAD");
                sw.WriteLine($"The percentage of 'Salaried' employees is: {amountSalaried / 11 * 100:F2}%\n" +
                    $"The percentage of 'Wages' employees is: {amountWages / employees.Count * 100:F2}%\n" +
                    $"The percentage of 'PartTime' employees is: {amountPartTime / employees.Count * 100:F2}%\n");
            }

            // Print results to Console:

            Console.WriteLine($"The average weekly pay for all employees is: {average / employees.Count:F2}CAD");
            Console.WriteLine($"The highest paid 'Wages' employee is: {highWage.Item1.name} -> {highWage.Item2}CAD");
            Console.WriteLine($"The lowest paid 'Salaried' employee is: {lowSalary.Item1.name} -> {lowSalary.Item2}CAD");
            Console.WriteLine($"The percentage of 'Salaried' employees is: {amountSalaried / 11 * 100:F2}%\n" +
                $"The percentage of 'Wages' employees is: {amountWages / employees.Count * 100:F2}%\n" +
                $"The percentage of 'PartTime' employees is: {amountPartTime / employees.Count * 100:F2}%\n");
        }
    }
}
