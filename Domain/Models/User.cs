using BookManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User : BaseModel
    {

        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }
 
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<Loan>? Loan { get; set; }
    }
}
