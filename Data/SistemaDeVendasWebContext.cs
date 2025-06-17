using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaDeVendasWeb.Models;

namespace SistemaDeVendasWeb.Data
{
    public class SistemaDeVendasWebContext : DbContext
    {
        public SistemaDeVendasWebContext (DbContextOptions<SistemaDeVendasWebContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; } = default!;
        public DbSet<Seller> Seller { get; set; } = default!;
        public DbSet<SalesRecord> SalesRecord { get; set; } = default!;

    }
}
