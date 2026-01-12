using System.Diagnostics;
using CodeFirstASPCore10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstASPCore10.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDBContext studentDB;

        public HomeController(StudentDBContext studentDB)
        {
            this.studentDB = studentDB;
        }
        public async Task<IActionResult> Index()
        {
            var stdData = await studentDB.Students.ToListAsync();

            return View(stdData);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student Std)
        {
            if (ModelState.IsValid)
            {
                await studentDB.Students.AddAsync(Std);
                await studentDB.SaveChangesAsync();
                TempData["SuccessMessage"] = "Student Record Created Successfully";
                return RedirectToAction("Index", "Home");
            }
            return View(Std);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || studentDB.Students == null)
            {
                return NotFound();
            }
            var stdData = await studentDB.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (stdData == null)
            {
                return NotFound();
            }

            return View(stdData);
        }
        public async Task<IActionResult> Edit(int? id) // Change to nullable int?
        {
            if (id == null || studentDB.Students == null)
            {
                return NotFound();
            }

            var stdData = await studentDB.Students.FindAsync(id);

            if (stdData == null)
            {
                return NotFound();
            }

            return View(stdData); // You MUST pass stdData here to fill the form
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Student Std)
        {
            if (id != Std.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                studentDB.Update(Std);
                await studentDB.SaveChangesAsync();
                TempData["SuccessMessage"] = "Student Record Updated Successfully";
                return RedirectToAction("Index", "Home");
            }
            return View(Std);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || studentDB.Students == null)
            {
                return NotFound();
            }
            var stdData = await studentDB.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (stdData == null)
            {
                return NotFound();
            }
            return View(stdData);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var stdData = await studentDB.Students.FindAsync(id);
            if (stdData != null)
            {
                studentDB.Students.Remove(stdData);
                await studentDB.SaveChangesAsync();
            }
            await studentDB.SaveChangesAsync();
            TempData["SuccessMessage"] = " Student Record Deleted Successfully";
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
