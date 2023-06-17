using System.ComponentModel.DataAnnotations;

namespace Core_Proje_Udemy.Areas.Writter.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen adınızı girin!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen Soyadınızı girin!")]
        public string Surname { get; set; }
        [Required(ErrorMessage ="Lütfen kullanıcı adını girin!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen şifrenizi girin!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Lütfen şifrenizi tekrar girin!")]
        [Compare("Password",ErrorMessage = "Şifreler uyumlu değil!")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Lütfen mailinizi girin!")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Lütfen resim yolunu girin!")]
        public string ImageUrl { get; set; }
    }
}
