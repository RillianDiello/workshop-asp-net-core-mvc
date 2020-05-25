using System.Collections.Generic;
using System.Linq;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context){
            _context = context;
        }

        public List<Seeler> FindAll(){
            return _context.Seeler.ToList();
        }

        public void Insert(Seeler obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}