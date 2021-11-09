#if __WASM__
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Messaging;
using System.Diagnostics;
using Uno.Extensions;
using UnoConfDemo.Messages;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using Uno.UI.Runtime.WebAssembly;

namespace UnoConfDemo.Views
{
    public class BarCodeScanner
    {
        private void OnBarCodeDetected(object sender, HtmlCustomEventArgs e)
        {
            Debug.WriteLine($"Barcode scanned and Invoked from C#! {e.Detail}");

            var container = ((App)App.Current).Container;
            var service = (IMessenger)ActivatorUtilities.GetServiceOrCreateInstance(container, typeof(IMessenger));
            service.Send(new BarcodeChangedMessage(e.Detail));
        }
    }
}
#endif