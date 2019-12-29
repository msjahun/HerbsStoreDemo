using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HerbsStore.Libraries.HS.Core.Domain.Feedback
{
    public class Feedback:BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime CreatedOn { get; set; }
        
    }
}
