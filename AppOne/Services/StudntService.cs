using Microsoft.EntityFrameworkCore;

namespace AppOne.Services
{
    public class StudntService : IStudntService
    {
        //private readonly IStudntService _studntService;
        //public StudntService(StudntService studntService)
        //{
        //    _studntService = studntService; 
        //}

        private readonly AppDbContext _context;
        public StudntService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Studnt>> GetAll()
        {
            //return (IEnumerable<Studnt>)await _context.Studnts
            //.OrderByDescending(s => s.Class)
            //.Include(x => x.Class)
            //.Select(m => new StudentDetailsDto
            //{
            //    Id = m.Id,
            //    classid = m.Classid,
            //    name = m.Name,
            //    age = m.age,
            //    ClassName = m.Class.name
            //})
            //.ToListAsync();
             return await _context.Studnts
            .OrderByDescending(s => s.Class)
            .Include(x => x.Class)
            .ToListAsync();
        }

        public async Task<Studnt> GetByClassId(int classid)
        {
             return (Studnt)(IEnumerable<Studnt>) await _context.Studnts
            .Where(s => s.Classid == classid)
            .OrderByDescending(s => s.Class)
            .Include(x => x.Class)
            .Select(m => new StudentDetailsDto
            {
                Id = m.Id,
                classid = m.Classid,
                name = m.Name,
                age = m.age,
                ClassName = m.Class.name
            })
            .ToListAsync();
            
        }

        public async Task<Studnt> GetById(int id)
        {
            //return await _context.Studnts
            //    .Include(c => c.Class)
            //    .SingleOrDefaultAsync(s => s.Id == id);
            return await _context.Studnts.FindAsync(id);
        }

        public async Task<Studnt> Add(Studnt student)
        {
            await _context.Studnts.AddAsync(student);
            _context.SaveChanges();
            return student;
        }

        public Studnt Update(Studnt student)
        {
            _context.Update(student);
            _context.SaveChanges();
            return student;
        }

        public Studnt Delate(Studnt student)
        {
            _context.Remove(student);
            _context.SaveChanges();
            return student;
        }

    }
}
