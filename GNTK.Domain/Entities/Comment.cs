using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GNTK.Domain.Entities
{
    public class Comment
    {
        [Key]
        [Required]
        [MaxLength(450)]
        public string CommentId { get; set; }
        [Required]
        [Range(0,5)]
        public int Rate { get; set; }
        [MaxLength(250)]
        public string Content { get; set; }
        public virtual Booking Booking { get; set; }
    }
}
