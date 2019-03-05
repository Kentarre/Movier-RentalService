using System;
namespace Common.DataTypes.Dto
{
    public class File
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public byte[] FileBytes { get; set; }
    }
}
