using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception //Aspect
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //defensive coding
            if (!typeof(IValidator).IsAssignableFrom(validatorType)) //gönderilen validatorType, IValidator değil ise hata göster
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);   //reflection  //Çalışma anında validator un instance ını oluştur.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];    //validator un çalışma tipini bul. Yani ProductValidator:AbstractValidator<Product> generek argumanın ilki: Product
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); //Metodun parametrelerini bul,validatorın tipine eşit olanları getir. Yani public IResult Add(Product product) parametresi: Product
            foreach (var entity in entities)  //bulduğu parametreleri tek tek gez.
            {
                ValidationTool.Validate(validator, entity); //ValidationTool u kullanarak validate et.
            }
        }

        
    }
}
