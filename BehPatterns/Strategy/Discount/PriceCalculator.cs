using System;

namespace BehPatterns.Strategy.Discount
{
    public class PriceCalculator
    {
        private DiscountType _type;
        private decimal _seasonalPercent;

        public void SetDiscount(DiscountType type, decimal seasonalPercent = 0)
        {
            _type = type;
            _seasonalPercent = seasonalPercent;
        }

        public decimal CalculateFinalPrice(decimal basePrice, string customerId)
        {
            decimal discount = _type switch
            {
                DiscountType.None        => 0,
                DiscountType.Seasonal    => basePrice * _seasonalPercent / 100m,
                DiscountType.Vip         => customerId.StartsWith("VIP") ? basePrice * 0.2m : 0,
                DiscountType.Progressive => ProgressiveDiscount(basePrice),
                _ => 0
            };

            var finalPrice = basePrice - discount;
            Console.WriteLine($"Базовая цена: {basePrice:C} → Скидка: {discount:C} → Итого: {finalPrice:C}");
            return finalPrice;
        }

        private static decimal ProgressiveDiscount(decimal basePrice)
        {
            decimal pct = 0;
            if (basePrice > 10000) pct = 5;
            if (basePrice > 50000) pct = 10;
            if (basePrice > 100000) pct = 15;
            return basePrice * pct / 100m;
        }
    }
}
