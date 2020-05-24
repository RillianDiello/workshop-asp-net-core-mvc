using System;
using System.Collections.Generic;
using System.Linq;
namespace SalesWebMvc.Models
{
    public class Department
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Seeler> Seelers { get; set; } = new List<Seeler>();

        public Department() { }

        public Department(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public void AddSeeler(Seeler sl)
        {
            Seelers.Add(sl);
        }

        public double TotalSales(DateTime inicial, DateTime final)
        {
            return Seelers.Sum(sl => sl.TotalSales(inicial,final));
        }
    }
}