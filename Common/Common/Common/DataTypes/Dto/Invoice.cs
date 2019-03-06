using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DataTypes.Dto
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int OrderId { get; set; }
        public  byte[] FileBytes { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
