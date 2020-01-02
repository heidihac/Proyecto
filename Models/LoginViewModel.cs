using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    #region Configuracion Login
    public class LoginViewModel
    {
        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }
        public class InputModel
        {
            [Required(ErrorMessage = "<font color='red'> El correo electrónico es obligarorio. </font>")]
            [EmailAddress(ErrorMessage = "<font color='red'> Debe Ingresar un correo electrónico válido. </font>")]
            public string Email { get; set; }

            [Required(ErrorMessage = "<font color='red'> La contraseña es obligaroria. </font>")]
            [DataType(DataType.Password)]
            [StringLength(100, ErrorMessage = "<font color='red'> El numero de caracteres del {0} debe ser  al menos de {2} caracteres. </font>", MinimumLength = 6)]
            public string Password { get; set; }
        }
    }
    #endregion
}
