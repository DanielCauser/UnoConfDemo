using System;
using System.Collections.Generic;
using System.Text;

namespace UnoConfDemo.Messages
{
    public class BarcodeChangedMessage
    {
        public string NewBarcodeValue { get; private set; }

        public BarcodeChangedMessage(string newBarCode)
        {
            NewBarcodeValue = newBarCode;
        }
    }
}
