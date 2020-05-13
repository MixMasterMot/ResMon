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
    public partial class RamPage : ContentPage
    {
        public RamPage(InfoViewModel infoViewModel, DataModel dataModel)
        {
            InitializeComponent();
        }
    }
}