using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ib_dotnet.Models
{
    public class Topic : ILoggableEntity
    {
        [Key]
        public int TopicId { get; set; }

        [Required, MinLength(1), MaxLength(250)]
        public String Title { get; set; }

        [Required, MinLength(1)]
        public String Content { get; set; }
        
        public DateTime CreatedAt{ get; set; }
              
        public int CreatedById { get; set; }
      
        
        [ForeignKey("CreatedById")]
        public virtual User CreatedBy { get; set; }

        public virtual IEnumerable<Reply> Replies { get; set; }

        public Topic()
        {
            Replies = new List<Reply>();
        }

        


        
    }
}