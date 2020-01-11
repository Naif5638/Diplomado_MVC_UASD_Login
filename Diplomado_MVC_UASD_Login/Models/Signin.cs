using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Diplomado_MVC_UASD_Login.Models
{
    public class SignIn
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El Apellido es requerido")]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El Usuario es requerido")]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "El Email es requerido")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "El numero de {0} debe ser al menos {2}", MinimumLength = 3)]
        [Required(ErrorMessage = "El Password es requerido")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        UsersDataDataContext user = new UsersDataDataContext();
        User obj = new User();

        public bool Signin()
        {
            var query = from u in user.Users
                        where u.Email == Email ||
                        u.UserName == UserName
                        select u;
            if (query.Count() > 0)
                return false;
            else
            {
                obj.Name = Name;
                obj.LastName = LastName;
                obj.UserName = UserName;
                obj.Email = Email;
                obj.Password = Password;

                user.Users.InsertOnSubmit(obj);
                user.SubmitChanges();
                return true;
            }
                
        }

    }
}