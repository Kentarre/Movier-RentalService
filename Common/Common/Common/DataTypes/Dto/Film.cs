using System;
using Common.DataTypes.Enums;
using Common.Redis;

namespace Common.DataTypes.Dto
{
    public class Film : IRedisEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public FilmType Type { get; set; }
        public bool IsAvailable { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }
    }
}
