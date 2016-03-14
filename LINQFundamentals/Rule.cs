using System;

namespace LINQFundamentals
{
    public class Rule<T>
    {
        public Func<T, bool> Test { get; set; }
        public string Message { get; set; }
    }
}
