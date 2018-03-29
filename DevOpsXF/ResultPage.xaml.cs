using System;
using DevOpsXF.DAL;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;

namespace DevOpsXF
{
	public partial class ResultPage : ContentPage {
		double _originalValue;

		public ResultPage ()
		{
			InitializeComponent();
		}

		public void SetOriginalValue(string val) {
			try {
				_originalValue = double.Parse(val);
			}
			catch (Exception e) {
				//ignored for now
			}
		}

		protected override async void OnAppearing() {
			base.OnAppearing();

			Crashes.GenerateTestCrash();

			var resultValue = await DataService.Instance.GetResult(_originalValue, "EUR", "JPY");
			ResultLabel.Text = $"{_originalValue:F2} EUR = {resultValue:F2} JPY";
		}
	}
}