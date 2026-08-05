using System;

namespace BehPatterns.Strategy.Discount
{
    public class DiscountDemo
    {
        public static void Run()
        {
            var calculator = new PriceCalculator();
            const decimal price = 50000m;
            const string customerId = "VIP-001";

            Console.WriteLine($"Товар: Ноутбук, Цена: {price:C}\n");

            Console.WriteLine("--- Без скидки ---");
            calculator.SetDiscount(DiscountType.None);
            calculator.CalculateFinalPrice(price, customerId);

            Console.WriteLine("\n--- Сезонная скидка 15% ---");
            calculator.SetDiscount(DiscountType.Seasonal, seasonalPercent: 15);
            calculator.CalculateFinalPrice(price, customerId);

            Console.WriteLine("\n--- VIP-клиент ---");
            calculator.SetDiscount(DiscountType.Vip);
            calculator.CalculateFinalPrice(price, customerId);

            Console.WriteLine("\n--- Прогрессивная ---");
            calculator.SetDiscount(DiscountType.Progressive);
            calculator.CalculateFinalPrice(price, customerId);

            Console.WriteLine("\n--- Смена скидки в рантайме ---");
            calculator.SetDiscount(DiscountType.None);
            calculator.CalculateFinalPrice(price, customerId);
            calculator.SetDiscount(DiscountType.Progressive);
            calculator.CalculateFinalPrice(price, customerId);
        }
    }
}
