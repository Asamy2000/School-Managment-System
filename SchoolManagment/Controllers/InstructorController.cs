using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagment.Contexts;
using SchoolManagment.Interfaces;
using SchoolManagment.Models;

namespace SchoolManagment.Controllers
{
    public class InstructorController : Controller
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;
        private readonly IInstructorRepository _instructorRepository;

        public InstructorController(SchoolDbContext context, IMapper mapper, IInstructorRepository instructorRepository)
        {
            _context = context;
            _mapper = mapper;
            _instructorRepository = instructorRepository;
        }

        public async Task<IActionResult> Index()
        {
            // Use the injected context to fetch data
            IEnumerable<Instructor> instructors = await _instructorRepository.GetAll();

            return View(instructors);
        }

        public  async Task<IActionResult> details(int id)
        {
            #region To Make Drop Down List I will this data 
            //ViewBag Read & Write in ViewData [dynamic so No casting in The View NOt like ViewData]
            List<Department> departments = _context.Departments.ToList();
            List<Course> courses = _context.Courses.ToList();
            ViewBag.Depts = departments;
            ViewData["Crs"] = courses;
            #endregion
            var instructor = await _instructorRepository.GetById(id);
                
                
                //_context.Instructors
                //.Include(i => i.Department)
                //.Include(i => i.Course)
                //.FirstOrDefault(x => x.Id == id);

            return View(instructor);
        }

        public IActionResult Edit(int id)
        {



            var instructor = _context.Instructors
                .Include(i => i.Department)
                .Include(i => i.Course)
                .FirstOrDefault(x => x.Id == id);

            if (instructor == null)
            {
                return NotFound(); // Handle the case where instructor is not found
            }
            var Mapped = _mapper.Map<Instructor, _InstructorVM>(instructor);

            #region To Make Drop Down List I will this data 
            //ViewBag Read & Write in ViewData [dynamic so No casting in The View NOt like ViewData]
            List<Department> departments = _context.Departments.ToList();
            List<Course> courses = _context.Courses.ToList();
            ViewBag.Depts = departments;
            ViewData["Crs"] = courses;
            #endregion
            return View(Mapped);
        }


        //Just for Saving Data in The Database then redirect To the Index Action to see the Update
        [HttpPost]
        public IActionResult SaveEdit([FromRoute] int id, _InstructorVM instructorVM) //[FromRoute] => Security wise
        {
            if (ModelState.IsValid)
            {
                var ins = _context.Instructors.FirstOrDefault(i => i.Id == id);

                if (ins == null)
                {
                    return NotFound(); // Handle the case where instructor is not found
                }


                //ins.Name = instructor.Name;
                //ins.Address = instructor.Address;
                //ins.Salary = instructor.Salary;
                //ins.dept_Id = instructor.dept_Id;
                //ins.Imag = instructor.Imag;
                //ins.crs_id = instructor.crs_id;

                _mapper.Map(instructorVM, ins); //don't create new obj from ins so tracking work
                //ins = _mapper.Map<_InstructorVM, Instructor>(instructorVM); does not work why??
                //because it creates new obj and assign it to the reference ins while the old object is tracked in memory without no change
                _context.SaveChanges(); // Save changes to the database

                return RedirectToAction("Index");
            }
            #region To Make Drop Down List I will this data 
            //ViewBag Read & Write in ViewData [dynamic so No casting in The View NOt like ViewData]
            List<Department> departments = _context.Departments.ToList();
            List<Course> courses = _context.Courses.ToList();
            ViewBag.Depts = departments;
            ViewData["Crs"] = courses;
            #endregion
            return View("Edit", instructorVM);
        }


        public ActionResult Add()
        {
            #region To Make Drop Down List I will this data 
            //ViewBag Read & Write in ViewData [dynamic so No casting in The View NOt like ViewData]
            List<Department> departments = _context.Departments.ToList();
            List<Course> courses = _context.Courses.ToList();
            ViewBag.Depts = departments;
            ViewData["Crs"] = courses;
            #endregion
            return View();
        }


