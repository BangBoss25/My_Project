using Microsoft.AspNetCore.Mvc;
using My_Project.Data;
using My_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Project.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.Tb_Employees.ToList();
            return View(data);
        }

        public IActionResult DataKaryawan()
        {
            var data = _context.Tb_Employees.ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee namaParameter)
        {
            if (ModelState.IsValid)
            {

                _context.Tb_Employees.Add(namaParameter);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");

            }

            return View(namaParameter);
        }


    }
}
