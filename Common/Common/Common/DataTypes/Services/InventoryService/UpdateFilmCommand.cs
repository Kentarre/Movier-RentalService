using System;
using Common.DataTypes.Dto;
using Common.DataTypes.Enums;

namespace Common.DataTypes.Services.InventoryService
{
    public class UpdateFilmCommand
    {
        public Guid FilmId { get;set; }
        public Film Film { get; set; }
    }

    public class UpdateFilmCommandResponse
    {
        public ResultType Result { get; set; }
        public string Message { get; set; }
    }
}
