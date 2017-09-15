using System.Collections.Generic;

namespace BooksStorage.Utils
{
    public class OperationResultGeneric<T>: OperationResult where T : class
    {
        public T DataResult { get; set; }
    }
}