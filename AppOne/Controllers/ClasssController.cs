
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasssController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClasssController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudentAsync()
        {
            var Classs = await _context.Classs.ToListAsync();
            return Ok(Classs);
        }
        [HttpPost]
        public async Task<IActionResult> CreatStudentAsync(ClassDto dto)
        {
            var student = new Class { name = dto.name };
            await _context.Classs.AddAsync(student);
            _context.SaveChanges();
            return Ok(student);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudentAsync(int id, ClassDto dto)
        {
            var updatedstudant = _context.Classs.SingleOrDefault(x => x.id == id);
            if (updatedstudant == null)
            {
                return NotFound($"no stebent with id = {id}");
            }
            updatedstudant.name = dto.name;
            _context.SaveChanges();
            return Ok(updatedstudant);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentAsync(int id)
        {
            var removedstudant = _context.Classs.SingleOrDefault(x => x.id == id);
            if (removedstudant == null)
            {
                return NotFound($"no stebent with id = {id}");
            }
            _context.Classs.Remove(removedstudant);
            _context.SaveChanges();
            return Ok(removedstudant);

        }


    }
}



//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using AppOne.Services;

//namespace AppOne.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ClasssController : ControllerBase
//    {
//        private readonly IClassService _classServices;

//        public ClasssController(IClassService classServices)
//        {
//            _classServices = classServices;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetAllClassesAsync()
//        {
//            var Classs = _classServices.GetAll();
//            return Ok(Classs);
//        }
//        [HttpPost]
//        public async Task<IActionResult> CreatStudentAsync(ClassDto dto)
//        {
//            var cls = new Class { name = dto.name };
//            await _classServices.Add(cls);
//            return Ok(cls);
//        }
//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateStudentAsync(int id, [FromBody] ClassDto dto)
//        {
//            var updatedstudant = _classServices.GetById(id);    
//            if (updatedstudant == null)
//            {
//                return NotFound($"no stebent with id = {id}");
//            }
//            updatedstudant.name = dto.name;
//            await _classServices.Update(updatedstudant);
//            return Ok(updatedstudant);
//        }
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteStudentAsync(int id)
//        {
//            var removedstudant = _classServices.GetById(id);
//            if (removedstudant == null)
//            {
//                return NotFound($"no stebent with id = {id}");
//            }
//            await _classServices.Delate(removedstudant);
//            return Ok(removedstudant);

//        }


//    }
//}

