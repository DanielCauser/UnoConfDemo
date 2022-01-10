using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnoConfDemo.Messages
{
    public class BarcodeChangedMessage  //: ValueChangedMessage
    {
        public string  NewBarcodeValue { get; private set; }

        public BarcodeChangedMessage(string newBarCode)
        {
            NewBarcodeValue = newBarCode;
        }
    }
}
