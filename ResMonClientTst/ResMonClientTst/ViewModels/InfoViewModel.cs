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
    public class InfoViewModel : BaseViewModel
    {
        public InfoViewModel(string url)
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
                OnPropertyChanged();
            }
        }

        private ObservableCollection<DataModel> _names = new ObservableCollection<DataModel>();
        public ObservableCollection<DataModel> Names
        {
            get { return _names; }
            set
            {
                _names = value;
                OnPropertyChanged();
            }
        }

        public int GetIndex(DataModel dataModel)
        {
            if(dataModel.Item == typeof(GpuModel))
            {
                for(int i = 0; i < Gpus.Count; i++)
                {
                    if (dataModel.Name == Gpus[i].Name)
                    {
                        return i;
                    }
                }
            }
            else if (dataModel.Item == typeof(CpuModel))
            {
                for (int i = 0; i < Cpus.Count; i++)
                {
                    if (dataModel.Name == Cpus[i].Name)
                    {
                        return i;
                    }
                }
            }
            else if (dataModel.Item == typeof(RamModel))
            {
                for (int i = 0; i < Rams.Count; i++)
                {
                    if (dataModel.Name == Rams[i].Name)
                    {
                        return i;
                    }
                }
            }

            return -1;
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
            if (Names.Count == 0)
            {
                foreach (var o in info.cpus)
                {
                    bool found = false;
                    foreach(DataModel d in Names)
                    {
                        if (d.Name == o.Name)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        Names.Add(new DataModel()
                        {
                            Name = o.Name,
                            Item = typeof(CpuModel)
                        });
                    }
                }

                foreach (var o in info.gpus)
                {
                    bool found = false;
                    foreach (DataModel d in Names)
                    {
                        if (d.Name == o.Name)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        Names.Add(new DataModel()
                        {
                            Name = o.Name,
                            Item = typeof(GpuModel)
                        });
                    }
                }

                foreach (var o in info.rams)
                {
                    bool found = false;
                    foreach (DataModel d in Names)
                    {
                        if (d.Name == o.Name)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        Names.Add(new DataModel()
                        {
                            Name = o.Name,
                            Item = typeof(RamModel)
                        });
                    }
                }
            }
            

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
