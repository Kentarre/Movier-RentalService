using System;
using System.Collections.Generic;
using System.Text;
using Common.DataTypes.Enums;
using Common.DataTypes.Services.FileService;
using ServiceStack;

namespace FileService
{
    public class FileService : Service
    {
        public object Any(CreateInvoiceCommand command)
        {
            return new CreateInvoiceCommandResponse { Result = ResultType.OK };
        }
    }
}
