
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using Uno.Foundation;
using Uno.UI.Runtime.WebAssembly;

namespace UnoConfDemo
{
    [ContentProperty(Name = "container")]
    [HtmlElement("div")] // PrismJS requires a <code> element
    public class BarCodeScanner : Control
    {
        public BarCodeScanner()
        {
            this.SetHtmlContent("<video autoplay='true' id='videoElement' width=500px; height=375px;></video>");

            Loaded += (_, _) => AskWebCamPermission();
        }

        private void AskWebCamPermission()
        {
            string javascript = $@"(function(){{
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

            this.ExecuteJavascript(javascript);
        }
    }
}