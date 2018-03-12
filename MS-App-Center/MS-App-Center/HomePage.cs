using System.Diagnostics;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace MSAppCenter
{
    public class HomePage : ContentPage
    {
        // In order to make this app work, you need to change three things in this file,
        // 1) The XApiToken string below this comment where you Enter you X-Api-Token value you get from microsoft's app center
        // 2) The baseURL for the iOS app in the ComputeBaseURL() function below this file
        // 3) The baseURL for the Android app in the ComputeBaseURL() function below this file
        // Note: The baseURL looks like this-> https://api.appcenter.ms//v0.1/apps/{owner_name}/{app_name}/push
        // and since the app_name changes for each platform (iOS and Android), therefore 
        // we use a switch case based on Device Platform in the ComputeBaseURL() to fix that!

        string XApiToken = "{X API TOKEN GOES HERE}";
        string baseURL = "";

        public HomePage()
        {
            ComputeBaseURL();

            Label title = new Label
            {
                Text = "MS App Center Notification",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.StartAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };

            Label subtitle = new Label
            {
                Text = "Click below to get a notification list",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.StartAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };
            Label notificationDetailText = new Label
            {
                Text = "Click on this to get detail on the first notification",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.StartAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };

            Label resultText = new Label
            {
                Text = "",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.StartAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };

            Button notificationListButton = new Button
            {
                Text = "Get Notification List",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.StartAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button))
            };
            notificationListButton.Clicked += async (sender, e) =>
            {
                var client = new System.Net.Http.HttpClient();
                var uri = new System.Uri(baseURL + "/notifications?%24top=30&%24orderby=count%20desc&%24inlinecount=none");
                client.DefaultRequestHeaders.Add("X-API-Token", XApiToken);
                string obstring = string.Empty;
                try
                {
                    obstring = await client.GetStringAsync(uri);
                }
                catch (System.Exception ex)
                {
                    Debug.WriteLine(ex);
                    obstring = "";
                }
                Notifications notification = JsonConvert.DeserializeObject<Notifications>(obstring);
                resultText.Text = notification.values[0].notification_id;
            };

            Button notificationDetailButton = new Button
            {
                Text = "Get info on first notification",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.StartAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button))
            };
            notificationDetailButton.Clicked += async (sender, e) =>
            {
                var client = new System.Net.Http.HttpClient();
                var url = baseURL + "/notifications?%24top=30&%24orderby=count%20desc&%24inlinecount=none";
                var uri = new System.Uri(url);
                client.DefaultRequestHeaders.Add("X-API-Token", XApiToken);
                string obstring = string.Empty;
                try
                {
                    obstring = await client.GetStringAsync(uri);
                }
                catch (System.Exception ex)
                {
                    Debug.WriteLine(ex);
                    obstring = "";
                }
                var notification = JsonConvert.DeserializeObject<Notifications>(obstring);
                var notificationId = notification.values[0].notification_id;
                //Part 1 is done, using that info for call 2
                var client2 = new System.Net.Http.HttpClient();
                var url2 = baseURL + "/notifications/" + notificationId;
                var uri2 = new System.Uri(url2);
                client2.DefaultRequestHeaders.Add("X-API-Token", XApiToken);
                string obstring2 = string.Empty;
                try
                {
                    obstring2 = await client2.GetStringAsync(uri2);
                }
                catch (System.Exception ex)
                {
                    Debug.WriteLine(ex);
                    obstring2 = "";
                }
                var notificationDetail = JsonConvert.DeserializeObject<NotificationDetail>(obstring2);
                resultText.Text = notificationDetail.notification_content.title;
            };



            StackLayout stack = new StackLayout
            {
                Children = {title, subtitle,
                    notificationListButton, notificationDetailText, notificationDetailButton, resultText},
                Padding = 20
            };
            this.Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
            this.Content = stack;
        }

        private void ComputeBaseURL()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    baseURL = "iOS App Base URL goes here";
                    break;
                case Device.Android:
                    baseURL = "{Android App Base URL goes here}";
                    break;
            }
        }
    }
}
