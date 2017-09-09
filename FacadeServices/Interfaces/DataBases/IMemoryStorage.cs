﻿using System.Collections;
using System.Collections.Generic;
using DomainModel;

namespace FacadeServices.Interfaces.DataBases
{
    public interface IMemoryStorage
    {
        void Add(BookModel book);
        void Add(PersonModel person);
        IList<BookModel> LoadBooks();
        BookModel LoadBook(int bookId);
    }
}