using System;
using Xamarin.UITest;

namespace DevOpsXF.UITests {
	public class AppInitializer {
		const string ProjectName = nameof(DevOpsXF);
		static readonly string ApkFile = $"../../../{ProjectName}.Android/bin/Release/com.binwell.{ProjectName}-Signed.apk";
		static readonly string Appfile = $"../../../{ProjectName}.iOS/bin/iPhoneSimulator/Release/{ProjectName}.iOS.app";
		
		static IApp _app;

		public static IApp App {
			get {
				if (_app == null)
					throw new NullReferenceException("AppInitializer.App' not set.");
				return _app;
			}
		}

		public static IApp StartApp(Platform platform) {
			if (platform == Platform.Android) {
				_app = ConfigureApp.Android.ApkFile(ApkFile)
					.EnableLocalScreenshots()
					.StartApp(Xamarin.UITest.Configuration.AppDataMode.Clear);
			}
			else {
				_app = ConfigureApp.iOS.AppBundle(Appfile)
					.DeviceIdentifier("4A802B8E-77C3-4362-BA49-C69845EF093C")
					.EnableLocalScreenshots()
					.StartApp(Xamarin.UITest.Configuration.AppDataMode.Clear);
			}

			return _app;
		}
	}
}

