using System;
using System.Collections.Generic;
using SalesWebMvc.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Services
{
    public class SalesRecordService
    {
        private readonly SalesWebMvcContext _context;

        public SalesRecordService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {

            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            return await result.Include(x => x.Seller)
            .Include(x => x.Seller.Department)
            .OrderByDescending(x => x.Date)
            .ToListAsync();
        }

        /// <summary>
        /// Metodo que faz uma busca agrupada. Uma busca agrupada retorna um IGrouping pelo agrupamento com o os Dados
        /// Ou seja estamos fazendo um agrupamento de Departments, retornando suas vendas
        /// </summary>
        /// <param name="minDate"></param>
        /// <param name="maxDate"></param>
        /// <returns></returns>
        public async Task<List<IGrouping<Department, SalesRecord>>> FindByDateGrouping(DateTime? minDate, DateTime? maxDate)
        {

            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            return await result.Include(x => x.Seller)
            .Include(x => x.Seller.Department)
            .OrderByDescending(x => x.Date)
            .GroupBy(x => x.Seller.Department)
            .ToListAsync();
        }
    }
}