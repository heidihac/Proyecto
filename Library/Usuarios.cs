using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Library
{
    public class Usuarios : ListObjects
    {
        #region metodos constructores
        public Usuarios()
        {

        }
        public Usuarios(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userRole = new UserRoles();
        }
        public Usuarios(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _userRole = new UserRoles();
        }
        #endregion
        //internal async Task<List<object[]>> userLogin(string email, string password)
        //{
        //    try
        //    {
        //        var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);
        //        if (result.Succeeded)
        //        {
        //            var appUser = _userManager.Users.Where(u => u.Email.Equals(email)).ToList();
        //        }
        //        else
        //        {
        //            code = "1";
        //            description = "Correo o contraseña inválidos";
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    }
}
