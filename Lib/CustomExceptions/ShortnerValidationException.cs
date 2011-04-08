using System;
using System.Collections.Generic;

namespace MyPersonalShortner.Lib.CustomExceptions
{
    public class ShortnerValidationException : Exception
    {
        public List<string> Errors { get; set; }
        public ShortnerValidationException(List<string> errors) : base("Validation error")
        {
            Errors = errors;
        }
    }
}
