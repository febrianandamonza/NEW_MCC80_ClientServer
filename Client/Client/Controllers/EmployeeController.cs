
using Client.Contracts;
using Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using API.Models;
using IEmployeeRepository = Client.Contracts.IEmployeeRepository;
using API.DTOs.Employees;
using API.DTOs.Rooms;
using Microsoft.AspNetCore.Authorization;

namespace Client.Controllers
{
    [Authorize(Roles = "Manager")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await repository.Get(id);
            var ListRoom = new Employee();
            if (result.Data != null)
            {
                ListRoom = result.Data;
            }
            return View(ListRoom);
        }

        [HttpPost]
        public async Task<IActionResult> Remove(Guid id)
        {
            var result = await repository.Delete(id);
            if (result.Code == 200)
            {
                TempData["Success"] = $"Data has been Successfully Registered! - {result.Message}!";
                return RedirectToAction("index","employee");
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await repository.Get(id);
            var ListRoom = new Employee();

            if (result.Data != null)
            {
                ListRoom = result.Data;
            }
            return View(ListRoom);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EmployeeDto employeeDto)
        {
            var result = await repository.Put(employeeDto.Guid,employeeDto);

            if (result.Code == 200)
            {
                TempData["Success"] = $"Data has been Successfully Registered! - {result.Message}!";
                return RedirectToAction("Index","Employee");
            }
            return RedirectToAction(nameof(Edit));
        }
        public async Task<IActionResult> Index()
        {
            var result = await repository.Get();
            var ListEmployee = new List<Employee>();

            if (result.Data != null)
            {
                ListEmployee = result.Data.ToList();
            }
            return View(ListEmployee);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewEmployeeDto newEmploye)
        {

            var result = await repository.Post(newEmploye);
            if (result.Status == "200")
            {
                TempData["Success"] = "Data berhasil masuk";
                return RedirectToAction(nameof(Index));
            }
            else if (result.Status == "409")
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View();
            }
            return RedirectToAction(nameof(Index));

        }

    }
}