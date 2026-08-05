namespace BehPatterns.Strategy.DiscountStrategy.Strategies
{
    // 1. Без скидки.
    public class NoDiscountStrategy : IDiscountStrategy
    {
        public decimal CalculateDiscount(decimal basePrice, string customerId) => 0;
    }
}
