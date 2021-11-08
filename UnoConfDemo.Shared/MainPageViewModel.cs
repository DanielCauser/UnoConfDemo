using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UnoConfDemo.Messages;

namespace UnoConfDemo
{
    public class MainPageViewModel : ObservableObject
    {
        private readonly IBarCodeReaderService _barCodeService;

        public IAsyncRelayCommand ScanBarCodeCommand { get; }

        private string _barCodeValue;

        public string BarCodeValue
        {
            get => _barCodeValue;
            set => SetProperty(ref _barCodeValue, value);
        }

        public MainPageViewModel(IBarCodeReaderService barCodeService, IMessenger Messenger)
        {
            _barCodeService = barCodeService;
            ScanBarCodeCommand = new AsyncRelayCommand(ScanBarCode);
            Messenger.Register<BarcodeChangedMessage>(this, (_, barcode) => BarCodeValue = barcode.NewBarcodeValue);
        }

        private async Task ScanBarCode()
        {
            BarCodeValue = await _barCodeService.ReadBarCode();
        }
    }
}
