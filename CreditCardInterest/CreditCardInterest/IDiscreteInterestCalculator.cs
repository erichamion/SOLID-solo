namespace CreditCardInterest
{
    public interface IDiscreteInterestCalculator
    {
        PrincipalInterestBalance CalculateInterest(double startingPrincipal, double ratePerPeriod, int periods);
    }
}