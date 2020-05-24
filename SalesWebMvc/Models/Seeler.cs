using System.Collections.Generic;
using System;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seeler
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public double BaseSalary { get; set; }


        public DateTime BirthDay { get; set; }

        public Department Department { get; set; }

        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seeler() { }

        public Seeler(int id, string name, string email, double baseSalary, DateTime birthDay, Department department)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.BaseSalary = baseSalary;
            this.BirthDay = birthDay;
            this.Department = department;

        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime inicial, DateTime final)
        {
            return Sales.Where(s => s.Date >= inicial && s.Date <= final).Sum(s => s.Amount);
        }

    }
}