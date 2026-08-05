using System;

using BehPatterns.Strategy.DiscountStrategy.Strategies;

namespace BehPatterns.Strategy.DiscountStrategy
{
    // Клиентский код: демонстрирует расчёт цены с разными стратегиями
    // и смену стратегии в рантайме.
    public class DiscountingDemoStrategy
    {
        public static void Run()
        {
            var calculator = new PriceCalculator();
            const decimal price = 50000m;
            const string customerId = "VIP-001";

            Console.WriteLine($"Товар: Ноутбук, Цена: {price:C}\n");

            // 1. Без скидки
            Console.WriteLine("--- Без скидки ---");
            calculator.SetDiscountStrategy(new NoDiscountStrategy());
            calculator.CalculateFinalPrice(price, customerId);

            // 2. Сезонная
            Console.WriteLine("\n--- Сезонная скидка 15% ---");
            calculator.SetDiscountStrategy(new SeasonalDiscountStrategy(15));
            calculator.CalculateFinalPrice(price, customerId);

            // 3. VIP
            Console.WriteLine("\n--- VIP-клиент ---");
            calculator.SetDiscountStrategy(new VipDiscountStrategy());
            calculator.CalculateFinalPrice(price, customerId);

            // 4. Прогрессивная
            Console.WriteLine("\n--- Прогрессивная ---");
            calculator.SetDiscountStrategy(new ProgressiveDiscountStrategy());
            calculator.CalculateFinalPrice(price, customerId);

            // 5. Комбинированная (сезонная + VIP)
            Console.WriteLine("\n--- Комбинированная (сезонная + VIP) ---");
            var composite = new CompositeDiscountStrategy(
                new SeasonalDiscountStrategy(10),
                new VipDiscountStrategy()
            );
            calculator.SetDiscountStrategy(composite);
            calculator.CalculateFinalPrice(price, customerId);

            // 6. В рантайме меняем стратегию
            Console.WriteLine("\n--- Смена стратегии в рантайме ---");
            calculator.SetDiscountStrategy(new NoDiscountStrategy());
            calculator.CalculateFinalPrice(price, customerId);

            calculator.SetDiscountStrategy(new ProgressiveDiscountStrategy());
            calculator.CalculateFinalPrice(price, customerId);
        }
    }
}
