using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using mission_08_models_db_setup.Models;
using mission_08_models_db_setup.Repositories;
using System.Diagnostics;

namespace mission_08_models_db_setup.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskRepository _taskRepo;
        private readonly ICategoryRepository _categoryRepo;

        public HomeController(ITaskRepository taskRepo, ICategoryRepository categoryRepo)
        {
            _taskRepo = taskRepo;
            _categoryRepo = categoryRepo;
        }

        public IActionResult Index()
        {
           
            var tasks = _taskRepo.GetAllTasks() 
                .Where(x => x.Completed == false)
                .ToList();

            
            return View(tasks); 
        }

        // GET: /Home/AddEdit  or  /Home/AddEdit/5
        [HttpGet]
        public IActionResult AddEdit(int? id)
        {
            PopulateCategoryDropdown();

            if (id.HasValue)
            {
                var task = _taskRepo.GetTaskById(id.Value);
                if (task == null) return NotFound();
                return View(task);
            }

            return View(new TaskItem());
        }

        // POST: /Home/AddEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEdit(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                if (task.TaskItemId == 0)
                {
                    _taskRepo.AddTask(task);
                }
                else
                {
                    _taskRepo.UpdateTask(task);
                }
                _taskRepo.SaveChanges();
                return RedirectToAction("Quadrants");
            }

            PopulateCategoryDropdown();
            return View(task);
        }

        public IActionResult Quadrants()
        {
            var tasks = _taskRepo.GetAllTasks().Where(t => !t.Completed);
            return View(tasks);
        }

        // POST: /Home/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _taskRepo.DeleteTask(id);
            _taskRepo.SaveChanges();
            return RedirectToAction("Quadrants");
        }

        // POST: /Home/MarkComplete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MarkComplete(int id)
        {
            var task = _taskRepo.GetTaskById(id);
            if (task != null)
            {
                task.Completed = true;
                _taskRepo.UpdateTask(task);
                _taskRepo.SaveChanges();
            }
            return RedirectToAction("Quadrants");
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

        private void PopulateCategoryDropdown()
        {
            var categories = _categoryRepo.GetAllCategories();
            ViewBag.Categories = categories.Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.Name
            }).ToList();
        }
    }
}
