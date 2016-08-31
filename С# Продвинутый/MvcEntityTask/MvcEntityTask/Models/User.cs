using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcEntityTask.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string Key { get; set; }

        [Required(ErrorMessage = "Введите пожалуйста имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите пожалуйста пароль")]
        public string Password { get; set; }

        public virtual List<Review> Reviews { get; set; }
    }
}