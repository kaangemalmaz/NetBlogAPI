using Castle.Components.DictionaryAdapter.Xml;
using NetBlog.Business.Abstract;
using NetBlog.Business.Constants;
using NetBlog.Core.Aspects.Performance;
using NetBlog.Core.Aspects.Secured;
using NetBlog.Core.Entities.Concrete;
using NetBlog.Core.Utilities.Business;
using NetBlog.Core.Utilities.Results.Abstract;
using NetBlog.Core.Utilities.Results.Concrete;
using NetBlog.DataAccess.Abstract;
using System.Net;
using System.Net.Mail;

namespace NetBlog.Business.Concrete
{
    public class EmailParameterManager : IEmailParameterService
    {
        private readonly IEmailParameterDal _emailParameterDal;

        public EmailParameterManager(IEmailParameterDal emailParameterDal)
        {
            _emailParameterDal = emailParameterDal;
        }

        public async Task<IDataResult<IList<EmailParameter>>> GetAllAsync()
        {
            try
            {
                IList<EmailParameter> emailParameters = await _emailParameterDal.GetAllAsync();

                if (emailParameters.Count == 0) return new ErrorDataResult<IList<EmailParameter>>(EmailParameterMessages.NotFoundData);

                return new SuccessDataResult<IList<EmailParameter>>(emailParameters);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<IList<EmailParameter>>();
            }
        }

        public async Task<IDataResult<EmailParameter>> GetAsync(int id)
        {
            try
            {

                EmailParameter emailParameter = await _emailParameterDal.GetAsync(i => i.Id == id);
                if (emailParameter == null) return new SuccessDataResult<EmailParameter>(EmailParameterMessages.NotFoundData);

                return new SuccessDataResult<EmailParameter>(emailParameter);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<EmailParameter>();
            }
        }

        public async Task<IResult> SendEmail(EmailParameter emailParameter, string body, string subject, string emails)
        {
            try
            {
                using (MailMessage message = new MailMessage())
                {
                    string[] setEmails = emails.Split(",");

                    message.From = new MailAddress(emailParameter.Email);

                    foreach (var email in setEmails)
                    {
                        message.To.Add(email);
                    }

                    message.Subject = subject;
                    message.Body = body;
                    message.IsBodyHtml = emailParameter.Html;

                    using (SmtpClient client = new SmtpClient())
                    {
                        client.Port = emailParameter.Port;
                        client.EnableSsl = emailParameter.SSL;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential(emailParameter.Email, emailParameter.Password);
                        await client.SendMailAsync(message);
                    }

                    return new SuccessResult(EmailParameterMessages.SuccessSend);
                }
            }
            catch (Exception)
            {
                return new ErrorResult(EmailParameterMessages.ErrorSend);
            }
            
        }
    }
}
