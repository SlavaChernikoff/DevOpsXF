using System;
using System.Collections.Generic;
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
				Crashes.TrackError(e);
			}
		}

		protected override async void OnAppearing() {
			base.OnAppearing();

			try {
				Crashes.GenerateTestCrash();
			}
			catch (Exception e) {
				var properties = new Dictionary<string, string>
				{
					{ "Value", _originalValue.ToString()},
					{ "BaseCurrency", "EUR"},
					{ "ToCurrency", "JPY"}
				};
				Crashes.TrackError(e, properties);
			}

			var resultValue = await DataService.Instance.GetResult(_originalValue, "EUR", "JPY");
			ResultLabel.Text = $"{_originalValue:F2} EUR = {resultValue:F2} JPY";
		}
	}
}