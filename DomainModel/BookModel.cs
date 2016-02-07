﻿using System;
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
        public byte[] BookImage { get; set; }
        public IList<AuthorModel> Authors { get; set; }

        public BookModel()
        {
            Authors= new AuthorModel[0];
        }
    }
}
