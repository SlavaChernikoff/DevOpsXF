using DevOpsXF.DAL;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DevOpsXF
{
	public class App : Application {
		public App() {
			MainPage = new NavigationPage(new MainPage());
			DataService.Instance.Init("http://apilayer.net", "1809397aeb646717dc0f4b44f820d81c");
		}
	}
}
