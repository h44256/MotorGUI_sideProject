using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinDIvideLib
{
    public interface IBinDivide
    {
        //設定來源"檔案"的路徑
        string sourceFilePath { get; set; }
        //設定切割後"資料夾"的路徑
        string outputFIlePath { get; set; }
        int divideByte { get; set; }
    }
}
