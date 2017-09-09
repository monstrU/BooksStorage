using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class BookModel
    {
        public int BookId { get; set; }
        public string  Title { get; set; }
        public int PagesCount { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishDate { get; set; }
        public string ISBN { get; set; }
        public string BookFileName { get; set; }
        public IList<PersonModel> Authors { get; set; }

        public BookModel()
        {
            Authors = new List<PersonModel>();
        }
    }
}
