using NetBlog.Core.Utilities.Results.Abstract;

namespace NetBlog.Core.Utilities.Results.Concrete
{
    public class DataResult<T> : IDataResult<T>
    {
        public T Data { get; }

        public ResultStatus ResultStatus { get; }

        public string Message { get; }

        public Exception Exception { get; }

        public DataResult(T data, ResultStatus resultStatus)
        {
            Data = data;
            ResultStatus = resultStatus;
        }

        public DataResult(T data, ResultStatus resultStatus, string message)
        {
            Data = data;
            ResultStatus = resultStatus;
            Message = message;
        }

        public DataResult(T data, ResultStatus resultStatus, string message, Exception exception)
        {
            Data = data;
            ResultStatus = resultStatus;
            Message = message;
            Exception = exception;
        }
    }
}
