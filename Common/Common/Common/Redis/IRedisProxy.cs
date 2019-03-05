using System;
using System.Collections.Generic;

namespace Common.Redis
{
    public interface IRedisProxy
    {
        void Set(Guid id, string value);
        void Set<T>(T value);
        string Get(Guid id);
        T Get<T>(Guid id);
        void Delete(Guid id);
        IEnumerable<T> GetAll<T>();
    }
}
