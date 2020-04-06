using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TIPit
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            PriceEntry.HorizontalTextAlignment = TextAlignment.Center;
        }

        private void PercentSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var newStep = Math.Round(e.NewValue / 1.0);
            PercentSlider.Value = newStep;
            PercentText.Text = PercentSlider.Value.ToString();
            PercentText.TranslateTo(PercentSlider.Value * ((PercentSlider.Width - 38) / PercentSlider.Maximum), 0, 1);
            calculate();
        }
        private void SplitSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {

        }

        private void PriceEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            calculate();

        }

        private void calculate()
        {
            if (PriceEntry.Text == null || PriceEntry.Text == "" )
            {
                TipLabel.Text = "0";
                TotalLabel.Text = "0";
            }
            else
            {
                var price = float.Parse(PriceEntry.Text);
                var tip = Math.Round(price * PercentSlider.Value / 100, 2);
                TipLabel.Text = "$"+tip.ToString("0.00");
                TotalLabel.Text = "$"+(tip + price).ToString("0.00");
            }
        }
    }
}
