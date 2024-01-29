using System;

namespace Inheritance

{
    public class Wages : Employee
    {
        public double rate { get; set; }
        public double hours { get; set; }

        // Default Constructor
        public Wages()
        {
            this.rate = 15;
        }

        // Defined Constructor
        public Wages(string id, string name, string address, string sin, string phone, string dob, string dept, double rate, double hours) : base(id, name, address, sin, phone, dob, dept)
        {
            this.rate = rate;
            this.hours = hours;
        }
        public override double GetSalary()
        {
            if (this.hours > 40)
            {
                double total = 40 * rate;
                total += (this.rate * 1.5) * (hours - 40);
                return total;
            }

            else
            {
                return hours * rate;
            }

            
        }

        public override string ToString()
        {
            return base.ToString() + $"\nHours Worked: {hours}" + $"\nHourly Rate: {rate}" + $"\nSalary {GetSalary()}";
        }
    }
}