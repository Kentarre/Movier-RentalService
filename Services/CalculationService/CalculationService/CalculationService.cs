using System;
using Common.DataTypes.Enums;
using Common.DataTypes.Services.CalculationService;
using ServiceStack;

namespace CalculationService
{
    public class CalculationService : Service
    {
        public object Any(CalculatePriceCommand command)
        {
            return new CalculatePriceCommandResponse { Result = ResultType.OK };
        }
    }
}
