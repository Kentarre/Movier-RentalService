using System;
using System.Linq;
using Common.DataTypes.Dto;
using Common.Redis;

namespace Main.Helpers
{
    public static class DbMethods
    {
        private static RedisProxy rProxy => Redis.Get();

        public static int GetNextOrderId()
        {
            var allRentals = rProxy.GetAll<Rent>();
            var rentalsSorted = allRentals?.OrderByDescending(x => x.OrderId).ToList();

            if (rentalsSorted.Count == 0)
                return 1;

            var lastOrderId = rentalsSorted.First().OrderId;

            return lastOrderId + 1;
        }
    }
}
