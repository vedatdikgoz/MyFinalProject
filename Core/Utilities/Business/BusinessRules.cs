using Core.Utilities.Results;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics) //Birden çok IResult gönderebilmek için params kullanılır.
        {
            foreach (var logic in logics) //logic:iş kuralı
            {
                if (!logic.Success)
                {
                    return logic;  //başarısız ise logic i dön. error result dön. yani bu logic hata demek için logic döndürüyoruz.
                }
            }

            return null;
        }


    }
}
