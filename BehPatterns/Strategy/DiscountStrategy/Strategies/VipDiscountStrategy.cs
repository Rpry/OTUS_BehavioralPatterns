namespace BehPatterns.Strategy.DiscountStrategy.Strategies
{
    // 3. VIP-клиент (скидка зависит от ID клиента).
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
}
