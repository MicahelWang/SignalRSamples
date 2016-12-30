using System.ComponentModel.DataAnnotations;

namespace SignalRSamples.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "�û���")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "����")]
        public string Password { get; set; }

        [Display(Name = "��ס��?")]
        public bool RememberMe { get; set; }
    }
}