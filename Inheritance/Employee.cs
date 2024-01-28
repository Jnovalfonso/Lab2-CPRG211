using System;

namespace Inheritance

{
    public class Employee
    {
        public string id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string sin { get; set; }
        public string phone { get; set; }
        public string dob { get; set; }
        public string dept { get; set; }



        // Default Constructor
        public Employee()
        {
            this.id = "0-000";
            this.name = "Employee";
            this.address = "000 Street Name";
            this.sin = "000-000-000";
            this.phone = "(000)-000-0000";
            this.dob = "01/01/2000";
            this.dept = "Unassigned Department";
        }

        // Defined Constructor
        public Employee(string id, string name, string address, string sin, string phone, string dob, string dept)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.sin = sin;
            this.phone = phone;
            this.dob = dob;
            this.dept = dept;

        }

        // Get Salary Method

        public virtual double  GetSalary()
        {
            return 0.0;
        }

        // To String Method

        public override string ToString()
        {
            return $"Employee ID: {id}\n" +
                $"Name: {name}\n" +
                $"Address: {address}\n" +
                $"SIN: {sin}\n" +
                $"Phone Number: {phone}\n" +
                $"Date of Birth: {dob}\n" +
                $"Department {dept}";
        }
    }
}