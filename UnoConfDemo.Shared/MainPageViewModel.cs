using System;
using System.Collections.Generic;
using System.Text;

namespace UnoConfDemo
{
    public class MainPageViewModel
    {
        private readonly IBarCodeReaderService _barCodeService;

        public MainPageViewModel(IBarCodeReaderService barCodeService)
        {
            _barCodeService = barCodeService;
        }
    }
}
