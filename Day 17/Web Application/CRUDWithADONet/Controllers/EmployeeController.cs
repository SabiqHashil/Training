using CRUDWithADONet.DAL;
using CRUDWithADONet.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDWithADONet.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly Employee_DAL _dal;

        public EmployeeController(Employee_DAL dal)
        {
            _dal = dal;
        }
        // Table Get
        [HttpGet]
        public IActionResult Index()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                employees = _dal.GetAll();
            }
	        catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
            }
            return View(employees);
        }
        // Create Get
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        // Create Post
        [HttpPost]
        public IActionResult Create(Employee model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                // Validate DateOfBirth range
                if (model.DateOfBirth < new DateTime(2000, 1, 1) || model.DateOfBirth > new DateTime(9999, 12, 31))
                {
                    ModelState.AddModelError(nameof(model.DateOfBirth), "Date of Birth must be between 01/01/2000 and 12/31/9999.");
                    return View(model);
                }
                bool result = _dal.Insert(model);
                if (!result)
                {
                    TempData["errorMessage"] = "Unable to save the data";
                    return View();
                }
                TempData["successMessage"] = "Employee details saved";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // Edit Get by ID
        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                Employee employee = _dal.GetById(id);
                if (employee.Id == 0)
                {
                    TempData["errorMessage"] = $"Employee details not found with Id : {id}";
                    return RedirectToAction("Index");
                }
                return View(employee);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // Edit Post by ID
        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["errorMessage"] = "Model data is invalid";
                    return View();
                }
                bool result = _dal.Update(model);
                    if (!result)
                    {
                        TempData["errorMessage"] = "Unable to update the data";
                        return View();
                    }
                    TempData["successMessage"] = "Employee details updated";
                    return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
        // Delete Get by ID
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                Employee employee = _dal.GetById(id);
                if (employee.Id == 0)
                {
                    TempData["errorMessage"] = $"Employee details not found with Id : {id}";
                    return RedirectToAction("Index");
                }
                return View(employee);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // Delete Confirmation POST 
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(Employee model)
        {
            try
            {
                bool result = _dal.Delete(model.Id);
                if (!result)
                {
                    TempData["errorMessage"] = "Unable to delete the data";
                    return View();
                }
                TempData["successMessage"] = "Employee details deleted";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

    }
}
