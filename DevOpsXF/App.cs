using System;
using DevOpsXF.DAL;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DevOpsXF
{
	public class App : Application {
		public App() {
			MainPage = new NavigationPage(new MainPage());
			DataService.Instance.Init("http://data.fixer.io", "8754892b614a90b5cb1debdf6948e7dc");
		}

		protected override void OnStart() {
			AppCenter.Start("ios={Your Xamarin iOS App Secret};" +
			                "android=cbd6369e-9944-4284-9bff-3cf550ab7907;",
				typeof(Crashes), typeof(Distribute));

			Crashes.NotifyUserConfirmation(UserConfirmation.AlwaysSend);
		}
	}
}
