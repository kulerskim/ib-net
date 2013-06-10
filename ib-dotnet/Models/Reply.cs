using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ib_dotnet.Models
{
    public class Reply : ILoggableEntity
    {
        [Key]
        public int ReplyId { get; set; }

        [Required]
        public virtual Topic Topic { get; set; }

        [Required, MinLength(1)] 
        public String Content { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public int CreatedById { get; set; }
        
        [ForeignKey("CreatedById")]
        public virtual User CreatedBy { get; set; }
    }
}