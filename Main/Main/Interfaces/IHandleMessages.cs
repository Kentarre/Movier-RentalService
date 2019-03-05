using System;
using ServiceStack.Messaging;

namespace Main.Interfaces
{
    public interface IHandleMessages
    {
        void HandleMessage(IMessage mqMessage);
    }
}
