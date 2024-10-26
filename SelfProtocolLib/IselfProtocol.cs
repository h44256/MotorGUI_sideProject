using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfProtocolLib
{
    internal interface ISelfProtocol
    {
        string silenceDeviceID();
        string sendDeviceID(int send_DeviceID);
        byte[] cmdHandShake();
        byte[] cmdWriteData();
        byte[] cmdEnd();
        void handShake();
        byte[] writeData();
        //bool end();
        ushort Crc16AugCcitt(byte[] data, int length);

        bool checkDeviceID(int send_DeviceID, string reply_DeviceID);

    }
}
