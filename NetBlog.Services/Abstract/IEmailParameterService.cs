using NetBlog.Core.Entities.Concrete;
using NetBlog.Core.Utilities.Results.Abstract;

namespace NetBlog.Business.Abstract
{
    public interface IEmailParameterService
    {
        Task<IDataResult<IList<EmailParameter>>> GetAllAsync();
        Task<IDataResult<EmailParameter>> GetAsync(int id);
        Task<IResult> SendEmail(EmailParameter emailParameter, string body, string subject, string emails);
    }
}
