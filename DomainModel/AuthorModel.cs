using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class AuthorModel
    {
        public int BookId { get; set; }
        public PersonModel Person { get; set; }

        public AuthorModel()
        {
            Person= new PersonModel();
        }
    }
}
