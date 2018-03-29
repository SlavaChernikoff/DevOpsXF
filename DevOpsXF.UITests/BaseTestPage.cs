using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.iOS;

namespace DevOpsXF.UITests {
	public class BaseTestPage {
		protected readonly IApp App;
		protected readonly bool OnAndroid;
		protected readonly bool OniOS;
		
		Platform _platform;

		protected BaseTestPage() {
			App = AppInitializer.App;
			OnAndroid = App.GetType() == typeof(AndroidApp);
			OniOS = App.GetType() == typeof(iOSApp);
		}

		public BaseTestPage(Platform platform) : this() {
			_platform = platform;
		}

	}
}
