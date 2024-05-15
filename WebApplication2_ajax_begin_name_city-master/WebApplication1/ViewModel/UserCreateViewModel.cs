using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModel
{
    public class UserCreateViewModel
    {
        [Required(ErrorMessage ="Lütfen Bir İsim Giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen Bir Soyisim Giriniz")]
        public string UserSurname { get; set; }

        [Required(ErrorMessage = "Lütfen Şehir Giriniz")]
        public string City { get; set; }
    }
}