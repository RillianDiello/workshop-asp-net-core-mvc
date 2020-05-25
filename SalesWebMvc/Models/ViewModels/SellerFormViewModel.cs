using System;
using System.Collections.Generic;

namespace SalesWebMvc.Models.ViewModels
{
    public class SellerFormViewModel
    {
        public Seeler Seeler { get; set; }
        public ICollection<Department> Departments { get; set; }

       
    }
}
