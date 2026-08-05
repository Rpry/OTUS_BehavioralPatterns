using System;

namespace BehPatterns.Strategy.DiscountStrategy.Strategies
{
    // 5. Стратегия с промокодом.
    public class PromoCodeStrategy : IDiscountStrategy
    {
        private readonly string _validCode;
        private readonly decimal _discountPercent;

        public PromoCodeStrategy(string validCode, decimal discountPercent)
        {
            _validCode = validCode;
            _discountPercent = discountPercent;
        }

        public decimal CalculateDiscount(decimal basePrice, string customerId)
        {
            // В реальном приложении код бы передавался отдельно
            // Здесь для примера - скидка по праздникам
            if (DateTime.Now.Month == 12) // Декабрь
            {
                return basePrice * _discountPercent / 100m;
            }
            return 0;
        }
    }
}
