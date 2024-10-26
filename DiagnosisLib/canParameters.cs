using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace canDiagnosisLib
{
    public class canParameters
    {
        public byte[] testAdcBytes = new byte[8];

        public ushort[] getADC(byte[] bytes)
        {
            ushort[] testADC = new ushort[2];
            for (int i = 2; i < bytes.Length/2; i++) 
            {
                ushort highByte = (ushort)(bytes[i*2+1] << 8);
                ushort lowByte = (ushort)(bytes[i*2] & 0xFF);
                ushort combine = (ushort)(highByte + lowByte);
                testADC[i-2] = combine;
            }
            return testADC;
        }


        public ushort[] getADC2(byte[] bytes)
        {
            ushort[] testADC = new ushort[4];
            for (int i = 0; i < bytes.Length / 2; i++)
            {
                ushort highByte = (ushort)(bytes[i * 2 + 1] << 8);
                ushort lowByte = (ushort)(bytes[i * 2] & 0xFF);
                ushort combine = (ushort)(highByte + lowByte);
                testADC[i] = combine;
            }
            return testADC;
        }
    }
}
