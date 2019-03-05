using System;
using Common.DataTypes.Dto;
using Common.Redis;

namespace RentalService.Helpers
{
    public static class InfraHelper
    {
        private static RedisProxy rProxy => Redis.Get();

        public static User GetUser(Guid userId)
        {
            return rProxy.Get<User>(userId);
        }

        public static void UpdateUser(User user)
        {
            rProxy.Set<User>(user);
        }

        public static void UpdateRent(Rent rent)
        {
            rProxy.Set<Rent>(rent);
        }

        public static Rent GetRent(Guid rentId)
        {
            return rProxy.Get<Rent>(rentId);
        }

        public static Film GetFilm(Guid filmId)
        {
            return rProxy.Get<Film>(filmId);
        }
    }
}
