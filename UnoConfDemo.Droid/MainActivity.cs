using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content.PM;
using Android.Views;

namespace UnoConfDemo.Droid
{
	[Activity(
			MainLauncher = true,
			ConfigurationChanges = global::Uno.UI.ActivityHelper.AllConfigChanges,
			WindowSoftInputMode = SoftInput.AdjustPan | SoftInput.StateHidden
		)]
	public class MainActivity : Windows.UI.Xaml.ApplicationActivity
	{

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            ZXing.Mobile.MobileBarcodeScanner.Initialize(Application);
        }
    }
}

