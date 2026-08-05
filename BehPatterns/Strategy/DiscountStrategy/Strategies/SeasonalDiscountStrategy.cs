namespace BehPatterns.Strategy.DiscountStrategy.Strategies
{
    // 2. Сезонная скидка (фиксированный процент).
    public class SeasonalDiscountStrategy : IDiscountStrategy
    {
        private readonly decimal _discountPercent; // например 10%

        public SeasonalDiscountStrategy(decimal discountPercent)
        {
            _discountPercent = discountPercent;
        }

        public decimal CalculateDiscount(decimal basePrice, string customerId)
        {
            return basePrice * _discountPercent / 100m;
        }
    }
}
