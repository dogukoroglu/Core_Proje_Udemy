using System.ComponentModel.DataAnnotations;

namespace Core_Proje_Udemy.Areas.Writter.Models
{
    public class UserLoginViewModel
    {
        [Display(Name ="Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen kullanıcı adını girin!")]
        public string UserName { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen şifrenizi girin!")]
        public string Password { get; set; }
    }
}
