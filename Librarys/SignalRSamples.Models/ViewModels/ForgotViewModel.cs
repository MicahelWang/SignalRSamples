using System.ComponentModel.DataAnnotations;

namespace SignalRSamples.Models.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "µç×ÓÓÊ¼þ")]
        public string Email { get; set; }
    }
}