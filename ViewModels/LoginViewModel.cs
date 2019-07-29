using System.ComponentModel.DataAnnotations;

namespace Ormawa.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage="{0} harus diisi.")]
        public string Username { get; set; }
        [Required(ErrorMessage="{0} harus diisi.")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
