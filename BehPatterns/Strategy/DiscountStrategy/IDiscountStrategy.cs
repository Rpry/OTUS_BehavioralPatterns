namespace BehPatterns.Strategy.DiscountStrategy
{
    // Интерфейс стратегии: алгоритм расчёта скидки.
    public interface IDiscountStrategy
    {
        decimal CalculateDiscount(decimal basePrice, string customerId);
    }
}
