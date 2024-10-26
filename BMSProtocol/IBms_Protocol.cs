using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSProtocol
{
    internal interface IBms_Protocol
    {
        byte BMS_ID{get;set;}
        byte[] Bms_cmdSetID(byte ID);
        byte Bms_cmdSetIDReply(byte[] replyIDSet);
        byte[] Bms_cmdReadID();
        byte Bms_cmdReadIDReply(byte[] IDBytes);
    }
}
