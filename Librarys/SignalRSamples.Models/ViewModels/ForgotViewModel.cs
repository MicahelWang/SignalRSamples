using System.ComponentModel.DataAnnotations;

namespace SignalRSamples.Models.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "�����ʼ�")]
        public string Email { get; set; }
    }
}