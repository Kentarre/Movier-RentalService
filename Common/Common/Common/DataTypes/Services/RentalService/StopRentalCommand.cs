using System;
using Common.DataTypes.Enums;

namespace Common.DataTypes.Services.RentalService
{
    public class StopRentalCommand
    {
        public Guid RentId { get; set; }
    }

    public class StopRentalCommandResponse
    {
        public ResultType Result { get; set; }
        public string Message { get; set; }
    }
}
