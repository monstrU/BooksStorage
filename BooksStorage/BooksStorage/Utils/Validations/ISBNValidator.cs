using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BooksStorage.Utils.Validations
{
    /// <summary>
    /// валидатор 9 значного номера ISBN
    /// </summary>
    public class ISBNValidator
    {
        public string ISBN { get; }
        public ISBNValidator(string isbn)
        {
            ISBN = isbn;
        }

        public bool Validate()
        {
            const int validISBNLenght = 9;
            const int divider = 11;
            var result = true;

            var regex = new Regex("(\\d)",
                   RegexOptions.IgnoreCase
                   | RegexOptions.CultureInvariant
                   | RegexOptions.IgnorePatternWhitespace
                   | RegexOptions.Compiled
                   );
            var chars = regex.Matches(ISBN);

            var numbers = (chars.Cast<Match>().Select(number => Convert.ToInt16(number.Value))).ToArray();

            result = numbers.Length == validISBNLenght;


            if (result)
            {
                int[] constants = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int mul = constants.Select((t, index) => t * numbers[index]).Sum();
                var div = mul % divider;

                var sum = divider - div;

                result = ((mul + sum) % divider) == 0;
            }

            return result;
        }
    }
}