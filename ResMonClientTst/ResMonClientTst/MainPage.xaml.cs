using ResMonClientTst.Models;
using ResMonClientTst.ViewModels;
using ResMonClientTst.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ResMonClientTst
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {

        InfoViewModel _InfoViewModel;
        List<string> MainMenuItems;
        public MainPage()
        {
            InitializeComponent();

            MainMenuItems = new List<string>()
            {
                "Home",
                "Settings",
            };
            //MainNavigationList.ItemsSource = MainMenuItems;

            string url = "http://192.168.0.110:8080/signalr";
            _InfoViewModel = new InfoViewModel(url);

            NavigationList.ItemsSource = _InfoViewModel.Names;
            //BindingContext = _InfoViewModel;
            Detail = new NavigationPage(new DefaultPage(_InfoViewModel));
        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            DataModel item = (DataModel)e.SelectedItem;
            Detail = new NavigationPage(new DisplayPage(_InfoViewModel, item));
            //int i = e.SelectedItemIndex;
            //Detail = new NavigationPage(new DisplayPage(_InfoViewModel, i));
            //Detail = new NavigationPage(new CpuPage(_InfoViewModel));
            //if (item.Item == typeof(CpuModel))
            //{
            //    Detail = new NavigationPage(new DisplayPage(_InfoViewModel, item));
            //    //Detail = new NavigationPage(new CpuPage(_InfoViewModel, item));
            //}
            //else if (item.Item == typeof(GpuModel))
            //{
            //    //Detail = new NavigationPage(new GpuPage(_InfoViewModel, item));
            //}
            //else if (item.Item == typeof(RamModel))
            //{
            //    //Detail = new NavigationPage(new RamPage(_InfoViewModel, item));
            //}
        }

    }
}
