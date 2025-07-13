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

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller obj)
        {
            if (obj.BirthDate.Kind == DateTimeKind.Unspecified)
            {
                obj.BirthDate = DateTime.SpecifyKind(obj.BirthDate, DateTimeKind.Utc);
            }

            _context.Add(obj);
           await _context.SaveChangesAsync();
        }

        // FirstOrDefault allows to receive a LINQ function, but is more efficient use Firt when you search for a single atribute (id)
        // Use too for case when you want to return not found when is null ( Controller )
        public async Task<Seller> FindByIdAsync(int id)
        {
            //Also search for department
            //Only FirsOrDefault or Firs, search for a single object "Seller" without "Department" associate
            return await _context.Seller.Include(s => s.Department).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Seller.FindAsync(id);
            if (obj != null)
            {
                _context.Seller.Remove(obj);
               await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
               await _context.SaveChangesAsync();
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
