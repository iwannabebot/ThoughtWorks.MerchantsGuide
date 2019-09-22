using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ThoughtWorks.MerchantsGuide.LanguageService.Calculator
{
    /// <summary>
    /// - Numbers are formed by combining symbols together and adding the values.
    ///   MMVI is 1000 + 1000 + 5 + 1 = 2006
    /// - Generally, symbols are placed in order of value, starting with the largest values.
    ///   When smaller values precede larger values, the smaller values are subtracted from
    ///   the larger values, and the result is added to the total.
    ///   MCMXLIV = 1000 + (1000 − 100) + (50 − 10) + (5 − 1) = 1944
    /// - The symbols "I", "X", "C", and "M" can be repeated three times in succession, but
    ///   no more. (They may appear four times if the third and fourth are separated by a 
    ///   smaller value, such as XXXIX.)
    /// - "D", "L", and "V" can never be repeated.
    /// - "I" can be subtracted from "V" and "X" only.
    /// - "X" can be subtracted from "L" and "C" only.
    /// - "C" can be subtracted from "D" and "M" only.
    /// - "V", "L", and "D" can never be subtracted.
    /// - Only one small-value symbol may be subtracted from any large-value symbol.
    /// - A number written in Arabic numerals can be broken into digits.
    /// </summary>
    public class RomanCalculator
    {
        private Dictionary<char, int> ValueSet = new Dictionary<char, int>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };
        public int RomanToInt(string roman)
        {
            Validate(roman);
            int total = 0;
            for (int i = 0; i< roman.Length; i++)
            {

            }
            return total;
        }

        private void Validate(string roman)
        {
            if(new Regex(@"[^IVXLCDM]", RegexOptions.IgnoreCase).IsMatch(roman))
            {
                throw new Exceptions.CalculatorException("Invalid symbol exception");
            }
            if (new Regex(@"(IIII+)|(XXXX+)|(CCCC+)|(MMMM+)|(DD+)|(LL+)|(VV+)", RegexOptions.IgnoreCase).IsMatch(roman))
            {
                throw new Exceptions.CalculatorException("Invalid symbol repetitions");
            }
            if (new Regex(@"(I(L||C|D|M))|(X(D|M))|(V(X|L|C|D|M))|(L(C|D|M))|DM", RegexOptions.IgnoreCase).IsMatch(roman))
            {
                throw new Exceptions.CalculatorException("Invalid symbol sequence");
            }
        }
    }
}
