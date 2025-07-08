using SistemaDeVendasWeb.Data;
using SistemaDeVendasWeb.Models;
using Microsoft.EntityFrameworkCore;
using SistemaDeVendasWeb.Services.Exceptions;

namespace SistemaDeVendasWeb.Services
{
    public class SellerService
    {
        private readonly SistemaDeVendasWebContext _context;
        public SellerService(SistemaDeVendasWebContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            if (obj.BirthDate.Kind == DateTimeKind.Unspecified)
            {
                obj.BirthDate = DateTime.SpecifyKind(obj.BirthDate, DateTimeKind.Utc);
            }

            _context.Add(obj);
            _context.SaveChanges();
        }

        // FirstOrDefault allows to receive a LINQ function, but is more efficient use Firt when you search for a single atribute (id)
        // Use too for case when you want to return not found when is null ( Controller )
        public Seller FindById(int id)
        {
            //Also search for department
            //Only FirsOrDefault or Firs, search for a single object "Seller" without "Department" associate
            return _context.Seller.Include(s => s.Department).FirstOrDefault(x => x.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            if (obj != null)
            {
                _context.Seller.Remove(obj);
                _context.SaveChanges();
            }
        }

        public void Update(Seller obj)
        {
            if(!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            //Catches a db level exception and throws it as service level
            // MVC model( Service, Repository and Entities ) -> Controller -> View
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
