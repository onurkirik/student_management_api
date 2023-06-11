using student_management.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_management.Domain.Entities
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ProfileImageUrl { get; set; }

        public Guid GenderId { get; set; }
        public Gender Gender { get; set; }
        public Adress Adress { get; set; }
    }
}
