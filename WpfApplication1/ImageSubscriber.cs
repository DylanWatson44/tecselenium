using SeleniumDemo;
using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WpfApplication1
{
    //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/events/how-to-publish-events-that-conform-to-net-framework-guidelines
    /// <summary>
    /// This is an object that inherits from Image, but it attaches the method "updateResultImageEvent" to its publisher (a queryobject), so that when that query object
    /// has its result updated, it will fire the newly attached method, causing this objects image to change appropriately based on the result. 
    /// </summary>
    class ImageSubscriber : Image
    {
        public ImageSubscriber(QueryObject pub)
        {
            pub.resultReturnedEvent += updateResultImageEvent;
        }

        //action to take when event is raised
        void updateResultImageEvent(object sender, TestResultEvent myevent)
        {
            //the dispatcher is required to talk to the UI thread, else this will not work when being called from a non UI thread.
            Dispatcher.Invoke(() => { 
                Uri uri;
                if (myevent.getResult())
                {
                    uri = new Uri(@"Resources/check.png", UriKind.Relative);
                }
                else
                {
                    uri = new Uri(@"Resources/cross.png", UriKind.Relative);
                }
                Source = new BitmapImage(uri);
            });
        }
    }

}
