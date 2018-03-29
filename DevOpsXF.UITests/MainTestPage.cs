namespace DevOpsXF.UITests {
	public class MainTestPage: BaseTestPage {
		public MainTestPage EnterEntryValue(string val) {
			App.EnterText("ValueEntry", val);
			return this;
		}

		public MainTestPage TapCalculateButton() {
			App.Tap("CalculateButton");
			return this;
		}
	}
}
