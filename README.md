# Microsoft-App-Center-Push-Notifications API

Xamarin.Forms Application that uses Visual Studio (on Mac or Windows) to build iOS and Android apps that work to get a list of the published Push Notifications from the Microsoft App Center using the AppCenter APIs
###### 

## 1. Purpose
This repository contains the code used to generate the list of notifications on your existing Xamarin Forms iOS and Android apps

## 2. Motivation
I love dabbling into new technology and was always fascinated with implementing Push Notifications to work from Start to Finish. So, I made this repository to help others reach their dreams and do some real winning.
So if you ever find my repo. helpful, please give me a shoutout at i@saamer.me, or on Twitter @Saamerm, or like me at facebook.com/prototypemakers
I always welcome constructive criticism and let me know if you want to see more!!

## 3. How to Use this
Once you make a free account on the MS App Center and set up the App Center and App Center Push notifications in the app using instructions in https://appcenter.ms/apps and https://docs.microsoft.com/en-us/appcenter/sdk/push/xamarin-forms
### 3.1 You need to buy
Nothing, this is all free! 

### 3.2 How do I know that I set up the  correctly
Follow instructions in the docs of the website above, and try to send a push notification your iOS and Android device. If the notification goes through, you're in business.

### 3.2 What else do I need
You need three things-
- Create an API token (XApiToken) in the app center and store it with you.
- (Tricky part) You'll need the owner name (owner_name) of the app from the App Center. 
  - If the app owner is a Organization, you can find this Under the Organization's Manage->Settings->Organization URL suffix (what ever comes after https://appcenter.ms/orgs/)
  - If the app owner is you, you can find this by clicking on your icon in the bottom left corner of the screen->Account Settings->Profile->Username
- Get the registered name of the app (app_name) by going to the Dashboard of the App Center, clicking on the app and checking the suffix of the URL after /apps/...
  - Note that the app name for the iOS and Android apps will be different
### 3.4 Ready to build that mobile app?
Once you make sure the device push notification works in the apps, Fork this repository, Clone it to your computer, and open the solution in Visual Studio. In the HomePage.cs file, edit,
- The XApiToken string below this comment where you Enter you X-Api-Token value you get from microsoft's app center
- The baseURL for the iOS app in the ComputeBaseURL() function - https://api.appcenter.ms//v0.1/apps/{owner_name}/{iOS app_name}/push
- The baseURL for the Android app in the ComputeBaseURL() function - https://api.appcenter.ms//v0.1/apps/{owner_name}/{Android app_name}/push
Voila. It should work.

## 4. Doesnt work?
Email me at i@saamer.me


