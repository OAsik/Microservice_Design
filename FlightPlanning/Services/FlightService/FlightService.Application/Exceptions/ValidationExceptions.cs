using System;
using System.Linq;
using FluentValidation.Results;
using System.Collections.Generic;

namespace FlightService.Application.Exceptions
{
    public class ValidationExceptions : ApplicationException
    {
        public Dictionary<string, string[]> Errors { get; }

        public ValidationExceptions() : base("One or more validation failures occured")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationExceptions(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures.GroupBy(x => x.PropertyName, y => y.ErrorMessage).ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }
    }
}