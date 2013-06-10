using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ib_dotnet.Models
{
    
    public class User
    {
        [Key]
        public int UserId { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Language { get; set; }        
    }
}