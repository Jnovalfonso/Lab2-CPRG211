using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Inheritance

{
    public class Salaried:Employee
    {
        public double salary {  get; set; }

        // Default Constructor
        public Salaried()
        {
            this.salary = 0.0;
        }

        // Defined Constructor
        public Salaried(double salary, string id, string name, string address, string sin, string phone, string dob, string dept) : base(id, name, address, sin, phone, dob, dept)
        {
            this.salary = salary;
        }

        public override double GetSalary()
        {
            return salary;
        }

        public override string ToString()
        {
            return base.ToString() +$"\nSalary {GetSalary()}";
        }
    }
}