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
    public partial class DisplayPage : ContentPage
    {
        InfoViewModel _InfoViewModel;
        public DisplayPage(InfoViewModel infoViewModel, DataModel dataModel)
        {
            InitializeComponent();
            _InfoViewModel = infoViewModel;
            DrawPage(dataModel);

            BindingContext = _InfoViewModel;
        }

        private void DrawPage(DataModel dataModel)
        {
            string baseBind = "";
            int i = _InfoViewModel.GetIndex(dataModel);
            if (dataModel.Item == typeof(GpuModel))
            {
                baseBind = $"Gpus[{i}]";
                AddLoadGraph(baseBind);
                AddTempGraph(baseBind);
                AddMemoryGraph(baseBind);
            }
            else if (dataModel.Item == typeof(CpuModel))
            {
                baseBind = $"Cpus[{i}]";
                AddLoadGraph(baseBind);
                AddTempGraph(baseBind);
            }
            else if (dataModel.Item == typeof(RamModel))
            {
                baseBind = $"Rams[{i}]";
                AddMemoryGraph(baseBind);
                AddLoadGraph(baseBind);
            }
        }

        private void AddLoadGraph(string baseBind)
        {
            Label l = new Label()
            {
                Text = "Load % :",
                HorizontalOptions = LayoutOptions.Center
            };
            MainStackLayout.Children.Add(l);

            Label la = new Label()
            {
                HorizontalOptions = LayoutOptions.Center,
            };
            la.SetBinding(Label.TextProperty, new Binding(baseBind + ".Load"));
            MainStackLayout.Children.Add(la);
        }
        private void AddTempGraph(string baseBind)
        {
            Label l = new Label()
            {
                Text = "Temperature :",
                HorizontalOptions = LayoutOptions.Center
                //VerticalOptions = LayoutOptions.Center
            };
            MainStackLayout.Children.Add(l);

            Label la = new Label()
            {
                HorizontalOptions = LayoutOptions.Center,
            };
            la.SetBinding(Label.TextProperty, new Binding(baseBind + ".Temperature"));
            MainStackLayout.Children.Add(la);
        }
        private void AddMemoryGraph(string baseBind)
        {
            Label totRam = new Label()
            {
                Text = "Total Memory :",
                HorizontalOptions = LayoutOptions.Center
                //VerticalOptions = LayoutOptions.Center
            };
            MainStackLayout.Children.Add(totRam);
            Label totRamV = new Label()
            {
                HorizontalOptions = LayoutOptions.Center,
            };
            totRamV.SetBinding(Label.TextProperty, new Binding(baseBind + ".MemoryTotal"));
            MainStackLayout.Children.Add(totRamV);

            Label usedRam = new Label()
            {
                Text = "Used Memory :",
                HorizontalOptions = LayoutOptions.Center
                //VerticalOptions = LayoutOptions.Center
            };
            MainStackLayout.Children.Add(usedRam);
            Label usedRamV = new Label()
            {
                HorizontalOptions = LayoutOptions.Center,
            };
            usedRamV.SetBinding(Label.TextProperty, new Binding(baseBind + ".MemoryUsed"));
            MainStackLayout.Children.Add(usedRamV);

            Label freeRam = new Label()
            {
                Text = "Free Memory :",
                HorizontalOptions = LayoutOptions.Center
                //VerticalOptions = LayoutOptions.Center
            };
            MainStackLayout.Children.Add(freeRam);
            Label freeRamV = new Label()
            {
                HorizontalOptions = LayoutOptions.Center,
            };
            freeRamV.SetBinding(Label.TextProperty, new Binding(baseBind + ".MemoryFree"));
            MainStackLayout.Children.Add(freeRamV);
        }

    }
}