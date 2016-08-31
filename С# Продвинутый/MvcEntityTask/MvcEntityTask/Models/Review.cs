using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcEntityTask.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        
        public DateTime? Date { get; set; }

        [Required(ErrorMessage = "Заполните пожалуйста отзыв")]
        public string Comment { get; set; }
        
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}