using ResMonClientTst.Models;
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
    public partial class CpuPage : ContentPage
    {
        InfoViewModel _InfoViewModel;
        public CpuPage(InfoViewModel infoViewModel, DataModel dataModel)
        {
            InitializeComponent();
            BindingContext = _InfoViewModel = infoViewModel;

            int i = 0;
            LoadLbl.SetBinding(Label.TextProperty, new Binding($"Cpus[{i}].Load"));
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