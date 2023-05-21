using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio07
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BatteryDemo : ContentPage
    {
        public BatteryDemo()
        {
            InitializeComponent();

            StackLayout stack = new StackLayout();
            var button = new Button
            {
                Text = "Click for battery info",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            button.Clicked += (sender, e) =>
            {
                var bat = DependencyService.Get<IBattery>();
                switch (bat.PowerSource)
                {
                    case PowerSource.Battery:
                        button.Text = "Battery - ";
                        break;
                    case PowerSource.Ac:
                        button.Text = "AC - ";
                        break;
                    case PowerSource.Usb:
                        button.Text = "USB - ";
                        break;
                    case PowerSource.Wireless:
                        button.Text = "Wireless - ";
                        break;
                    case PowerSource.Other:
                    default:
                        button.Text = "Unknown - ";
                        break;
                }
                switch (bat.Status)
                {
                    case BatteryStatus.Charging:
                        button.Text += "Charging";
                        break;
                    case BatteryStatus.Discharging:
                        button.Text += "Discharging";
                        break;
                    case BatteryStatus.NotCharging:
                        button.Text += "Not Charging";
                        break;
                    case BatteryStatus.Full:
                        button.Text += "Full";
                        break;
                    case BatteryStatus.Unknown:
                    default:
                        button.Text += "Unknown";
                        break;
                }
            };
            stack.Children.Add(button);
            Content = stack;
        }
    }
}