using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.iOS;

namespace DevOpsXF.UITests {
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public abstract class BaseTest {
		protected IApp App;
		protected readonly Platform Platform;
		protected bool OnAndroid { get; set; }
		protected bool OniOS { get; set; }

		public BaseTest(Platform platform) {
			Platform = platform;
		}

		[SetUp]
		public virtual void BeforeEachTest() {
			App = AppInitializer.StartApp(Platform);
			OnAndroid = App.GetType() == typeof(AndroidApp);
			OniOS = App.GetType() == typeof(iOSApp);
		}
	}
}