        public ActionResult SaveAdd(_InstructorVM instructor)
        {
            if (ModelState.IsValid)
            {
                var mapped = _mapper.Map<_InstructorVM, Instructor>(instructor);
                _context.Instructors.Add(mapped);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            #region To Make Drop Down List I will this data 
            //ViewBag Read & Write in ViewData [dynamic so No casting in The View NOt like ViewData]
            List<Department> departments = _context.Departments.ToList();
            List<Course> courses = _context.Courses.ToList();
            ViewBag.Depts = departments;
            ViewData["Crs"] = courses;
            #endregion
            return View("Add", instructor);
        }

        public ActionResult delete(int id)
        {
            #region To Make Drop Down List I will this data 
            //ViewBag Read & Write in ViewData [dynamic so No casting in The View NOt like ViewData]
            List<Department> departments = _context.Departments.ToList();
            List<Course> courses = _context.Courses.ToList();
            ViewBag.Depts = departments;
            ViewData["Crs"] = courses;
            #endregion

            var ins = _context.Instructors.Include(x => x.Course).Include(x => x.Department).FirstOrDefault(X => X.Id == id);
            ;
            return View(ins);
        }

        [HttpPost]
        public IActionResult SaveDelete(int id, string deleteButton, string cancelButton)
        {
            if (!string.IsNullOrEmpty(deleteButton) && id != null)
            {
                // Delete button was clicked, perform deletion and redirect
                // to a suitable action, e.g., Index or a confirmation page.
                // Delete the instructor from the database here.
                // Set the success message in TempData.

                var ins = _context.Instructors.FirstOrDefault(I => I.Id == id);
                TempData["DeletedUserName"] = "User " + ins.Name + " deleted successfully";
                _context.Instructors.Remove(ins);
                _context.SaveChanges();

                // Redirect to the Index action after successful deletion.
                return RedirectToAction("Index");
            }
            else if (!string.IsNullOrEmpty(cancelButton))
            {
                // Cancel button was clicked, redirect to the Index action.
                return RedirectToAction("Index");
            }
            return View("delete");
            // Handle any other cases or errors here.
        }


        public IActionResult CheckName(string Name, int Id)
        {
            if (Id == 0) //addition process
            {
                var Ins = _context.Instructors.FirstOrDefault(I => I.Name == Name);
                if (Ins == null) //name is New not exist in the database
                    return Json(true);
                else
                    return Json(false); //name exist 
            }
            else //edit process
            {
                Instructor Ins = _context.Instructors.FirstOrDefault(I => I.Name == Name);
                if (Ins == null)
                    return Json(true);
                else
                {
                    if (Ins.Id == Id) //the name which is found associated with the same instructor that is being edited
                        return Json(true);
                    else
                        return Json(false);  //associated with another one exist
                }
            }

        }
        #region Ex On Remote S07
        //public IActionResult NameExist(string Name, int id)
        //{
        //    //case Add NEw Student Add id=0;
        //    if (id == 0)
        //    {
        //        Instructor std = _context.Instructors.FirstOrDefault(s => s.Name == Name);
        //        if (std == null)//name not exist
        //            return Json(true);//new {name="ahemd,age=22}
        //        else //name already exist
        //            return Json(false);
        //    }
        //    else //edit\3
        //    {
        //        Instructor std = _context.Instructors.FirstOrDefault(s => s.Name == Name);
        //        if (std == null)
        //            return Json(true);//update name with new value not exist befor
        //        else
        //        {
        //            //object id==id parmeter true
        //            if (std.Id == id)//name not change
        //                return Json(true);
        //            else
        //                return Json(false);//chaged in name with value alread found
        //        }
        //    }
        //} 
        #endregion

        //public IActionResult CheckName(string Name)
        //{
        //    var std = _context.Instructors.FirstOrDefault(I => I.Name == Name);

        //    if (std == null)
        //    {
        //        // Name is new, not exist in the database
        //        return Json(true);
        //    }
        //    else if (std.Id != 0)
        //    {
        //        // If an ID exists, it's an edit
        //        if (Name == std.Name)
        //        {
        //            // Name is not changed during edit, return true
        //            return Json(true);
        //        }
        //    }

        //    // Name exists or it's an edit with a changed name, return false
        //    return Json(false);
        //}



        public IActionResult GetInstructorsByDeptId(int DeptId)
        {
            var result = _context.Instructors.Include(I => I.Department).Include(I => I.Course).Where(I => I.dept_Id == DeptId);
            return PartialView("_InstructorPartialView", result);
        }

    }
}
