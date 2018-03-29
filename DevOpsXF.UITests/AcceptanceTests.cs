using NUnit.Framework;
using Xamarin.UITest;

namespace DevOpsXF.UITests
{
	[Category("Acceptance")]
	public class AcceptanceTests : BaseTest {
		public AcceptanceTests(Platform platform) : base(platform) {
		}

		[Test]
		[TestCase("20")]
		[TestCase("-20")]
		[TestCase("AA")]
		public void CalculateResult(string val) {
			var mainPage = new MainTestPage();
			mainPage.EnterEntryValue(val);
			mainPage.TapCalculateButton();
			
			App.WaitForElement(e => e.Text("ResultPage"));
			App.Screenshot("CalculateResult from Acceptance Test");
		}
	}
}