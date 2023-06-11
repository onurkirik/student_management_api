using student_management.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_management.Domain.Entities
{
    public class Gender : BaseEntity
    {
        public string Description { get; set; }
        public Guid StudentId { get; set; }
    }
}
