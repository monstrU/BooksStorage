﻿using System.Collections.Generic;

namespace BooksStorage.Utils
{
    public class OperationResult
    {
        public bool IsSuccess { get; set; }
        public IList<string> ErrorMessages { get; set; }

        public OperationResult()
        {
            ErrorMessages=new List<string>();
        }
    }
}