using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
#if __ANDROID__ || NETFX_CORE
using ZXing;
using ZXing.Mobile;
#endif

namespace UnoConfDemo
{
    public class BarCodeReaderService : IBarCodeReaderService
    {
        public async Task ReadBarCode()
        {
#if __ANDROID__ || NETFX_CORE
            var scanner = new MobileBarcodeScanner();
            var result = await scanner.Scan();

            Debug.Write($"Value Scanned!: {result.Text}");
#elif __WASM__
            Debug.Write($"Not implemented with ZXING lib :(");
#endif
        }
    }
}