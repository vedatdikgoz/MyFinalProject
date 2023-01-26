using Castle.DynamicProxy;
using System.Reflection;
using Core.Aspects.Autofac.Exception;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;

namespace Core.Utilities.Interceptors
{

    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute> //class ın attribute lerini oku
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)   //method un attribute lerini oku
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);    //okunan attribute leri listeye koy
            classAttributes.Add(new LogAspect(typeof(FileLogger)));

            return classAttributes.OrderBy(x => x.Priority).ToArray();  //çalışmasını öncelik değerine göre sırala
        }
    }

}
