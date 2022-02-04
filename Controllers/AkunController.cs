using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_Project.Data;
using My_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace My_Project.Controllers
{
    public class AkunController : Controller
    {
        private readonly AppDbContext _context;

        public AkunController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Daftar()
        {
            return View();
        }

        public IActionResult UserAdmin()
        {
            var data = _context.Tb_User.ToList();

            return View(data);
        }

        [HttpPost]
        public IActionResult Daftar(User pengguna)
        {
            var deklarRole = _context.Tb_Roles.Where(
                x => x.Id == "1"
                ).FirstOrDefault();

            pengguna.Roles = deklarRole;

            if (!ModelState.IsValid)
            {
                return View(pengguna);
            }

            _context.Tb_User.Add(pengguna);
            _context.SaveChanges();

            return RedirectToAction("UserAdmin");

        }

        public IActionResult Masuk()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Masuk(User pengguna)
        {
            var cekUsername = _context.Tb_User.Where(
                free =>
                free.Username == pengguna.Username
                ).FirstOrDefault();

            if (cekUsername != null)
            {
                var cekPassword = _context.Tb_User.Where(
                    free =>
                    free.Username == pengguna.Username
                    &&
                    free.Password == pengguna.Password
                    )
                    .Include(free2 => free2.Roles)
                    .FirstOrDefault();

                if (cekPassword != null)
                {
                    // proses Tampungan data
                    var daftar = new List<Claim>
                    {
                        new Claim("Username", cekUsername.Username),
                        new Claim("Role", cekUsername.Roles.Id)
                    };

                    // Proses daftar
                    await HttpContext.SignInAsync(new ClaimsPrincipal(
                        new ClaimsIdentity(
                            daftar, "Cookie", "Username", "Role")
                        ));

                    if (cekUsername.Roles.Id == "1")
                    {
                        return RedirectToAction(controllerName: "Employee", actionName: "Index");
                    }

                    return RedirectToAction(controllerName: "Employee", actionName: "Index");
                }

                ViewBag.pesan = "Passwordnya Salah Euy !!!";

                return View(pengguna);
            }

            ViewBag.pesan = "Username Anda Tidak Ada";

            return View(pengguna);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return Redirect("/");
        }
    }
}
