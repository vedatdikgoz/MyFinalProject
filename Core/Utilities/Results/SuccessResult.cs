namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        public SuccessResult(string message) : base(true, message) //base=Result , yani result a true ve message gönderir
        {

        }

        public SuccessResult():base(true)  //message olmadan, base e sadece true gönderir
        {

        }
    }
}
