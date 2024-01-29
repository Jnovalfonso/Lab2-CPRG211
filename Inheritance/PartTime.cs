using System;

namespace Inheritance

{
    public class PartTime : Employee
    {
        public double rate { get; set; }
        public double hours { get; set; }

        // Default Constructor
        public PartTime()
        {
            this.rate = 15;
            this.hours = 20;
        }

        // Defined Constructor
        public PartTime(string id, string name, string address, string sin, string phone, string dob, string dept, double rate, double hours) : base(id, name, address, sin, phone, dob, dept)
        {
            this.rate = rate;
            this.hours = hours;
        }

        public override double GetSalary()
        {
            if (!(this.hours > 20))
            {
                return hours * rate;            
            }

            else
            {
                return 20 * rate;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"\nHours Worked: {hours}" +$"\nHourly Rate: {rate}" + $"\nSalary {GetSalary()}";
        }
    }
}
