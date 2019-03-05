using System;
using Common.DataTypes.Enums;
using Common.DataTypes.Services.InventoryService;
using ServiceStack;

namespace InventoryService
{
    public class InvenotryService : Service
    {
        public object Any(SetFilmAvailableCommand command)
        {
            return new SetFilmAvailableCommandResponse { Result = ResultType.OK };
        }

        public object Any(SetFilmUnavailableCommand command)
        {
            return new SetFilmUnavailableCommandResponse { Result = ResultType.OK };
        }

        public object Any(UpdateFilmCommand command)
        {
            return new UpdateFilmCommandResponse { Result = ResultType.OK };
        }

        public object Any(RemoveFilmCommand command)
        {
            return new RemoveFilmCommandResponse { Result = ResultType.OK };
        }

        public object Any(AddFilmCommand command)
        {
            return new AddFilmCommandResponse { Result = ResultType.OK };
        }
    }
}
