using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    //hedef attributler, classlar metodlar, attribute ü birden fazla ekleyebilirsin. inherite edilen yerde çalışsın
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }  //öncelik demek

        public virtual void Intercept(IInvocation invocation)  //Intercept: yakalama, kesme
        {

        }
    }

}
