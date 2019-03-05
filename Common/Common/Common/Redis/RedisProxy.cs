using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack.Redis;

namespace Common.Redis
{
    public static class Redis
    {
        public static RedisProxy Get()
        {
            return new RedisProxy();
        }
    }

    public class RedisProxy : IRedisProxy
    {
        public void Delete(Guid id)
        {
            using (var client = new RedisClient())
            {
                client.Remove(id.ToString());
            }
        }

        public string Get(Guid id)
        {
            using (var client = new RedisClient())
            {
                var result = client.Get(id.ToString());

                return Encoding.UTF8.GetString(result);
            }
        }

        public IEnumerable<T> GetAll<T>()
        {
            using (var client = new RedisClient())
            {
                var typedClient = client.As<T>();

                return typedClient.GetAll();
            }
        }

        public T Get<T>(Guid id)
        {
            using(var client = new RedisClient())
            {
                var typedClient = client.As<T>();

                return typedClient.GetById(id);
            }
        }

        public void Set(Guid id, string value)
        {
            using (var client = new RedisClient())
            {
                var valueBytes = Encoding.UTF8.GetBytes(value);

                client.Set(id.ToString(), valueBytes);
            }
        }

        public void Set<T>(T value)
        {
            using (var client = new RedisClient())
            {
                var typedClient = client.As<T>();

                typedClient.Store(value);
            }
        }
    }
}
