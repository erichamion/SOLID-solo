namespace CreditCardInterest
{
    public interface ICreditCard : IInterestBearingAccount
    {
        string Name { get; }        
    }
}