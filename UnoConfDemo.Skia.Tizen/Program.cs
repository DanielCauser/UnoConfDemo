using Tizen.Applications;
using Uno.UI.Runtime.Skia;

namespace UnoConfDemo.Skia.Tizen
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new TizenHost(() => new UnoConfDemo.App(), args);
            host.Run();
        }
    }
}
