using Microsoft.EntityFrameworkCore;
using SistemaDeVendasWeb.Data;
using SistemaDeVendasWeb.Models;
namespace SistemaDeVendasWeb.Services
{
    public class DepartmentService
    {
        private readonly SistemaDeVendasWebContext _context;
        public DepartmentService(SistemaDeVendasWebContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
