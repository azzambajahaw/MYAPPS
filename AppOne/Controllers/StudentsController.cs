//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace AppOne.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class StudentsController : ControllerBase
//    {
//        private readonly AppDbContext _context;

//        public StudentsController(AppDbContext context)
//        {
//            _context = context;
//        }
//        [HttpGet]
//        public async Task<IActionResult> GetStudentAsync()
//        {
//            //  ((way of opject inside opject))

//            //var All = await _context.Studnts
//            //.OrderByDescending(s => s.Class)
//            //.Include(x => x.Class)
//            //.ToListAsync();
//            //return Ok(All);

//            //  ((way of all data inside one opject))
//            var All = await _context.Studnts
//                .OrderByDescending(s=>s.Class)
//                .Include(x => x.Class)
//                .Select(m=> new StudentDetailsDto
//                {
//                    Id = m.Id,
//                    classid = m.Classid,
//                    name = m.Name,
//                    age = m.age,
//                    ClassName = m.Class.name
//                })
//                .ToListAsync();
//            return Ok(All); 
//        }


//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetStudentByIdAsync(int id)
//        {
//            // ((the same way but deffernt orgnaize))


//            //var student = await _context.Studnts
//            //.Include(c => c.Class)
//            // .Select(m => new StudentDetailsDto
//            // {
//            //     Id = m.Id,
//            //     classid = m.Classid,
//            //     name = m.Name,
//            //     age = m.age,
//            //     ClassName = m.Class.name
//            // })
//            //.SingleOrDefaultAsync(s => s.Id == id);
//            //if (student == null)
//            //{
//            //    return NotFound($"no student with id ={id}");
//            //}

//            //return Ok(student);

//            var student = await _context.Studnts
//                .Include(c=>c.Class)
//                .SingleOrDefaultAsync(s=>s.Id == id);
//            if(student == null)
//            {
//                return NotFound($"no student with id ={id}");
//            }
//            var filteredstudent = new StudentDetailsDto
//            {
//                    Id = student.Id,
//                    classid = student.Classid,
//                    name = student.Name,
//                    age = student.age,
//                    ClassName = student.Class.name
//            };

//            return Ok(filteredstudent); 
//        }


//        [HttpGet("GetByClassId")]
//        public async Task<IActionResult> GetByClassIdAsync(int classid)
//        {
//            var All = await _context.Studnts
//            .Where(s => s.Classid == classid)
//            .OrderByDescending(s => s.Class)
//            .Include(x => x.Class)
//            .Select(m => new StudentDetailsDto
//            {
//                Id = m.Id,
//                classid = m.Classid,
//                name = m.Name,
//                age = m.age,
//                ClassName = m.Class.name
//            })
//            .ToListAsync();
//            return Ok(All);

//        }

//        [HttpPost]
//        public async Task<IActionResult> CreatStudentAsync(StudentDto dto)
//        {
//            var checkFKofClass = await _context.Classs.AnyAsync(x => x.id == dto.Classid);
//            if(!checkFKofClass)
//            {
//                return BadRequest($"no class exsisting with id = {dto.Classid}");
//            }
//            var student = new Studnt
//            {
//                Name = dto.Name,
//                age = dto.age,
//                Classid = dto.Classid,
//            };
//            await _context.Studnts.AddAsync(student);
//            _context.SaveChanges();
//            return Ok(student); 
//        }

//        [HttpPut]
//        public async Task<IActionResult> UpdateStudentAsync(int id ,StudentDto dto)
//        {
//            var student = await _context.Studnts
//            .Include(c => c.Class)
//            .SingleOrDefaultAsync(s => s.Id == id);
//            if (student == null)
//            {
//                return NotFound($"no student with id ={id}");
//            }

//            student.Classid = dto.Classid;
//            student.age = dto.age;
//            student.Name = dto.Name;

//            _context.SaveChanges(); 

//            return Ok(student);
//        }


//        [HttpDelete]
//        public async Task<IActionResult> DeleteStudentAsync(int id)
//        {
//            var student = await _context.Studnts.FindAsync(id);
//            if (student == null)
//            {
//                return NotFound("no student with this id");
//            }
//            _context.Studnts.Remove(student);
//            _context.SaveChanges();
//            return Ok(student);
//        }



//        //[HttpDelete("{classId}/{studentId}")]
//        //public async Task<IActionResult> DeleteStudentFromClass(int classId, int studentId)
//        //{
//        //    // 1. Retrieve the class to ensure it exists
//        //    var dbContext = GetDbContext(); // Assuming you have a method to get the database context
//        //    var theClass = await dbContext.Classes.FindAsync(classId);

//        //    if (theClass == null)
//        //    {
//        //        return NotFound("Class not found");
//        //    }

//        //    // 2. Retrieve the student to ensure it exists within that class
//        //    var student = await theClass.Students.FindAsync(studentId);

//        //    if (student == null)
//        //    {
//        //        return NotFound("Student not found in this class");
//        //    }

//        //    // 3. Remove the student from the class's navigation property
//        //    theClass.Students.Remove(student);

