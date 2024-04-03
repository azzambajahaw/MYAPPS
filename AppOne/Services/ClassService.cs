using Microsoft.EntityFrameworkCore;

namespace AppOne.Services
{
    public class ClassService : IClassService
    {
        private readonly AppDbContext _context;
        public ClassService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Class> Add(Class clas)
        {
            await _context.Classs.AddAsync(clas);
            _context.SaveChanges();
            return (clas);
        }

        public Class Delate(Class clas)
        {
            _context.Remove(clas);
            _context.SaveChanges();
            return (clas);
        }



        public async Task<IEnumerable<Class>> GetAll()
        {
            return await _context.Classs.ToListAsync();

        }

        public async Task<Class> GetById(int id)
        {
            return await _context.Classs.SingleOrDefaultAsync(x => x.id == id);

        }


        public Class Update(Class clas)
        {
            _context.Update(clas);
            _context.SaveChanges();
            return (clas);
        }

        public async Task<bool> IsValidClass(int id)
        {
            return await _context.Classs.AnyAsync(x => x.id == id);
  
        }

    }
}
