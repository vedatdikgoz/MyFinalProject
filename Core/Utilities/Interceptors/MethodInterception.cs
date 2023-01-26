using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        //invocation :  business method
        protected virtual void OnBefore(IInvocation invocation) { } //metodun başı
        protected virtual void OnAfter(IInvocation invocation) { }  //metodun sonu
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }  //metod başarısız olursa, hata fırlatırsa
        protected virtual void OnSuccess(IInvocation invocation) { } //metod başarılı olursa
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }

}
