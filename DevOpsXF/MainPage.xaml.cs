using System;
using System.Collections.Generic;
using Microsoft.AppCenter.Analytics;
using Xamarin.Forms;

namespace DevOpsXF
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		async void CalculateOnClicked(object sender, EventArgs e) {
			if (string.IsNullOrEmpty(ValueEntry.Text)) {
				await DisplayAlert("Empty value", "Please enter valid number", "OK");
				return;
			}

			var resultPage = new ResultPage();
			resultPage.SetOriginalValue(ValueEntry.Text);

			Analytics.TrackEvent("CalculateButtonTapped", new Dictionary<string, string>{{"Value", ValueEntry.Text}});

			await Navigation.PushAsync(resultPage);
		}
	}
}
