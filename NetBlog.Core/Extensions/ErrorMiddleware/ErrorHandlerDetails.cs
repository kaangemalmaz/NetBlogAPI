using FluentValidation.Results;
using Newtonsoft.Json;

namespace NetBlog.Core.Extensions.ErrorMiddleware
{
    public class ErrorHandlerDetails
    {
        public string Messages { get; set; }
        public int StatusCode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class ValidationErrorDetails : ErrorHandlerDetails
    {
        public IEnumerable<ValidationFailure> Errors { get; set; }
    }

}
