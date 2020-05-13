using Microsoft.AspNet.SignalR.Client;
using ResMonClientTst.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ResMonClientTst.ViewModels
{
    public class InfoViewModelTemp : BaseViewModel 
    {
        public InfoViewModelTemp(string url)
        {
            InfoViewModelInit(url);
        }

        private List<CpuModel> _cpus = new List<CpuModel>();
        public List<CpuModel> Cpus
        {
            get { return _cpus; }
            set
            {
                _cpus = value;
                UpdateBaseModels(cpusPar: _cpus);
                OnPropertyChanged();
            }
        }

        private List<GpuModel> _gpus = new List<GpuModel>();
        public List<GpuModel> Gpus
        {
            get { return _gpus; }
            set
            {
                _gpus = value;
                UpdateBaseModels(gpusPar: _gpus);
                OnPropertyChanged();
            }
        }

        private List<RamModel> _rams = new List<RamModel>();
        public List<RamModel> Rams
        {
            get { return _rams; }
            set
            {
                _rams = value;
                UpdateBaseModels(ramsPar: _rams);
                OnPropertyChanged();
            }
        }

        private ObservableCollection<string> _names = new ObservableCollection<string>();
        public ObservableCollection<string> Names
        {
            get { return _names; }
            set
            {
                _names = value;
                OnPropertyChanged();
            }
        }

        private void UpdateBaseModels(List<RamModel> ramsPar = null, List<GpuModel> gpusPar = null, List<CpuModel> cpusPar = null)
        {
            bool changed = false;
            ObservableCollection<string> tempNames = Names;
            if (ramsPar != null)
            {
                foreach (var o in ramsPar)
                {
                    if (!tempNames.Contains(o.Name))
                    {
                        tempNames.Add(o.Name);
                        if (!changed) changed = true;
                    }
                }
            }

            if (gpusPar != null)
            {
                foreach (var o in gpusPar)
                {
                    if (!tempNames.Contains(o.Name))
                    {
                        tempNames.Add(o.Name);
                        if (!changed) changed = true;
                    }
                }
            }

            if (cpusPar != null)
            {
                foreach (var o in cpusPar)
                {
                    if (!tempNames.Contains(o.Name))
                    {
                        tempNames.Add(o.Name);
                        if (!changed) changed = true;
                    }
                }
            }

            if (changed)
            {
                Names = tempNames;
            }
        }

        public void GetModel(string name)
        {

        }

        // signalR section
        private HubConnection _hubConnection;
        private IHubProxy _hubProxy;

        async void InfoViewModelInit(string url)
        {
            StartListenForInfo(url);
            await SignalRConnect();
        }

        void UpdateInfo(InfoModel info)
        {
            Cpus = info.cpus;
            Gpus = info.gpus;
            Rams = info.rams;
        }

        void StartListenForInfo(string url)
        {
            _hubConnection = new HubConnection(url);
            _hubProxy = _hubConnection.CreateHubProxy("InfoHub");

            _hubProxy.On<InfoModel>("updateInfo", info =>
            {
                UpdateInfo(info);
            });
        }

        // TODO
        // TRY CATCH CONECTION.START
        async Task SignalRConnect()
        {
            await _hubConnection.Start();
        }
    }
}
