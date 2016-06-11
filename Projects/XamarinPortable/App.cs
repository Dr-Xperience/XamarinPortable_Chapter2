using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinPortable
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application 
            System.Diagnostics.Debug.WriteLine("App Started :: "+Dependency.DependencyInjector.getDependencyInjector().Device);
            //MainPage = new Page1();
            MainPage = new XamlPage();
            //Looper vLooper = new Looper();
            //vLooper.Notification += NotificationHandler;
            //System.Diagnostics.Debug.WriteLine("Loop Started");
            //Task.Run(() => { vLooper.startInfiniteLoop(); });
            //vLooper.startInfiniteLoop();
            System.Diagnostics.Debug.WriteLine("App Stopped");
        }
        //{
        //Content = new StackLayout
        //    {
        //        VerticalOptions = LayoutOptions.Center,
        //        Children = {
        //            new Label {
        //                HorizontalTextAlignment = TextAlignment.Center,
        //                Text = "Welcome to Xamarin Forms!"
        //            },
        //            new Label
        //            {
        //                HorizontalTextAlignment = TextAlignment.Center,
        //                Text = "New Label"
        //            }
        //        }
        //    }
        //};

        //public void NotificationHandler(object sender, CustomArgs args)
        //{
        //    if (args.Counter == 100)
        //    {
        //        Device.BeginInvokeOnMainThread(() =>
        //       {
        //           MainPage = new ContentPage
        //           {
        //               Content = new StackLayout
        //               {
        //                   VerticalOptions = LayoutOptions.Center,
        //                   Children =
        //               {
        //                    new Label
        //                    {
        //                        HorizontalTextAlignment = TextAlignment.Center,
        //                        Text = "Loop Exceeded 100 Iterations"
        //                    }
        //               }
        //               }
        //           };
        //       });
        //    }
        //    else
        //    {
        //        Device.BeginInvokeOnMainThread(() =>
        //        {
        //            Label ilabel = (Label)((StackLayout)((Page1)MainPage).Content).Children[0];
        //            ilabel.Text = args.Message;
        //        });

        //    }
        //}


        protected override void OnStart()
        {
            // Handle when your app starts
           
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
