using SeleniumDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WpfApplication1
{
    //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/events/how-to-publish-events-that-conform-to-net-framework-guidelines
    class ImageSubscriber : Image
    {
        public ImageSubscriber(QueryObject pub)
        {
            pub.resultReturnedEvent += updateResultImageEvent;
        }

        //action to take when event is raised
        void updateResultImageEvent(object sender, CustomEventArgs e)
        {
            Uri uri;
            if (e.getResult())
            {
                uri = new Uri(@"Resources/check.png", UriKind.Relative);
            }
            else
            {
                uri = new Uri(@"Resources/cross.png", UriKind.Relative);
            }
            Source = new BitmapImage(uri);
        }
    }

}
