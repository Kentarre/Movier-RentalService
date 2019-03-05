using System;
using Common.Redis;

namespace Common.DataTypes.Dto
{
    public class User : IRedisEntity
    {
        public User()
        {
            Contact = new Contact();
        }

        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Contact Contact { get; set; }
        public int AvailableBonus { get; set; }
    }
}
