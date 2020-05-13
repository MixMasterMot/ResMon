using ResMonClientTst.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ResMonClientTst.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DefaultPage : ContentPage
    {
        InfoViewModel _infoViewModel;
        public DefaultPage(InfoViewModel infoViewModel)
        {
            InitializeComponent();
            _infoViewModel = infoViewModel;
        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            //Navigation.PushAsync(new Page4());
            //Application.Current.MainPage = new NavigationPage(new Page4());
            int i = 0;
            i++;
        }
    }
}