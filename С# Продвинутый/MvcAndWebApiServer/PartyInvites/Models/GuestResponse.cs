using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Пожалуйста, введите имя")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Пожалуйста, введите e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите телефон")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Пожалуйста, укажите, примите ли вы участи в вечеринке")]
        public bool? WillAttend { get; set; }
    }
}