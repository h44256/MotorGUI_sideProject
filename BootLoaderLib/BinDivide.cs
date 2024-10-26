using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinDIvideLib
{
    public class BinDivide:abs_BinDivide
    {
        public BinDivide(string sourceFilePath, string outputFilePath, int divideByte)
        {
            this.sourceFilePath = sourceFilePath;
            this.outputFIlePath = outputFilePath;
            this.divideByte = divideByte;
        }
        public BinDivide(string sourceFilePath, int divideByte)
        {
            this.sourceFilePath = sourceFilePath;
            this.divideByte = divideByte;
        }
        public BinDivide() 
        {
            
        }
    }
}
