using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using UserNotifications;
using Firebase.CloudMessaging;
using Firebase.Analytics;
using ToastIOS;

namespace FirstApp.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate, IMessagingDelegate, IUNUserNotificationCenterDelegate	
	{
		
		UIWindow window;

		public UINavigationController RootNavigationController
		{
			get;
			private set;
		}

		public void ApplicationReceivedRemoteMessage(RemoteMessage remoteMessage)
		{
			//Toast.MakeText("remote Message received!!").Show();
			Toast.MakeText(remoteMessage.AppData.Description).Show();
			System.Console.WriteLine(remoteMessage.AppData.Description);
			Console.WriteLine(remoteMessage.AppData.Description);
		}

		public override void DidReceiveRemoteNotification(UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
		{
			var message = userInfo;
			Toast.MakeText("Message received!!").Show();
			System.Console.WriteLine(userInfo);
		}

		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			RootNavigationController = new UINavigationController();

			window = new UIWindow(UIScreen.MainScreen.Bounds);
			var viewController = new CategoryViewController();

			RootNavigationController.PushViewController(viewController, false);

			window.RootViewController = RootNavigationController;

			window.MakeKeyAndVisible();

			Firebase.Analytics.App.Configure();

			if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
			{
				// iOS 10 or later
				var authOptions = UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound;
				UNUserNotificationCenter.Current.RequestAuthorization(authOptions, (granted, error) =>
				{
					Console.WriteLine(granted);
				});

				// For iOS 10 display notification (sent via APNS)
				UNUserNotificationCenter.Current.Delegate = this;

				//// For iOS 10 data message (sent via FCM)
				Messaging.SharedInstance.RemoteMessageDelegate = this;
			}
			else {
				// iOS 9 or before
				var allNotificationTypes = UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound;
				var settings = UIUserNotificationSettings.GetSettingsForTypes(allNotificationTypes, null);
				UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
			}

			UIApplication.SharedApplication.RegisterForRemoteNotifications();


			Messaging.SharedInstance.Connect(error =>
			{
				if (error != null)
				{
					Console.WriteLine("Error in creating connection");
				}
				else {
					Console.WriteLine("Success in creating connection");
				}
			});
			return true;
		}
	}
}
