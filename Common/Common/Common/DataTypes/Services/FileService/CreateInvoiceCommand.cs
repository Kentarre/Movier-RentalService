using System;
using System.Security.Cryptography;
using Common.DataTypes.Enums;

namespace Common.DataTypes.Services.FileService
{
    public class CreateInvoiceCommand
    {
        public int OrderId { get; set; }
    }

    public class CreateInvoiceCommandResponse
    {
        public ResultType Result { get; set; }
        public string Message { get; set; }
    }
}
