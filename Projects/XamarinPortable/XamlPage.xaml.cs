using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PlatformInfo;


namespace XamarinPortable
{
   
    public partial class XamlPage : ContentPage
    {
        public XamlPage()
        {
            InitializeComponent();

            IDeviceInfo gtr = Dependency.DependencyInjector.getDependencyInjector().Device;

            DeviceName.Text = gtr.Model + "\n"+gtr.Version;
        }
    }
}
