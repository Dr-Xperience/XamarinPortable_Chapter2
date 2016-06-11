using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinPortable
{
    public class Page1 : ContentPage
    {
        Looper vLooper;
        //Task thread;
        CancellationTokenSource cancelTokenSource;
        private int styleID = 0;
        public int StyleIDCounter
        {
            get { return ++styleID; }
        }
        Label iLable = new Label
        {
            Text = " New Page"
        };

        
        StackLayout forScroller = new StackLayout();
        Button AddLabel = new Button
        {
            Text = "Add Anonymoud Delegate and lambda Label"
        };
        Button StartLoop = new Button { Text = "StartLoop" };
        int counter = 0;

        StackLayout vRef = new StackLayout();
        //{
        //    Children = button,
        //};
        public Page1()
        {
            Device.OnPlatform(WinPhone: () =>
             {
                 Padding = new Thickness(0,30,0,0);
             });

            Device.OnPlatform(Android: () =>
             {
                 Padding = new Thickness(30, 30, 0, 0);
             });
            Content = vRef;
            
            AddLabel.Clicked += delegate
            {
                iLable.BackgroundColor = Color.Black;
                iLable.TextColor = Color.White;
                iLable.Text = "Clicked" + counter++;
            };
            AddLabel.Clicked += (sender, Args) => {
                forScroller.Children.Add(new Label { Text = "Added new Lamda Label"});
            };
            vRef.Children.Add(iLable);
            vRef.Children.Add(AddLabel);
            vRef.Children.Add(StartLoop);
            StartLoop.Clicked += ButtonHandler;
            vRef.Children.Add(new ScrollView
            {
                //VerticalOptions = LayoutOptions.FillAndExpand,
                Content = forScroller
            });
            
        }

        async void ButtonHandler(object Sender, EventArgs args)
        {
            iLable.BackgroundColor = Color.Black;
            iLable.TextColor = Color.White;
            iLable.Text="Clicked";
            String StyleID = StyleIDCounter.ToString();
            forScroller.Children.Add(new Label { Text = "Added new Label", StyleId = StyleID});
            System.Diagnostics.Debug.WriteLine("Loop Started");
            
            cancelTokenSource = new CancellationTokenSource();

            await Task.Factory.StartNew((o) => {
                vLooper = new Looper()
                {
                    StyleID = StyleID,
                    CancelTokenSource = cancelTokenSource,
                };
                vLooper.Notification += NotificationHandler;
                vLooper.startInfiniteLoop(); },TaskCreationOptions.LongRunning,cancelTokenSource.Token);

            System.Diagnostics.Debug.WriteLine("Loop Completed");
            //thread = Task.Run(()=>
            //{
            //    vLooper.startInfiniteLoop();
            //});


        }

        public void NotificationHandler(object sender, CustomArgs args)
        {
            if (args.Counter == 700)
            {
                Device.BeginInvokeOnMainThread(delegate
               {
                   iLable.BackgroundColor = Color.Yellow;
                   iLable.TextColor = Color.Red;
                   iLable.Text = "Counter Exceeded 700";
                   
                    //throw new Exception("Counter Exceeded 100");                     
                });

                args.CancelTokenSource.Cancel();                                
                //throw new System.Threading.Tasks.TaskCanceledException();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(args.Message + args.Counter);
                Device.BeginInvokeOnMainThread(() => {

                    foreach(View view in forScroller.Children)
                    {
                        if(view.StyleId != null && view.StyleId.Contains(args.LabelArgs))
                        {
                            (view as Label).Text = args.Message;
                        }
                    }
                    
                });
               
            }
        }

    }
}
