using System;
namespace Common.Redis
{
    public interface IRedisEntity
    {
        Guid Id { get; set; }
    }
}
