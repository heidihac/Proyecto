using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class HomeController : Controller
    {
        IServiceProvider _serviceProvider;
        public HomeController(IServiceProvider serviceProvider)
        {
            //_serviceProvider = serviceProvider;
            //ejecutarTareaAsincronica();
        }
        public async Task<IActionResult> Index()
        {
            await CreateRoles(_serviceProvider);
            return View();
        }

        //Para Post en Inicio de Sesion.

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {

            }
            return View(model);
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
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
        #region Roles
        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            String mensaje;

            try
            {
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

                String[] rolesName = { "Admin", "User" };

                foreach (var item in rolesName)
                {
                    var roleExist = await roleManager.RoleExistsAsync(item);
                    if (!roleExist)
                    {
                        await roleManager.CreateAsync(new IdentityRole(item));
                    }
                }
                var user = await userManager.FindByIdAsync("594043de-9eee-4039-84f0-9cc9e40a8c28");

                await userManager.AddToRoleAsync(user, "Admin");
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

        }
        #endregion

        //Ejecución de una tarea asincrónica.
        private async void ejecutarTareaAsincronica()
        {
            var data = await TareasAsincronicas();

            String tarea = "Se ejecutan las otras líneas de código, porque la tarea asincrónica finalizó."; 
        }
        private async Task<String> TareasAsincronicas()
        {
            Thread.Sleep(20 * 1000);

            String tarea = "Tarea Asincronica Finalizada";

            return tarea;

        }
    }
}

