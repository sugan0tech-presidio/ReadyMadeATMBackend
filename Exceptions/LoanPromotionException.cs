namespace ReadyMadeATMBackend.Exceptions;

public class LoanPromotionException: Exception
{
    public LoanPromotionException()
    {
    }

    public LoanPromotionException(string? message) : base(message)
    {
    }
}