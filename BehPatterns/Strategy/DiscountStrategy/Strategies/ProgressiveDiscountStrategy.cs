namespace BehPatterns.Strategy.DiscountStrategy.Strategies
{
    // 4. Прогрессивная скидка (чем больше сумма, тем больше скидка).
    public class ProgressiveDiscountStrategy : IDiscountStrategy
    {
        public decimal CalculateDiscount(decimal basePrice, string customerId)
        {
            decimal discount = 0;
            if (basePrice > 10000) discount = 5;      // 5% от 10000+
            if (basePrice > 50000) discount = 10;     // 10% от 50000+
            if (basePrice > 100000) discount = 15;    // 15% от 100000+
            return basePrice * discount / 100m;
        }
    }
}
