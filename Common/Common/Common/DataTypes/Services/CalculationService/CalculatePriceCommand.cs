using System;
using Common.DataTypes.Enums;

namespace Common.DataTypes.Services.CalculationService
{
    public class CalculatePriceCommand
    {
        public Guid UserId { get; set; }
        public Guid FilmId { get; set; }
        public DateTime ActiveFrom { get; set; }
        public DateTime ActiveTo { get; set; }
        public int BonusPoints { get; set; }
        public FilmType Type { get; set; }
        public bool UseBonuses { get; set; }
        public int OrderId { get; set; }
    }

    public class CalculatePriceCommandResponse
    {
        public ResultType Result { get; set; }
        public string Message { get; set; }
    }
}
