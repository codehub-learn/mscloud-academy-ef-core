using System.Linq;
using CrmAzure.Data;
using Microsoft.EntityFrameworkCore;

// ReSharper disable All

namespace CrmAzure
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new CrmAzureDbContext())
            {
                // fetch customer with id 2
                var c = db
                    .Customer
                    .Where(c => c.Id == 2)
                    .Include(c => c.Orders)
                    .ThenInclude(o => o.Products)
                    .ThenInclude(p => p.Product)
                    .ToList();

            }
        }
    }
}
