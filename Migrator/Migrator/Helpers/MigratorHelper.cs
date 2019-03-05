using System;
using Common.Redis;

namespace Migrator.Helpers
{
    public static class MigratorHelper
    {
        private static RedisProxy redisProxy => Redis.Get();

        public static void Migrate<T>(T obj)
        {
            redisProxy.Set<T>(obj);
        }
    }
}
