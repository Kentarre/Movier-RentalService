using System;
using Common.DataTypes.Enums;

namespace Common.DataTypes.Services.InventoryService
{
    public class RemoveFilmCommand
    {
        public Guid FilmId { get; set; }
    }

    public class RemoveFilmCommandResponse
    {
        public ResultType Result { get; set; }
        public string Message { get; set; }
    }
}
