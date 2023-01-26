namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        public Result(bool success, string message):this(success)    //this(success) demek result ın tek parametreli constructor ına success i yolla
        {
            Message = message;
        }

        public Result(bool success) //message vermek istenmez ise bu çalışır.
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; } //getter lar readonly olduğu için constructor lar set edilebilirler.
    }
}
