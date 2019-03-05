using System;
using Common.DataTypes.Enums;
using Common.DataTypes.Services.RentalService;
using ServiceStack;

namespace RentalService
{
    public class RentalService : Service
    {
        public object Any(RentalServiceTestCommand command)
        {
            return new RentalServiceTestCommandResponse { Result = "OK" };
        }

        public object Any(AnotherRentalServiceTestCommand command)
        {
            return new AnotherRentalServiceTestCommandResponse { Result = "OK" };
        }

        public object Any(StartRentalCommand command)
        {
            return new StartRentalCommandResponse { Result = ResultType.OK };
        }

        public object Any(StopRentalCommand command)
        {
            return new StopRentalCommandResponse { Result = ResultType.OK };
        }
    }
}
