using Castle.DynamicProxy;
using NetBlog.Core.Utilities.Interceptors;
using System.Transactions;

namespace NetBlog.Core.Aspects.Transaction
{
    public class TransactionAspect : MethodInterception
    {
        //genellikle birden fazla tabloya veya birden fazla işlemin aynı anda yapıldığı metodlarda gözükür.
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete();

                }
                catch (Exception e)
                {
                    transactionScope.Dispose();
                    throw new Exception("İşlemler sırasında bir hata oluştu", e);
                }
            }
        }
    }
}
