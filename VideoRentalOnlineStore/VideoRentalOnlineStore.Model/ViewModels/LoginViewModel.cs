using System.ComponentModel.DataAnnotations;

namespace VideoRentalOnlineStore.Model.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public required string CardNumber {get; set;}
    }
}
