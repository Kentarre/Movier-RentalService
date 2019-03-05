using System;
using Common.DataTypes.Dto;
using Common.DataTypes.Enums;

namespace Common.DataTypes.Services.InventoryService
{
    public class AddFilmCommand
    {
        public Film Film { get; set; }
    }

    public class AddFilmCommandResponse
    {
        public ResultType Result { get; set; }
        public string Message { get; set; }
    }
}
