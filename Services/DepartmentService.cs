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

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
