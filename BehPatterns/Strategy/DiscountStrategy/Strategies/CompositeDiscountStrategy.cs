using System;

namespace BehPatterns.Strategy.DiscountStrategy.Strategies
{
    // 6. Комбинированная стратегия (применяет несколько).
    public class CompositeDiscountStrategy : IDiscountStrategy
    {
        private readonly IDiscountStrategy[] _strategies;

        public CompositeDiscountStrategy(params IDiscountStrategy[] strategies)
        {
            _strategies = strategies;
        }

        public decimal CalculateDiscount(decimal basePrice, string customerId)
        {
            decimal totalDiscount = 0;
            foreach (var strategy in _strategies)
            {
                totalDiscount += strategy.CalculateDiscount(basePrice, customerId);
            }
            // Но не более 50%
            return Math.Min(totalDiscount, basePrice * 0.5m);
        }
    }
}
