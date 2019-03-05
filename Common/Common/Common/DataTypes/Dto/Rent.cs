using System;
using Common.Redis;

namespace Common.DataTypes.Dto
{
    public class Rent : IRedisEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid FilmId { get; set; }
        public decimal Price { get; set; }
        public DateTime ActiveFrom { get; set; }
        public DateTime ActiveTo { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public bool UseBonus { get; set; }
        public int OrderId { get;set; }

        public bool IsRented => ReturnedDate == null;
        public bool IsDue => ReturnedDate == null && ActiveTo < DateTime.Now;
    }
}
