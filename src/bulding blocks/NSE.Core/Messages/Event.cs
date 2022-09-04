using MediatR;
using NSE.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSE.Core.Messages
{
    public class Event : Message, INotification
    {
    }
}
