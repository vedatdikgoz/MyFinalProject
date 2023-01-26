namespace Core.Utilities.Results
{
    //Temel voidler için başlangıç
    public interface IResult
    {
        bool Success { get; } //get yazarsak sadece okunabilir demek.
        string Message { get; }

    }
}
