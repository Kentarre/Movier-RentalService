using System;
using Common.DataTypes.Enums;

namespace Common.DataTypes.Services.RentalService
{
    public class StartRentalCommand
    {
        public Guid FilmId { get; set; }
        public Guid UserId { get; set; }
        public DateTime ActiveFrom { get; set; }
        public DateTime ActiveTo { get; set; }
        public bool UseBonuses { get; set; }
        public int OrderId { get; set; }
    }

    public class StartRentalCommandResponse
    {
        public ResultType Result { get; set; }
        public string Message { get; set; }
    }
}
