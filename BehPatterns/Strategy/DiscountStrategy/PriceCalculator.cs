using System;

namespace BehPatterns.Strategy.DiscountStrategy
{
    // Context — контекст, использующий стратегию. Хранит текущую стратегию
    // и делегирует ей расчёт. Стратегию можно менять в рантайме через SetDiscountStrategy.
    public class PriceCalculator
    {
        private IDiscountStrategy _discountStrategy;

        public void SetDiscountStrategy(IDiscountStrategy strategy)
        {
            _discountStrategy = strategy;
        }

        public decimal CalculateFinalPrice(decimal basePrice, string customerId)
        {
            var discount = _discountStrategy.CalculateDiscount(basePrice, customerId);
            var finalPrice = basePrice - discount;
            Console.WriteLine($"Базовая цена: {basePrice:C} → Скидка: {discount:C} → Итого: {finalPrice:C}");
            return finalPrice;
        }
    }
}
