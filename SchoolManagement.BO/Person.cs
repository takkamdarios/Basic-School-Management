using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.BO
{
    public class Person : BaseModel
    {
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public int Lastname { get; set; }

        public Person() { }
        public Person(int id, string? firstname, int lastname)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
        }
    }
}
