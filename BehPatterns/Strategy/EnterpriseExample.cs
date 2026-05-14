using System;

namespace BehPatterns.Strategy.Enterprise
{
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

    public interface IDiscountStrategy
    {
        decimal CalculateDiscount(decimal basePrice, string customerId);
    }

    // 1. Без скидки
    public class NoDiscountStrategy : IDiscountStrategy
    {
        public decimal CalculateDiscount(decimal basePrice, string customerId) => 0;
    }

    // 2. Сезонная скидка (фиксированный процент)
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

    // 3. VIP-клиент (скидка зависит от ID клиента)
    public class VipDiscountStrategy : IDiscountStrategy
    {
        // ID VIP-клиентов
        private readonly decimal _vipDiscountPercent = 20m;

        public decimal CalculateDiscount(decimal basePrice, string customerId)
        {
            if (customerId.StartsWith("VIP"))
            {
                return basePrice * _vipDiscountPercent / 100m;
            }
            return 0;
        }
    }

    // 4. Прогрессивная скидка (чем больше сумма, тем больше скидка)
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

    // 5. Стратегия с промокодом
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

    // 6. Комбинированная стратегия (применяет несколько)
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

    // === Клиентский код ===

    public class PricingDemo
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