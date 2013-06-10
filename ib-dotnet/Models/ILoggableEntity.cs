using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ib_dotnet.Models
{
    interface ILoggableEntity
    {
        DateTime CreatedAt { get; set; }
    }
}
