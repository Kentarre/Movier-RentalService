using System;
using Common.DataTypes.Enums;

namespace Common.DataTypes.Services.InventoryService
{
    public class SetFilmAvailableCommand
    {
        public Guid FilmId { get; set; }
    }

    public class SetFilmAvailableCommandResponse
    {
        public ResultType Result { get; set; }
        public string Message { get; set; }
    }
}
