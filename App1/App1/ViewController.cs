using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace App1
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.weatherBtn.Layer.BorderColor = UIColor.White.CGColor;
            this.weatherBtn.Layer.BorderWidth = 1;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        async partial void GetWeatherBtn_Click(UIButton sender)
        {
            if (!String.IsNullOrEmpty(this.zipCodeEntry.Text))
            {
                Clima clima = await Core.GetWeather(zipCodeEntry.Text);
                if (clima != null)
                {
                    locationText.Text = clima.Title;
                    tempText.Text = clima.Temperature;
                    windText.Text = clima.Wind;
                    visibilityText.Text = clima.Visibility;
                    humidityText.Text = clima.Humidity;
                    sunriseText.Text = clima.Sunrise;
                    sunsetText.Text = clima.Sunset;
                }
            }
        }
    }
}
