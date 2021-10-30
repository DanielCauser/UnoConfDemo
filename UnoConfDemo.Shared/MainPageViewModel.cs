using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UnoConfDemo
{
    public class MainPageViewModel
    {
        private readonly IBarCodeReaderService _barCodeService;

        public IAsyncRelayCommand ScanBarCodeCommand { get; }

        public MainPageViewModel(IBarCodeReaderService barCodeService)
        {
            _barCodeService = barCodeService;
            ScanBarCodeCommand = new AsyncRelayCommand(ScanBarCode);
        }

        private Task ScanBarCode()
        {
            Debug.WriteLine("Hey, lets scan a bar code?");
            return Task.CompletedTask;
        }
    }
}
