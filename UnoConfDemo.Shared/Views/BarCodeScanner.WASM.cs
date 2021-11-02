#if __WASM__
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using Uno.UI.Runtime.WebAssembly;
using Uno.Extensions;
using System.Diagnostics;

namespace UnoConfDemo
{
    [ContentProperty(Name = "container")]
    [HtmlElement("div")] // PrismJS requires a <code> element
    public class BarCodeScanner : Control
    {
        public BarCodeScanner()
        {
            this.SetHtmlContent("<video autoplay='true' id='videoElement' width=500px; height=375px;></video>");
            this.RegisterHtmlCustomEventHandler("BarCodeDetected", OnBarCodeDetected, isDetailJson: false);

            Loaded += (_, _) => InitJavascript();
        }

        private void OnBarCodeDetected(object sender, HtmlCustomEventArgs e)
        {
            Debug.WriteLine($"Barcode scanned and Invoked from C#! {e.Detail}");
        }

        private void InitJavascript()
        {
            string initHtmlVideoCapturingJs = $@"(function(){{
                var video = document.querySelector('#videoElement');
                if (navigator.mediaDevices.getUserMedia) {{
                     navigator.mediaDevices.getUserMedia({{ video: true }})
                      .then(function(stream) {{
                        video.srcObject = stream;
                    }})
                    .catch(function (err0r) {{
                        alert('COULD NOT FETCH THE MEDIA');
                    }});
                }}
            }})();";

            string initBarCodeScanJs = $@"(function(){{
                Quagga.init({{
                    inputStream: {{
                    name : 'Live',
                    type: 'LiveStream',
                    target: document.querySelector('#videoElement')
                    }},
                    decoder : {{
                    readers : ['code_128_reader']
                    }}
                }}, function(err) {{
                    if (err) {{
                        console.log(err);
                        return
                    }}
                    console.log('Initialization finished. Ready to start');
                }});

                Quagga.onDetected(function(result) {{
                    console.log('Barcode Detected: ' + result.codeResult.code);
                    //invoke C# code.
                    element.dispatchEvent(new CustomEvent(""BarCodeDetected"", {{detail: result.codeResult.code}}))
                }});
            }})();";

            this.ExecuteJavascript(initHtmlVideoCapturingJs);
            this.ExecuteJavascript(initBarCodeScanJs);
        }
    }
}
#endif