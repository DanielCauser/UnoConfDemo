using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

        public MainPageViewModel(IBarCodeReaderService barCodeService)
        {
            _barCodeService = barCodeService;
            ScanBarCodeCommand = new AsyncRelayCommand(ScanBarCode);
        }

        private async Task ScanBarCode()
        {
            BarCodeValue = await _barCodeService.ReadBarCode();
        }
    }
}
