using System;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Models
{
    public class SalesRecord
    {

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public double Amount { get; set; }

        public SaleStatus Status { get; set; }

        public Seeler Seller { get; set; }

        public SalesRecord() { }

        public SalesRecord(int id, DateTime date, double amount, SaleStatus status, Seeler seller)
        {
            this.Id = id;
            this.Date = date;
            this.Amount = amount;
            this.Status = status;
            this.Seller = seller;

        }
    }
}