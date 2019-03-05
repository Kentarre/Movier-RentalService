using System;
using Common.DataTypes.Enums;

namespace Common.DataTypes.Services.FileService
{
    public class CreateInvoiceCommand
    {
        public Guid UserId { get; set; }
    }

    public class CreateInvoiceCommandResponse
    {
        public ResultType Result { get; set; }
        public byte[] InvoiceFile { get; set; }
        public string Message { get; set; }
    }
}
