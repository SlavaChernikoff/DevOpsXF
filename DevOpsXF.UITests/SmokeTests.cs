using NUnit.Framework;
using Xamarin.UITest;

namespace DevOpsXF.UITests {
	[Category("Smoke")]
	public class SmokeTests: BaseTest {
		public SmokeTests(Platform platform): base(platform) {
		}

		[Test]
		public void AppLaunches() {
			App.Screenshot("AppLaunches in Smoke UI test");
		}
	}
}

