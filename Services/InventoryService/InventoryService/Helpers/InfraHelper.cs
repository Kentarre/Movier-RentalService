using System;
using Common.DataTypes.Dto;
using Common.Redis;

namespace InventoryService.Helpers
{
    public static class InfraHelper
    {
        private static RedisProxy rProxy => Redis.Get();

        public static Film GetFilm(Guid filmId)
        {
            return rProxy.Get<Film>(filmId);
        }

        public static void UpdateFilm(Film film)
        {
            rProxy.Set<Film>(film);
        }

        public static void RemoveFilm(Guid filmId)
        {
            rProxy.Delete(filmId);
        }

        public static void AddFilm(Film film)
        {
            rProxy.Set<Film>(film);
        }
    }
}
