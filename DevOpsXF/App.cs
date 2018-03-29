using DevOpsXF.DAL;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DevOpsXF
{
	public class App : Application {
		public App() {
			MainPage = new NavigationPage(new MainPage());
			DataService.Instance.Init("http://data.fixer.io", "8754892b614a90b5cb1debdf6948e7dc");
		}
	}
}
