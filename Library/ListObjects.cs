using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto.Data;
using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Library
{
    public class ListObjects
    {
        public String description, code; 
        public UserRoles _userRole;
        public UserData _userData;
        public IdentityError _identityError;
        public ApplicationDbContext _contenxt;

        public List<SelectListItem> _userRoles;

        public RoleManager<IdentityRole> _roleManager;
        public UserManager<IdentityUser> _userManager;
        public SignInManager<IdentityUser> _signInManager;

        public List<object[]> dataList = new List<object[]>();
    }
}