//        //    try
//        //    {
//        //        // 4. Save changes to the database
//        //        await dbContext.SaveChangesAsync();
//        //        return Ok("Student deleted from class successfully");
//        //    }
//        //    catch (DbUpdateException ex)
//        //    {
//        //        // Handle potential database errors gracefully
//        //        return StatusCode(500, "Failed to delete student: " + ex.Message);
//        //    }
//        //}






//        //[HttpDelete("{classId}/{studentId}")]
//        //public async Task<IActionResult> DeleteStudent(int classId, int studentId)
//        //{
//        //    // Validate and fetch the class
//        //    var classToUpdate = await _context.Classes.FindAsync(classId);
//        //    if (classToUpdate == null)
//        //    {
//        //        return NotFound("Class not found.");
//        //    }

//        //    // Find the student within the class
//        //    Student studentToDelete = null;
//        //    foreach (Student student in classToUpdate.Students)
//        //    {
//        //        if (student.Id == studentId)
//        //        {
//        //            studentToDelete = student;
//        //            break;
//        //        }
//        //    }

//        //    if (studentToDelete == null)
//        //    {
//        //        return NotFound("Student not found in the specified class.");
//        //    }

//        //    // Remove student from the class's Students collection
//        //    classToUpdate.Students.Remove(studentToDelete);

//        //    // Delete the student entity
//        //    _context.Students.Remove(studentToDelete);

//        //    try
//        //    {
//        //        // Save changes to the database
//        //        await _context.SaveChangesAsync();
//        //        return NoContent();
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        // Handle database errors gracefully
//        //        return StatusCode(500, "Failed to delete student: " + ex.Message);
//        //    }
//        //}

//        [HttpDelete("{classId:int}/{studentId:int}")]
//        public async Task<IActionResult> DeleteStudent(int classId, int studentId)
//        {
//            // Find the student in the database
//            var student = await _context.Studnts
//                .FirstOrDefaultAsync(s => s.Id == studentId && s.Classid == classId);

//            // If the student doesn't exist or isn't in the specified class, return NotFound
//            if (student == null)
//            {
//                return NotFound("no student");
//            }

//            // Remove the student from the database
//            _context.Studnts.Remove(student);
//            await _context.SaveChangesAsync();

//            // Return a NoContent response
//            return NoContent();
//        }






//    }
//}


using AppOne.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudntService _studntService;
        private readonly IClassService _classService;
        public StudentsController(StudntService studntService , IClassService classService)
        {
            _studntService = studntService;
            _classService = classService;
        }
        [HttpGet]
        public async Task<IActionResult> GetStudentAsync()
        {
            //  ((way of opject inside opject))

            //var All = await _context.Studnts
            //.OrderByDescending(s => s.Class)
            //.Include(x => x.Class)
            //.ToListAsync();
            //return Ok(All);

            //  ((way of all data inside one opject))
            var All = _studntService.GetAll();
            return Ok(All);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentByIdAsync(int id)
        {
            // ((the same way but deffernt orgnaize))


            //var student = await _context.Studnts
            //.Include(c => c.Class)
            // .Select(m => new StudentDetailsDto
            // {
            //     Id = m.Id,
            //     classid = m.Classid,
            //     name = m.Name,
            //     age = m.age,
            //     ClassName = m.Class.name
            // })
            //.SingleOrDefaultAsync(s => s.Id == id);
            //if (student == null)
            //{
            //    return NotFound($"no student with id ={id}");
            //}

            //return Ok(student);

            var student = await _studntService.GetById(id);
            if (student == null)
            {
                return NotFound($"no student with id ={id}");
            }
            var filteredstudent = new StudentDetailsDto
            {
                Id = student.Id,
                classid = student.Classid,
                name = student.Name,
                age = student.age,
                ClassName = student.Class.name
            };

            return Ok(filteredstudent);
        }


        [HttpGet("GetByClassId")]
        public async Task<IActionResult> GetByClassIdAsync(int classid)
        {
            var All = _studntService.GetByClassId(classid);
            return Ok(All);

        }

        [HttpPost]
        public async Task<IActionResult> CreatStudentAsync(StudentDto dto)
        {
            var checkFKofClass = await _classService.IsValidClass(dto.Classid);
            if (!checkFKofClass)
            {
                return BadRequest($"no class exsisting with id = {dto.Classid}");
            }
            var student = new Studnt
            {
                Name = dto.Name,
                age = dto.age,
                Classid = dto.Classid,
            };
            await _studntService.Add(student);
            return Ok(student);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudentAsync(int id, StudentDto dto)
        {
            var student = await _studntService.GetById(id);

            if (student == null)
            {
                return NotFound($"no student with id ={id}");
            }

            student.Classid = dto.Classid;
            student.age = dto.age;
            student.Name = dto.Name;

            _studntService.Update(student);

            return Ok(student);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteStudentAsync(int id)
        {
            var student = await _studntService.GetById(id);
            if (student == null)
            {
                return NotFound("no student with this id");
            }
            _studntService.Delate(student);
            return Ok(student);
        }

    }
}
