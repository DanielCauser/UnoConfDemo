using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnoConfDemo
{
    public interface IBarCodeReaderService
    {
        Task ReadBarCode();
    }
}
