using System;
using Common.DataTypes.Enums;

namespace Common.DataTypes.Services.InventoryService
{
    public class SetFilmUnavailableCommand
    {
        public Guid FilmId { get; set; }
    }

    public class SetFilmUnavailableCommandResponse
    {
        public ResultType Result { get; set; }
        public string Message { get; set; }
    }
}
